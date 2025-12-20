package tests.day9

import Helpers.runTest
import days.day9.Day9_1.parse
import days.day9.Day9_1.puzzle
import java.io.File

object Day9_1 {
    val input =
        parse("7,1\n" +
                "11,1\n" +
                "11,7\n" +
                "9,7\n" +
                "9,5\n" +
                "2,5\n" +
                "2,3\n" +
                "7,3")

    fun testSimple() {
        val suspectedResult = 50L

        runTest("Day9_1 simple", { puzzle(input) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 4767418746L
        val inputString = File("input9.txt").readText()

        val inputs = parse(inputString)

        runTest("Day9_1 complex", { puzzle(inputs) }, suspectedResult)
    }
}