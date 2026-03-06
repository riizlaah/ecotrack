package nr.dev.ecotrack


import androidx.compose.foundation.BorderStroke
import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.Column
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.Spacer
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.layout.size
import androidx.compose.foundation.layout.width
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Button
import androidx.compose.material3.CircularProgressIndicator
import androidx.compose.material3.DropdownMenu
import androidx.compose.material3.DropdownMenuItem
import androidx.compose.material3.Icon
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.OutlinedTextField
import androidx.compose.material3.Text
import androidx.compose.material3.TextButton
import androidx.compose.runtime.Composable
import androidx.compose.runtime.LaunchedEffect
import androidx.compose.runtime.derivedStateOf
import androidx.compose.runtime.getValue
import androidx.compose.runtime.mutableStateListOf
import androidx.compose.runtime.mutableStateOf
import androidx.compose.runtime.remember
import androidx.compose.runtime.rememberCoroutineScope
import androidx.compose.runtime.setValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.res.painterResource
import androidx.compose.ui.unit.dp
import androidx.navigation.NavHostController
import kotlinx.coroutines.launch

@Composable
fun HomeScreen(modifier: Modifier, controller: NavHostController) {
    var user by remember { mutableStateOf<User?>(null) }
    var categoryOpened by remember { mutableStateOf(false) }
    var loading by remember { mutableStateOf(false) }
    var weight by remember { mutableStateOf("1") }
    var msg by remember { mutableStateOf("") }
    val categories = remember { mutableStateListOf<Category>() }
    var selectedCategory by remember { mutableStateOf<Category?>(null) }
    val totalPrice by remember {
        derivedStateOf {
            (selectedCategory?.pricePerKg ?: 0.0) * (weight.toDoubleOrNull() ?: 0.0)
        }
    }
    val scope = rememberCoroutineScope()

    LaunchedEffect(Unit) {
        if (user == null) {
            user = HttpClient.me()
            if (categories.addAll(HttpClient.getCategories())) {
                selectedCategory = categories[0]
            }
        }
    }
    if (user == null || selectedCategory == null) return
    Column(modifier) {
        Alert(msg.isNotEmpty(), {msg = ""}, msg)
        Row(
            Modifier
                .fillMaxWidth()
                .padding(12.dp),
            horizontalArrangement = Arrangement.SpaceBetween
        ) {
            Column {
                Text("Halo, ${user!!.fullName}")
                Text("Saldo: Rp" + "%.2f".format(user!!.balance))
            }
            Button(onClick = {
                HttpClient.accessToken = ""
                controller.navigate(Route.LOGIN)
            }, shape = RoundedCornerShape(8.dp)) {
                Text("Log out")
            }
        }
        Column(Modifier
            .weight(1f)
            .padding(32.dp), verticalArrangement = Arrangement.Center) {
            Text("Kategori Sampah")
            Box(Modifier.fillMaxWidth()) {
                TextButton(
                    onClick = { categoryOpened = !categoryOpened },
                    border = BorderStroke(
                        1.dp,
                        MaterialTheme.colorScheme.primary
                    ),
                    shape = RoundedCornerShape(8.dp)
                ) {
                    Text(selectedCategory!!.name)
                    Spacer(Modifier.width(8.dp))
                    Icon(painterResource(R.drawable.arr_dropdown), contentDescription = "Dropdown")
                }
                DropdownMenu(categoryOpened, onDismissRequest = { categoryOpened = false }) {
                    categories.forEach { item ->
                        DropdownMenuItem(
                            text = { Text(item.name) },
                            onClick = {
                                selectedCategory = item
                                categoryOpened = false
                            })
                    }
                }
            }
            Text("Price per KG: Rp" + "%.2f".format(selectedCategory!!.pricePerKg))
            Spacer(Modifier.height(8.dp))
            OutlinedTextField(
                value = weight,
                onValueChange = { weight = it },
                modifier = Modifier.fillMaxWidth(),
                label = { Text("Weight") }
            )
            Spacer(Modifier.height(24.dp))
            Text("Total: Rp" + "%.2f".format(totalPrice))
            Spacer(Modifier.height(12.dp))
            Button(onClick = {
                if ((weight.toDoubleOrNull() ?: 0.0) < 0.001) {
                    return@Button
                }
                scope.launch {
                    loading = true
                    if (HttpClient.sellTrash(weight.toDouble(), selectedCategory!!.id)) {
                        user = HttpClient.me()
                        weight = "1"
                        msg = "Berhasil"
                    } else {
                        weight = "1"
                        msg = "Transaksi Gagal."
                    }
                    loading = false
                }
            }, modifier = Modifier.fillMaxWidth()) {
                if (loading) {
                    CircularProgressIndicator(Modifier.size(24.dp))
                    return@Button
                }
                Text("Jual")
            }
        }
    }
}