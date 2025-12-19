package tests.day6

import Helpers.runTest
import days.day6.Day6_2.parse
import days.day6.Day6_1.puzzle
import tests.day6.Day6_1.inputString
import java.io.File

object Day6_2 {
    fun testSimple() {
        val suspectedResult = 3263827L

        val input = parse(inputString)
        runTest("Day6_2 simple", { puzzle(input) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 11494432585168L
        val inputString = File("input6.txt").readText()

        val inputs = parse(inputString)

        runTest("Day6_2 complex", { puzzle(inputs) }, suspectedResult)
    }
}