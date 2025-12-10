package tests.day1

import Helpers.runTest
import days.day1.Day1_1.translate
import days.day1.Day1_1.puzzle
import java.io.File

object Day1_1 {

    val inputString =
        ("L68\n" +
                "L30\n" +
                "R48\n" +
                "L5\n" +
                "R60\n" +
                "L55\n" +
                "L1\n" +
                "L99\n" +
                "R14\n" +
                "L82").split("\n")

    fun testSimple() {
        val suspectedResult = 3
        val inputs = inputString.map(::translate)

        runTest("Day1_1 simple", { puzzle(50, inputs) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 997
        val inputString = File("input.txt").readLines()

        val inputs = inputString
            .map(::translate)

        runTest("Day1_1 complex", { puzzle(50, inputs) }, suspectedResult)
    }
}