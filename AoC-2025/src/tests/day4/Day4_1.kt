package tests.day4

import Helpers.runTest
import days.day4.Day4_1.parse
import days.day4.Day4_1.puzzle
import java.io.File

object Day4_1 {
    val input =
        parse("..@@.@@@@.\n" +
                "@@@.@.@.@@\n" +
                "@@@@@.@.@@\n" +
                "@.@@@@..@.\n" +
                "@@.@@@@.@@\n" +
                ".@@@@@@@.@\n" +
                ".@.@.@.@@@\n" +
                "@.@@@.@@@@\n" +
                ".@@@@@@@@.\n" +
                "@.@.@@@.@.")

    fun testSimple() {
        val suspectedResult = 13

        runTest("Day4_1 simple", { puzzle(input) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 1389
        val inputString = File("input4.txt").readText()

        val inputs = parse(inputString)

        runTest("Day4_1 complex", { puzzle(inputs) }, suspectedResult)
    }
}