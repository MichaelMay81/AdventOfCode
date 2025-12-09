package days.day1

import days.day1.Day1_1.checkNumber
import kotlin.math.abs

object Day1_2 {
    data class Data(val value:Int, val zeroCount:Int)

    fun countZeroes(oldValue:Int, newValue:Int):Int {
        val rotations = abs(newValue) / 100
        val dippedToOrBelowZero = if (oldValue != 0 && newValue <= 0) 1 else 0

        return rotations + dippedToOrBelowZero
    }

    fun puzzle(initialNumber:Int, input:List<Int>) : Int {
        val addValue = {
                result:Data, steps:Int ->
            val newValueFull = result.value + steps
            val newValue = checkNumber(newValueFull)

            val newZeroCount = result.zeroCount + countZeroes(result.value, newValueFull)

            Data(value=newValue, zeroCount=newZeroCount) }

        val result = input.fold(Data(initialNumber, 0), addValue)

        return result.zeroCount
    }
}