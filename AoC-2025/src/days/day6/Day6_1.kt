package days.day6

import Helpers.pair
import Helpers.transposed

object Day6_1 {

    fun parse(input:String) : List<Pair<Char, List<Long>>> {
        try {
            val lines =
                input
                .replace("\r", "")
                .split('\n')
                .filter { it.isNotEmpty() }

            val numbers = lines
                .take(lines.size - 1)
                .map { line -> line
                    .split(' ')
                    .filter { v -> v.isNotEmpty() }
                    .map { str -> str.toLong() }}
            val numbersSeq = numbers.transposed()

            val operators = lines
                .last()
                .split(' ')
                .filter { v -> v.isNotEmpty() }
                .map { str -> str.first() }

            return pair(operators, numbersSeq)
        } catch (e: Exception) {
            println(e)
            return emptyList()
        }
    }

    fun calculate(operator:Char, numbers:List<Long>) : Long {
        return when (operator) {
            '*' -> numbers.reduce { a, b -> a * b }
            '+' -> numbers.sum()
            else -> throw IllegalArgumentException("Unknown operator")
        }
    }

    fun puzzle(list:List<Pair<Char, List<Long>>>) : Long {
        val results = list.map { (operator, numbers) -> calculate(operator, numbers) }
        val result = results.sum()

        return result
    }
}