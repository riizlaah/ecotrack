namespace EcoTrackAPI
{
    public class Helper
    {
        public static IResult Success(object obj, string msg = "Success")
        {
            return Results.Json( new 
            {
                message = msg,
                data = obj
            });
        }
        public static IResult errResponse(string msg, int code = 400)
        {
            return Results.Json(new
            {
                message = msg,
            }, statusCode: code);
        }
    }
}
