package days.day3

object Day3_1 {

    fun parse(input:String) : List<List<Int>> {
        try {
            return input.replace("\r", "").split('\n').map { s -> s.map { c -> c.digitToInt() } }
        } catch (e: Exception) {
            println(e)
            return listOf()
        }
    }

    fun process(input:List<Int>, first:Int?, second:Int?) : Int {
        val head = input.first()
        val tail = input.drop(1)

        if (first == null)
            return process(tail, head, second);

        if (tail.isEmpty()) {
            if (second == null || head > second)
                return first * 10 + head
            else
                return first * 10 + second
        }

        if (head > first)
            return process(tail, head, null)

        if (second == null || head > second)
            return process(tail, first, head)

        return process(tail, first, second)
    }

    fun puzzle(input:List<List<Int>>) : Int {
        val results = input.map { l -> process(l, null, null )}
        return results.sum()
    }
}