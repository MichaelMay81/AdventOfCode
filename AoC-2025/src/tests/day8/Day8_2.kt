package tests.day8

import Helpers.runTest
import days.day8.Day8_1.parse
import days.day8.Day8_2.puzzle
import java.io.File
import tests.day8.Day8_1.input

object Day8_2 {
    fun testSimple() {
        val suspectedResult = 25272

        runTest("Day8_2 simple", { puzzle(input) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 25325968
        val inputString = File("input8.txt").readText()

        val inputs = parse(inputString)

        runTest("Day8_2 complex", { puzzle(inputs) }, suspectedResult)
    }
}