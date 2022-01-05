class Lambda {
    fun method() {
        val l1 = { i: Int, s: String -> "$i, $s" }
        val l2 = { i: Int, s: String ->
            {
                val ii = i * 2
                val ss = s + "ABC"
                "$ii, $ss"
            }
        }
        func1({ i, s -> "$i, $s" })

        func1 { i, s -> "$i, $s" }

        func2(3) { i, s -> "$i, $s" }

        func3 { it.toString() }

        val result = arrayOf(1, 2, 3, 4, 5).filter { it % 2 == 0 }.map { it * it }

        lock {
            val i = 3
            val s = 4
            println("$i, $s")
        }

    }

    fun func1(logic: (i: Int, s: String) -> String) {

    }

    fun func2(number: Int, logic: (i: Int, s: String) -> String) {
    }

    fun func3(logic: (i: Int) -> String) {}


    fun lock(logic: () -> Unit) {

    }

}