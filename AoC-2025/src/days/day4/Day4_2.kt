package days.day4

import days.day4.Day4_1.getPaperNeighbours
import days.day4.Day4_1.updateElement
import days.day4.Day4_1.updateNeighbours

object Day4_2 {

    tailrec fun removeNeighbours(paperNeighbours:List<List<Int>>, toRemove:List<Pair<Int, Int>>) : List<List<Int>> {
        if (toRemove.isEmpty()) return paperNeighbours

        val (index1, index2) = toRemove.first()
        val newPaperNeighbours =
            paperNeighbours.updateNeighbours(index1, index2) { e:Int -> e.dec() }

        return removeNeighbours(newPaperNeighbours, toRemove.drop(1))
    }

    tailrec fun removePaper(paperNeighbours:List<List<Int>>, toRemove:List<Pair<Int, Int>>) : List<List<Int>> {
        if (toRemove.isEmpty()) return paperNeighbours

        val (index1, index2) = toRemove.first()
        val newPaperNeighbours =
            paperNeighbours.updateElement(index1, index2) { _:Int -> 0 }

        return removePaper(newPaperNeighbours, toRemove.drop(1))
    }

    tailrec fun removePaper(paperNeighbours:List<List<Int>>, removedPaper:Int) : Int {
        val paperAccesable = paperNeighbours
            .map { l -> l
                .map{ v -> if (v in 1..<5) true else false } }

        val indices = paperAccesable
            .mapIndexed { i1, l -> l.mapIndexed { i2, v -> Triple(v, i1, i2)} }
            .flatten()
            .filter { (v, _, _) -> v }
            .map { (_, i1, i2) -> Pair(i1, i2) }

        if (indices.isEmpty())
            return removedPaper

        val newPaperNeighbours1 = removeNeighbours(paperNeighbours, indices)
        val newPaperNeighbours2 = removePaper(newPaperNeighbours1, indices)

        return removePaper(newPaperNeighbours2, removedPaper + indices.size)
    }

    fun puzzle(input:List<List<Boolean>>) : Int {
        val paperNeighbours = getPaperNeighbours(input)
        val removedPaper = removePaper(paperNeighbours, 0)

        return removedPaper
    }
}