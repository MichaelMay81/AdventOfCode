package tests.day4

import Helpers.runTest
import days.day4.Day4_1.parse
import days.day4.Day4_2.puzzle
import tests.day4.Day4_1.input
import java.io.File

object Day4_2 {
    fun testSimple() {
        val suspectedResult = 43

        runTest("Day4_2 simple", { puzzle(input) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 9000
        val inputString = File("input4.txt").readText()

        val inputs = parse(inputString)

        runTest("Day4_2 complex", { puzzle(inputs) }, suspectedResult)
    }
}