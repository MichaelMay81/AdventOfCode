package tests.day2

import Helpers.runTest
import days.day1.Day1_1.translate
import days.day2.Day2_1.puzzle
import days.day2.Day2_1.parse
import java.io.File

object Day2_1 {
    val input =
        parse("11-22,95-115,998-1012,1188511880-1188511890,222220-222224," +
                "1698522-1698528,446443-446449,38593856-38593862,565653-565659," +
                "824824821-824824827,2121212118-2121212124")

    fun testSimple() {
        val suspectedResult = 1227775554L

        runTest("Day2_1 simple", { puzzle(input) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 24157613387L
        val inputString = File("input2.txt").readText()

        val inputs = parse(inputString)

        runTest("Day2_1 complex", { puzzle(inputs) }, suspectedResult)
    }
}