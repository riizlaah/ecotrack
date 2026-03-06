package nr.dev.ecotrack

import java.time.LocalDateTime
import java.time.OffsetDateTime


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

data class Transaction2(
    val id: Int,
    val weight: Double,
    val categoryId: Int,
    val categoryName: String,
    val totalPrice: Double,
    val createdAt: LocalDateTime
)