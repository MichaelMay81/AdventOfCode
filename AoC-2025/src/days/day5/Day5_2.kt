package days.day5

import days.day5.Day5_1.Range

object Day5_2 {

    fun combine(range1:Range, range2:Range) : List<Range> {
        if (range1.to + 1 >= range2.from) {
            val rangeTo = if (range1.to > range2.to) range1.to else range2.to
            return listOf(Range(range1.from, rangeTo))
        }
        return listOf(range1, range2)
    }

    tailrec fun combine(ranges:List<Range>, current:Range, result:List<Range>) : List<Range> {
        if (ranges.isEmpty())
            return result + current
        val head = ranges.first()
        val tail = ranges.drop(1)

        val newRanges = combine(current, head)
        if (newRanges.size == 1)
            return combine(tail, newRanges.first(), result)
        return combine(tail, newRanges[1], result + newRanges[0])
    }

    fun combine(ranges:List<Range>) : List<Range> {
        val sorted = ranges.sortedWith(compareBy({ it.from }, { it.to })) //{ range -> range.from }
        val combined = combine(sorted.drop(1), sorted.first(), emptyList())

        return combined
    }

    fun puzzle(ranges:List<Range>) : Long {
        val combinedRanges = combine(ranges)
        val counts = combinedRanges.map { range -> range.to - range.from + 1 }
        val count = counts.sum()

        return count
    }
}