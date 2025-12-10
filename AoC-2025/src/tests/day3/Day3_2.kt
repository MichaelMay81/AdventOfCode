package tests.day3

import Helpers.runTest
import days.day3.Day3_2.puzzle
import days.day3.Day3_1.parse
import tests.day3.Day3_1.input
import java.io.File

object Day3_2 {
    fun testSimple1() {
        val suspectedResult = 357L

        runTest("Day3_2 simple1", { puzzle(input, 2) }, suspectedResult)
    }

    fun testSimple2() {
        val suspectedResult = 3121910778619L

        runTest("Day3_2 simple2", { puzzle(input, 12) }, suspectedResult)
    }

    fun testComplex1() {
        val suspectedResult = 17166L
        val inputString = File("input3.txt").readText()

        val inputs = parse(inputString)

        runTest("Day3_2 complex1", { puzzle(inputs, 2) }, suspectedResult)
    }

    fun testComplex2() {
        val suspectedResult = 169077317650774L
        val inputString = File("input3.txt").readText()

        val inputs = parse(inputString)

        runTest("Day3_2 complex2", { puzzle(inputs, 12) }, suspectedResult)
    }
}