class Class4 {
    private val class2 = Class2(10, "ABC")

    val number: Int
        get() {
            return class2.number
        }

    val string: String
        get() {
            return class2.string
        }
}