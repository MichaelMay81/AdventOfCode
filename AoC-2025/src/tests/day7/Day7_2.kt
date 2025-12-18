package tests.day7

import Helpers.runTest
import tests.day7.Day7_1.input
import days.day7.Day7_1.parse
import days.day7.Day7_2.puzzle
import java.io.File

object Day7_2 {
    fun testSimple() {
        val suspectedResult = 40L

        runTest("Day7_2 simple", { puzzle(input) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 422102272495018L
        val inputString = File("input7.txt").readText()

        val inputs = parse(inputString)

        runTest("Day7_2 complex", { puzzle(inputs) }, suspectedResult)
    }
}