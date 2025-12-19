package days.day6

import Helpers.transposed

object Day6_2 {

    tailrec fun filterCalculation(lines:List<String>, numbers:List<Long>, result:List<Pair<Char, List<Long>>>) : List<Pair<Char, List<Long>>> {
        if (lines.isEmpty())
            return result
        val head = lines.first()
        val tail = lines.drop(1)

        val operator = head.last()
        val possibleOperators = "+*"

        if (possibleOperators.contains(operator)) {
            val number = head.take(head.length - 1).toLong()
            return filterCalculation(tail, emptyList(), result + Pair(operator, numbers + number))
        }

        val number = head.toLong()
        return filterCalculation(tail, numbers+number, result)
    }

    fun parse(input:String) : List<Pair<Char, List<Long>>> {
        try {
            val lines =
                input
                .replace("\r", "")
                .split('\n')
                .filter { it != "" }

            val linesTransposed = lines
                .map { line -> line
                    .toList()
                    .reversed()}
                .transposed()
                .map { line -> line.filter { !it.isWhitespace() } .joinToString("")}
                .filter { line -> line.isNotEmpty() }

            val numbersWithOperators = filterCalculation(linesTransposed, emptyList(), emptyList())

            return numbersWithOperators
        } catch (e: Exception) {
            println(e)
            return emptyList()
        }
    }

}