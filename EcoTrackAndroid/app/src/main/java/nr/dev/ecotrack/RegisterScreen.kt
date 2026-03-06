package nr.dev.ecotrack

import androidx.compose.foundation.border
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.text.BasicSecureTextField
import androidx.compose.foundation.text.input.TextFieldState
import androidx.compose.material3.AlertDialog
import androidx.compose.material3.Button
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.Text
import androidx.compose.material3.TextButton
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.rememberCoroutineScope
import androidx.compose.runtime.setValue
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.navigation.NavHostController
import kotlinx.coroutines.launch


@Composable
fun RegisterScreen(modifier: Modifier, controller: NavHostController) {
    var username by remember { mutableStateOf("") }
    var fullName by remember { mutableStateOf("") }
    var phoneNum by remember { mutableStateOf("") }
    val passState = remember { TextFieldState() }
    val passState2 = remember { TextFieldState() }

    var loading by remember { mutableStateOf(false) }
    var errMsg by remember { mutableStateOf("") }
    val scope = rememberCoroutineScope()
    Column(modifier.padding(32.dp), verticalArrangement = Arrangement.Center) {
        Text("Register", fontSize = MaterialTheme.typography.headlineSmall.fontSize)
        Spacer(Modifier.height(12.dp))
        OutlinedTextField(
            value = username,
            onValueChange = { username = it },
            label = { Text("Username") },
            modifier = Modifier.fillMaxWidth()
        )
        Spacer(Modifier.height(8.dp))
        OutlinedTextField(
            value = fullName,
            onValueChange = { fullName = it },
            label = { Text("Full Name") },
            modifier = Modifier.fillMaxWidth()
        )
        Spacer(Modifier.height(8.dp))
        OutlinedTextField(
            value = phoneNum,
            onValueChange = { phoneNum = it },
            label = { Text("Phone Number") },
            modifier = Modifier.fillMaxWidth()
        )
        Spacer(Modifier.height(8.dp))
        PasswordField(passState, modifier = Modifier.fillMaxWidth())
        Spacer(Modifier.height(8.dp))
        PasswordField(passState2, "Confirm Password", modifier = Modifier.fillMaxWidth())
        Spacer(Modifier.height(12.dp))
        if(errMsg.isNotEmpty()) {
            Text(errMsg, color = Color.Red, modifier = Modifier.fillMaxWidth(), textAlign = TextAlign.Center)
        }
        Button(onClick = {
            if(username.isBlank()) {
                errMsg = "Username must be filled."
                return@Button
            }
            if(fullName.isBlank()) {
                errMsg = "Full Name must be filled."
                return@Button
            }
            if(!phoneNum.matches(Regex("^\\+?\\d+$"))) {
                errMsg = "Phone Number not valid."
                return@Button
            }
            if(!passState.text.any { it.isDigit() } || !passState.text.any { it.isLetter() } || !passState.text.any { !it.isLetterOrDigit() }) {
                errMsg = "Password must contains combination of letters, number and symbols."
                return@Button
            }
            if(passState.text != passState2.text) {
                errMsg = "Password and Confirmation Password must be same."
                return@Button
            }
            errMsg = ""
            scope.launch {
                loading = true
                when(val msg = HttpClient.register(username, fullName, phoneNum, passState.text.toString())) {
                    "ok" -> {controller.navigate(Route.LOGIN)}
                    else -> {errMsg = msg}
                }
                loading = false
            }
        }, modifier = Modifier.fillMaxWidth()) {
            if(loading) {
                Loading()
                return@Button
            }
            Text("Register")
        }
        Row(Modifier.fillMaxWidth(), verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.Center) {
            Text("Already have an account?")
            TextButton(onClick = {controller.navigate(Route.LOGIN)}) {
                Text("Login")
            }
        }
    }
}