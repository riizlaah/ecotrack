using EcoTrackAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace EcoTrackAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EcoTrackContext dbc;
        private readonly IConfiguration config;
        public AuthController(EcoTrackContext ctx, IConfiguration conf)
        {
            dbc = ctx;
            config = conf;
        }
        [Authorize]
        [HttpGet("me")]
        public IResult Me()
        {
            if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int userId))
            {
                return Helper.errResponse("User id not valid!", 400);
            }
            var user = dbc.Users.Find(userId);
            return Helper.Success(new
            {
                id = user.Id,
                fullName = user.FullName,
                username = user.Username,
                role = user.Role,
                phone = user.Phone,
                balance = user.Balance
            }, "Profile fetched successfully.");
        }
        [HttpPost("login")]

        public IResult Login(UserLoginDTO input)
        {
            if (input.username.Trim() == "") return Helper.errResponse("Username not valid!");
            if (input.password.Trim() == "") return Helper.errResponse("Password not valid!");
            var user = dbc.Users.Where(u => u.Username == input.username).FirstOrDefault();
            if(user != null)
            {
                if (!isHashEqual(input.password, user.Password)) return Helper.errResponse("Wrong username or password.");
                return Helper.Success(new { username = user.Username, fullName = user.FullName, token = GenerateToken(user.Id.ToString(), user.Username, user.Role) });
            }
            return Helper.errResponse("Wrong username or password.");
        }

        [HttpPost("register")]
        public IResult Register(CustomerRegisterDTO input)
        {
            if (input.username.Trim() == "") return Helper.errResponse("Username not valid!");
            if (input.fullName.Trim() == "") return Helper.errResponse("Full Name not valid!");
            if (Regex.IsMatch(input.phone, @"^\+?\d{8,12,}$")) return Helper.errResponse("Phone number not valid!");
            if(!input.password.Any(Char.IsDigit) || !input.password.Any(Char.IsLetter) || !input.password.Any(c => !Char.IsDigit(c) && !Char.IsLetter(c)))
            {
                return Helper.errResponse("Password must contains combination of number, letters and symbols.");
            }
            if(input.password.Length < 6)
            {
                return Helper.errResponse("Password length must be at least 6 characters");
            }
            if(dbc.Users.Any(u => u.Username == input.username))
            {
                return Helper.errResponse("Username has been used.");
            }
            input.password = hash(input.password);
            var user = input.toUser();
            dbc.Users.Add(user);
            dbc.SaveChanges();
            return Helper.Success(new {userId = user.Id, username = user.Username, role = user.Role}, "Account created successfully.");
        }

        public string hash(string input)
        {
            using(var alg = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashedBytes = alg.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                foreach(var b in hashedBytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public bool isHashEqual(string input, string hashedStr)
        {
            var hashedInput = hash(input);
            return StringComparer.OrdinalIgnoreCase.Compare(hashedInput, hashedStr) == 0;
        }

        public string GenerateToken(string userId, string username, string role)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Name, userId),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: config["Jwt:Issuer"],
                audience: config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token).ToString();
        }
    }
}
