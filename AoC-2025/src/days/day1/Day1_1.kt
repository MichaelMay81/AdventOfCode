package days.day1

object Day1_1 {
    fun translate(value:String) : Int
    {
        val number =
            value
                .substring(1)
                .toInt()
        return when (value[0]) {
            'L' -> -number
            'R' -> number
            else -> number
        }
    }

    fun checkNumber(value:Int):Int {
        val v = value % 100
        return if (v < 0) v + 100 else v
    }

    fun puzzle(initialNumber:Int, input:List<Int>) : Int {
        val addValue = {
                results:List<Int>, value:Int ->
            results + checkNumber(results.last() + value) }

        val results = input.fold(listOf(initialNumber), addValue)

        val isZero = { value:Int -> value == 0 }
        val result = results.count(isZero)

        return result
    }

}