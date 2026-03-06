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
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.text.BasicSecureTextField
import androidx.compose.foundation.text.input.TextFieldState
import androidx.compose.material3.Button
import androidx.compose.material3.CircularProgressIndicator
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
import androidx.compose.ui.unit.dp
import androidx.navigation.NavHostController
import kotlinx.coroutines.launch


@Composable
fun LoginScreen(modifier: Modifier, controller: NavHostController) {
    var username by remember { mutableStateOf("") }
    var errMsg by remember { mutableStateOf("") }
    var loading by remember { mutableStateOf(false) }
    val passState = remember { TextFieldState() }
    val scope = rememberCoroutineScope()
    Column(modifier.padding(32.dp), verticalArrangement = Arrangement.Center) {
        Alert(errMsg.isNotEmpty(), {errMsg = ""}, errMsg)
        Text("Login", fontSize = MaterialTheme.typography.headlineSmall.fontSize)
        Spacer(Modifier.height(12.dp))
        OutlinedTextField(
            value = username,
            onValueChange = { username = it },
            label = { Text("Username") },
            modifier = Modifier.fillMaxWidth()
        )
        Spacer(Modifier.height(8.dp))
        PasswordField(passState, modifier = Modifier.fillMaxWidth())
        Spacer(Modifier.height(12.dp))
        Button(onClick = {
            if(username.isEmpty()) {
                errMsg = "Username can't be empty"
                return@Button
            }
            if(passState.text.isEmpty()) {
                errMsg = "Password can't be empty"
                return@Button
            }
            scope.launch {
                loading = true
                if(HttpClient.login(username, passState.text.toString())) {
                    controller.navigate(Route.HOME) {
                        popUpTo(controller.graph.id) {
                            inclusive = true
                        }
                    }
                    return@launch
                } else {
                    errMsg = "Invalid username or password."
                }
                loading = false
            }
        }, modifier = Modifier.fillMaxWidth()) {
            if(loading) {
                Loading()
                return@Button
            }
            Text("Sign In")
        }
        Row(Modifier.fillMaxWidth(), verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.Center) {
            Text("Don't have an account?")
            TextButton(onClick = {controller.navigate(Route.REGISTER)}) {
                Text("Register")
            }
        }
    }
}