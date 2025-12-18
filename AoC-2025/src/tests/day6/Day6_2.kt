package tests.day6

import Helpers.runTest
import days.day6.Day6_2.parse
import days.day6.Day6_1.puzzle
import java.io.File

object Day6_2 {
    val input =
        parse("123 328  51 64 \n" +
                " 45 64  387 23 \n" +
                "  6 98  215 314\n" +
                "*   +   *   +  ")

    fun testSimple() {
        val suspectedResult = 3263827L

        runTest("Day6_2 simple", { puzzle(input) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 11494432585168L
        val inputString = File("input6.txt").readText()

        val inputs = parse(inputString)

        runTest("Day6_2 complex", { puzzle(inputs) }, suspectedResult)
    }
}