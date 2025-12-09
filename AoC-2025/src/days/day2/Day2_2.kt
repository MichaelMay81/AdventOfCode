package days.day2

import days.day2.Day2_1.idToStrings

object Day2_2 {

    fun <T>pair(lists:List<List<T>>) : List<List<T>> {
        if (lists.isEmpty()) return emptyList()

        val length = lists.first().size
        if (lists.any{ list -> list.size != length })
            return emptyList()

        return (0..<length)
            .map { i1 -> (0..<lists.size)
                .map { i2 -> lists[i2][i1] }}
    }

    fun invalid(input:String, splitInto:Int) : Boolean {
        if (input.length % splitInto == 0) {
            val chunkSize = input.length / splitInto
            val chunks = input.chunked(chunkSize).map{ s -> s.toList() }
            val pairs = pair(chunks)
            if (pairs.all { pair -> pair.distinct().size == 1 })
                return true
        }
        return false
    }
    fun invalid(input:String) : Boolean {
        for (splitInto in 2 .. input.length) {
            if (invalid(input, splitInto)) {
                return true
            }
        }
        return false
    }

    fun puzzle(input:List<Day2_1.Id>) : Long {
        val strings = input.map(::idToStrings).flatten()
        val invalidIds = strings.filter(::invalid)

        return invalidIds.sumOf { v -> v.toLong() }
    }
}