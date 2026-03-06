package nr.dev.ecotrack

import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.withContext
import org.json.JSONObject
import java.net.HttpURLConnection
import java.net.URL
import java.time.LocalDateTime
import java.time.OffsetDateTime

data class HttpReq(
    val url: String,
    val method: String = "GET",
    val body: String = "",
    val headers: Map<String, String> = emptyMap(),
    val timeout: Int = 10000
)

data class HttpRes(
    val code: Int,
    val body: String? = null,
    val headers: Map<String, List<String>> = emptyMap(),
    val errors: String? = null
)



object HttpClient {
    val address = "http://10.0.2.2:5000/api/"
    var accessToken = ""

    fun send(req: HttpReq): HttpRes {
        val conn = URL(req.url).openConnection() as HttpURLConnection
        return try {
            conn.requestMethod = req.method
            conn.readTimeout = req.timeout
            conn.connectTimeout = req.timeout
            req.headers.forEach { (t, u) -> conn.setRequestProperty(t, u) }
            if (req.body.isNotBlank() && req.method in listOf("POST", "PUT", "PATCH")) {
                conn.doOutput = true
                conn.getOutputStream().buffered().use { it.write(req.body.toByteArray()) }
            }
            conn.connect()
            val code = conn.responseCode
            val body = if (code in 200..299) {
                conn.getInputStream().bufferedReader().use { it.readText() }
            } else {
                conn.errorStream?.bufferedReader()?.use { it.readText() }
            }
            HttpRes(
                code = code,
                body = body,
                headers = conn.headerFields
            )
        } catch (e: Exception) {
            HttpRes(
                code = -1,
                errors = e.message ?: "Network Error"
            )
        } finally {
            conn.disconnect()
        }
    }

    suspend fun jsonReq(url: String, body: String = "", method: String = "POST"): HttpRes {
        val headers = mapOf("content-type" to "application/json")
        return withContext(Dispatchers.IO) {
            send(
                HttpReq(
                    url,
                    method,
                    body,
                    headers = if (accessToken.isNotEmpty()) headers + mapOf("authorization" to "Bearer $accessToken") else headers
                )
            )
        }
    }

    suspend fun login(username: String, password: String): Boolean {
        val body = """{"username": "$username", "password": "$password"}"""
        val res = jsonReq(address + "auth/login", body)
        if(res.code == 200 && res.body != null) {
            val obj = JSONObject(res.body)
            accessToken = obj.getJSONObject("data").getString("token")
            return true
        }
        return false
    }

    suspend fun register(username: String, fullName: String, phoneNum: String, password: String): String {
        val body = """{"username": "$username", "fullName": "$fullName", "phone": "$phoneNum", "password": "$password"}"""
        val res = jsonReq(address + "auth/register", body)
        println(res)
        if(res.code == 200) return "ok"
        if(!res.body.isNullOrEmpty()) {
            val obj = JSONObject(res.body)
            if(obj.has("message")) return obj.getString("message")
            return "Register Failed"
        }
        return "Register Failed"
    }

    suspend fun me(): User? {
        val res = jsonReq(address + "auth/me", method = "GET")
        if(res.code == 200 && res.body != null) {
            val obj = JSONObject(res.body).getJSONObject("data")
            return User(
                id = obj.getInt("id"),
                fullName = obj.getString("fullName"),
                balance = obj.getDouble("balance"),
            )
        }
        return null
    }

    suspend fun getCategories(): List<Category> {
        val res = jsonReq(address + "categories", method = "GET")
        if(res.code != 200 || res.body == null) return emptyList()
        val arr = JSONObject(res.body).getJSONArray("data")
        val categories = mutableListOf<Category>()
        for(i in 0 until arr.length()) {
            val obj = arr.getJSONObject(i)
            categories.add(Category(
                id = obj.getInt("id"),
                name = obj.getString("name"),
                pricePerKg = obj.getDouble("pricePerKg"),
            ))
        }
        return categories
    }

    suspend fun sellTrash(weight: Double, categoryId: Int): Boolean {
        val body = """{"weight": $weight, "categoryId": $categoryId}"""
        val res = jsonReq(address + "transactions", body)
        return res.code == 200
    }

    suspend fun getTransactions(): List<Transaction2> {
        val res = jsonReq(address + "transactions", method = "GET")
        if(res.code != 200 || res.body == null) return emptyList()
        val arr = JSONObject(res.body).getJSONArray("data")
        val transactions = mutableListOf<Transaction2>()
        for(i in 0 until arr.length()) {
            val obj = arr.getJSONObject(i)
            transactions.add(Transaction2(
                id = obj.getInt("id"),
                categoryId = obj.getInt("categoryId"),
                categoryName = obj.getString("categoryName"),
                weight = obj.getDouble("weight"),
                totalPrice = obj.getDouble("totalPrice"),
                createdAt = LocalDateTime.parse(obj.getString("createdAt"))
            ))
        }
        return transactions
    }
}