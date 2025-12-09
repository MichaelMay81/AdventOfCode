package days.day2

object Day2_1 {
    data class Id(val first:String, val second:String)

    fun parse (input: String): List<Id> {
        return input
            .split(",")
            .map({ tup -> tup.split("-", limit=2)})
            .map({ (first, second) -> Id(first, second) })
    }

    fun invalid(input:String) : Boolean {
        if (input[0] == '0')
            return true
        if (input.length % 2 != 0)
            return false
        val first = input.take(input.length/2)
        val second = input.substring(input.length/2)

        return first == second
    }

    fun idToStrings(input:Id) : List<String> {
        val first = input.first.toLong()
        val second = input.second.toLong()

        return (first .. second).map { v -> v.toString() }
    }

    fun puzzle(input:List<Id>) : Long {
        val strings = input.map(::idToStrings).flatten()
        val invalidIds = strings.filter(::invalid)

        return invalidIds.sumOf { v -> v.toLong() }
    }
}