package days.day5

object Day5_1 {

    data class Range (val from:Long, val to:Long)

    fun parse(input:String) : Pair<List<Range>, List<Long>> {
        try {
            val lines =
                input
                .replace("\r", "")
                .split('\n')
                .map { s -> s.split('-') }

            val ranges = lines.filter { l -> l.size == 2 }.map  { l -> Range(l[0].toLong(), l[1].toLong()) }
            val values = lines.filter { l -> l.size == 1 && l[0].isNotEmpty() }.map  { l -> l.first().toLong() }

            return Pair(ranges, values)
        } catch (e: Exception) {
            println(e)
            return Pair(emptyList(), emptyList())
        }
    }

    fun isFresh (freshIds:List<Range>, id:Long) : Boolean {
        return freshIds.any { freshRange -> id in freshRange.from ..freshRange.to }
    }

    fun areFresh (freshIds:List<Range>, ids:List<Long>) : List<Long> {
        return ids.filter { id -> isFresh(freshIds, id) }
    }

    fun puzzle(freshRanges:List<Range>, ingredients:List<Long>) : Int {
        val freshIngredients = areFresh(freshRanges, ingredients)

        return freshIngredients.size
    }
}