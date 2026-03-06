package nr.dev.ecotrack

import android.os.Bundle
import androidx.activity.ComponentActivity
import androidx.activity.compose.setContent
import androidx.activity.enableEdgeToEdge
import androidx.compose.foundation.background
import androidx.compose.foundation.border
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxSize
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.wrapContentHeight
import androidx.compose.foundation.layout.wrapContentSize
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.text.BasicSecureTextField
import androidx.compose.foundation.text.input.TextFieldState
import androidx.compose.material3.CircularProgressIndicator
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Scaffold
import androidx.compose.material3.Text
import androidx.compose.material3.TextButton
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.tooling.preview.Preview
import androidx.compose.ui.unit.Dp
import androidx.compose.ui.unit.dp
import androidx.compose.ui.window.Dialog
import androidx.compose.ui.window.DialogProperties
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.rememberNavController
import nr.dev.ecotrack.ui.theme.EcoTrackTheme

class MainActivity : ComponentActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContent {
            EcoTrackTheme {
                val controller = rememberNavController();
                Scaffold(modifier = Modifier.fillMaxSize()) { innerPadding ->
                    NavHost(
                        navController = controller,
                        startDestination = Route.LOGIN
                    ) {
                        val mod = Modifier.fillMaxSize().padding(innerPadding)
                        composable(route = Route.LOGIN) {
                            LoginScreen(mod, controller)
                        }
                        composable(route = Route.REGISTER) {
                            RegisterScreen(mod, controller)
                        }
                        composable(route = Route.HOME) {
                            HomeScreen(mod, controller)
                        }
                    }
                }
            }
        }
    }
}

@Composable
fun PasswordField(state: TextFieldState, placeholder: String = "Password...", modifier: Modifier = Modifier) {
    BasicSecureTextField(
        state = state,
        modifier = modifier,
        decorator = { tField ->
            Box(
                Modifier
                    .fillMaxWidth()
                    .clip(RoundedCornerShape(8.dp))
                    .border(
                        1.dp, Color.Gray,
                        RoundedCornerShape((8.dp))
                    )
                    .padding(12.dp, 16.dp)
            ) {
                if(state.text.isEmpty()) {
                    Text(placeholder, color = Color.LightGray)
                }
                tField()
            }
        }
    )
}

@Composable
fun Alert(visible: Boolean, onOKClicked: () -> Unit, content: String, withCancel: Boolean = false, onCancelClicked: () -> Unit = {}, title: String = "Alert") {
    if(visible) {
        Dialog(onDismissRequest = {}) {
            Column(Modifier.size(300.dp, 200.dp).clip(RoundedCornerShape(16.dp)).background(Color.White).padding(16.dp)) {
                Text(title, fontSize = MaterialTheme.typography.titleSmall.fontSize, fontWeight = FontWeight.SemiBold)
                Spacer(Modifier.height(16.dp))
                LazyColumn(Modifier.weight(1f)) {
                    item {
                        Text(content)
                    }
                }
                Spacer(Modifier.height(8.dp))
                Row(Modifier.fillMaxWidth(), verticalAlignment = Alignment.CenterVertically, horizontalArrangement = Arrangement.End) {
                    if(withCancel) {
                        TextButton(onClick = onCancelClicked) {
                            Text("Cancel")
                        }
                    }
                    TextButton(onClick = onOKClicked) {
                        Text("OK")
                    }
                }
            }
        }
    }
}

@Composable
fun Loading(size: Dp = 32.dp, color: Color = Color.White) {
    CircularProgressIndicator(modifier = Modifier.size(size), color = color, strokeWidth = 2.dp)
}
