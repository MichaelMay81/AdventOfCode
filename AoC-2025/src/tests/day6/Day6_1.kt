package tests.day6

import Helpers.runTest
import days.day6.Day6_1.parse
import days.day6.Day6_1.puzzle
import java.io.File

object Day6_1 {
    val input =
        parse("123 328  51 64 \n" +
                " 45 64  387 23 \n" +
                "  6 98  215 314\n" +
                "*   +   *   +  ")

    fun testSimple() {
        val suspectedResult = 4277556L

        runTest("Day6_1 simple", { puzzle(input) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 6378679666679L
        val inputString = File("input6.txt").readText()

        val inputs = parse(inputString)

        runTest("Day6_1 complex1", { puzzle(inputs) }, suspectedResult)
    }
}