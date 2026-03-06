package nr.dev.ecotrack


object Route {
    const val LOGIN = "login"
    const val REGISTER = "register"
    const val HOME = "home"
}

data class User(
    val id: Int,
    val fullName: String,
    val balance: Double
)

data class Category(
    val id: Int,
    val name: String,
    val pricePerKg: Double
)

data class Transaction(
    val weight: Double,
    val categoryId: Int
)