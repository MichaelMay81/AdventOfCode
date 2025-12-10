package tests.day2

import Helpers.runTest
import days.day2.Day2_2.puzzle
import days.day2.Day2_1.parse
import tests.day2.Day2_1.input
import java.io.File

object Day2_2 {
    fun testSimple() {
        val suspectedResult = 4174379265L

        runTest("Day2_2 simple", { puzzle(input) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 33832678380L
        val inputString = File("input2.txt").readText()

        val inputs = parse(inputString)

        runTest("Day2_2 complex", { puzzle(inputs) }, suspectedResult)
    }
}