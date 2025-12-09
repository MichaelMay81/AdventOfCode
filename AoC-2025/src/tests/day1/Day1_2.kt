package tests.day1

import Helpers.runTest
import days.day1.Day1_1.translate
import days.day1.Day1_2.puzzle
import tests.day1.Day1_1.inputString
import java.io.File

object Day1_2 {
    fun testSimple() {
        val suspectedResult = 6
        val inputs = inputString.map(::translate)

        runTest("Day1_2 simple", { puzzle(50, inputs) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 5978
        val inputString = File("input.txt").readLines()

        val inputs = inputString
            .map(::translate)

        runTest("Day1_1 complex", { puzzle(50, inputs) }, suspectedResult)
    }
}