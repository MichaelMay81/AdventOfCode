package tests.day5

import Helpers.runTest
import days.day5.Day5_1.parse
import days.day5.Day5_2.puzzle
import tests.day5.Day5_1.input
import java.io.File

object Day5_2 {
    fun testSimple() {
        val suspectedResult = 14L

        runTest("Day5_2 simple", { puzzle(input.first) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 359913027576322L
        val inputString = File("input5.txt").readText()

        val inputs = parse(inputString)

        runTest("Day5_2 complex", { puzzle(inputs.first) }, suspectedResult)
    }
}