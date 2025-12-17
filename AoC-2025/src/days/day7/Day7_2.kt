package days.day7

import days.day4.Day4_1.updateElement

object Day7_2 {

    tailrec fun analyseSpaces(line:String, currentId:Int, tachyons:List<Long>, newTachyons:List<Long>) : List<Long> {
        if (line.isEmpty()) return newTachyons

        val head = line.first()

        if (head == 'S')
            return newTachyons.updateElement(currentId, { _ -> 1})

        val tail = line.drop(1)
        val tachyon = tachyons[currentId]

        if (tachyon <= 0)
            return analyseSpaces(tail, currentId + 1, tachyons, newTachyons)

        val ts =
            if (head == '^')
                newTachyons
                    .updateElement(currentId - 1) { t -> t + tachyon }
                    .updateElement(currentId + 1) { t -> t + tachyon }
            else
                newTachyons.updateElement(currentId) { t -> t + tachyon }

        return analyseSpaces(tail, currentId + 1, tachyons, ts)
    }

    tailrec fun analyseLines(lines:List<String>, tachyons:List<Long>) : List<Long> {
        if (lines.isEmpty()) return tachyons

        val head = lines.first()
        val tail = lines.drop(1)

        val newTachyons = analyseSpaces(head, 0, tachyons, List(tachyons.size) { 0 })
        return analyseLines(tail, newTachyons)
    }

    fun puzzle(lines:List<String>) : Long {
        val result = analyseLines(lines, List(lines.first().length) { 0 })

        return result.sum()
    }
}