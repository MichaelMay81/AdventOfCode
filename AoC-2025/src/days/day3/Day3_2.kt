package days.day3

import kotlin.math.max

object Day3_2 {

    fun process(input:List<Int>, result:List<Int>, size:Int) : Long {
        if (input.isEmpty())
            return result.fold (0, { acc, value -> acc * 10 + value })

        val head = input.first()
        val tail = input.drop(1)

        if (result.isEmpty())
            return process(tail, listOf(head), size);

        val start = max(size - input.size, 0)
        val i = result.drop(start).indexOfFirst { value -> value < head }

        if (i != -1) {
            val newResult = result.take(start+i) + head
            return process(tail, newResult, size)
        } else if (result.size < size)
        {
            return process(tail, result + head, size)
        }

        return process(tail, result, size)
    }

    fun puzzle(input:List<List<Int>>, size:Int) : Long {
        val results = input.map { l -> process(l, emptyList(), size )}
        return results.sum()
    }
}