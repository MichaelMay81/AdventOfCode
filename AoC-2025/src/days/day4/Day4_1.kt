package days.day4

import Helpers.transposed

object Day4_1 {

    fun parse(input:String) : List<List<Boolean>> {
        try {
            return input
                .replace("\r", "")
                .split('\n')
                .map { s -> s.map { c -> c == '@'} }
        } catch (e: Exception) {
            println(e)
            return listOf()
        }
    }

    fun <T>List<T>.updateElement(index:Int, f: (T) -> T) : List<T> {
        if (index !in 0..<size)
            return this

        val oldValue = this[index]
        val newValue = f(oldValue)

        return slice(0 until index) +
                newValue +
                slice(index+1 until size)
    }

    fun <T>List<List<T>>.updateElement(index1:Int, index2:Int, f: (T) -> T) : List<List<T>> {
        return updateElement(index1) { l -> l.updateElement(index2, f) }
    }

    fun <T>List<List<T>>.updateNeighbours(index1:Int, index2:Int, f: (T) -> T) : List<List<T>> {
        return this
            .updateElement(index1-1, index2-1, f)
            .updateElement(index1-1, index2, f)
            .updateElement(index1-1, index2+1, f)
            .updateElement(index1, index2-1, f)
            .updateElement(index1, index2+1, f)
            .updateElement(index1+1, index2-1, f)
            .updateElement(index1+1, index2, f)
            .updateElement(index1+1, index2+1, f)
    }

    tailrec fun countNeighbours(input:List<List<Boolean>>, index1:Int, index2:Int, result:List<List<Int>>) : List<List<Int>> {
        if (index1 >= input.size)
            return result

        val currentList = input[index1]
        if (index2 >= currentList.size)
            return countNeighbours(input, index1+1, index2=0, result)

        val newResult =
            if (currentList[index2])
                result.updateNeighbours(index1, index2) { e:Int -> e.inc() }
            else result
        return countNeighbours(input, index1, index2+1, result=newResult)
    }

    fun getPaperNeighbours(input:List<List<Boolean>>) : List<List<Int>> {
        val size1 = input.size
        val size2 = input[0].size

        val initCounter = List(size1) { _ -> List(size2) { _ -> 0 }}
        val neighbours = countNeighbours(input, 0, 0, initCounter)

        val inputInt = input.map { l -> l.map { b -> if (b) 1 else 0 }}

        val paperNeighbours =
            listOf(inputInt, neighbours)
                .transposed()
                .map { lists -> lists
                    .transposed()
                    .map { ints -> ints
                        .reduce { a, b -> a * b + a } } }

        return paperNeighbours
    }

    fun puzzle(input:List<List<Boolean>>) : Int {

        val paperNeighbours = getPaperNeighbours(input)

        val paperAccesable = paperNeighbours
            .map { l -> l
                .map{ v -> if (v in 1..<5) 1 else 0 } }

        return paperAccesable.flatten().sum()
    }
}