package tests.day3

import Helpers.runTest
import days.day3.Day3_1.puzzle
import days.day3.Day3_1.parse
import java.io.File

object Day3_1 {
    val input =
        parse("987654321111111\n" +
                "811111111111119\n" +
                "234234234234278\n" +
                "818181911112111")

    fun testSimple() {
        val suspectedResult = 357

        runTest("Day3_1 simple", { puzzle(input) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 17166
        val inputString = File("input3.txt").readText()

        val inputs = parse(inputString)

        runTest("Day3_1 complex", { puzzle(inputs) }, suspectedResult)
    }
}