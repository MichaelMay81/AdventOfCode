package days.day7

import Helpers.pair
import Helpers.transposed

object Day7_1 {

    fun parse(input:String) : List<String> {
        try {
            val lines =
                input
                .replace("\r", "")
                .split('\n');

            return lines
        } catch (e: Exception) {
            println(e)
            return emptyList()
        }
    }

    tailrec fun analyseSpaces(line:String, currentId:Int, tachyonIds:Set<Int>, newtachyonIds:Set<Int>, splitCount:Int) : Pair<Set<Int>,Int> {
        if (line.isEmpty()) return Pair(newtachyonIds, splitCount)

        val head = line.first()
        val tail = line.drop(1)
        val newId = currentId + 1

        if (head == 'S')
            return Pair(setOf(currentId), 0)

        if (!tachyonIds.contains(currentId))
            return analyseSpaces(tail, newId, tachyonIds, newtachyonIds, splitCount)

        if (head == '^')
            return analyseSpaces(tail, newId, tachyonIds, newtachyonIds + (currentId-1) + (currentId+1), splitCount+1)
        else
            return analyseSpaces(tail, newId, tachyonIds, newtachyonIds + currentId, splitCount)
    }

    tailrec fun analyseLines(lines:List<String>, tachyonIds:Set<Int>, result:Int) : Int {
        if (lines.isEmpty()) return result

        val head = lines.first()
        val tail = lines.drop(1)

        val (newtachyonIds, splitCount) = analyseSpaces(head, 0, tachyonIds, emptySet(), 0)
        val newResult = result + splitCount

        return analyseLines(tail, newtachyonIds, newResult)
    }

    fun puzzle(lines:List<String>) : Int {
        val result = analyseLines(lines, emptySet(), 0)

        return result
    }
}