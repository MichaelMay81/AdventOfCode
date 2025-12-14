package tests.day5

import Helpers.runTest
import days.day5.Day5_1.parse
import days.day5.Day5_1.puzzle
import days.day5.Day5_2.combine
import java.io.File

object Day5_1 {
    val input =
        parse("3-5\n" +
                "10-14\n" +
                "16-20\n" +
                "12-18\n" +
                "\n" +
                "1\n" +
                "5\n" +
                "8\n" +
                "11\n" +
                "17\n" +
                "32")

    fun testSimple() {
        val suspectedResult = 3

        runTest("Day5_1 simple", { puzzle(input.first, input.second) }, suspectedResult)
    }

    fun testComplex1() {
        val suspectedResult = 840
        val inputString = File("input5.txt").readText()

        val inputs = parse(inputString)

        runTest("Day5_1 complex1", { puzzle(inputs.first, inputs.second) }, suspectedResult)
    }

    fun testComplex2() {
        val suspectedResult = 840
        val inputString = File("input5.txt").readText()

        val inputs = parse(inputString)
        val ranges = combine(inputs.first)
        val ingredients = inputs.second

        runTest("Day5_1 complex2", { puzzle(ranges, ingredients) }, suspectedResult)
    }
}