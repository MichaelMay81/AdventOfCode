package tests.day7

import Helpers.runTest
import days.day7.Day7_1.parse
import days.day7.Day7_1.puzzle
import java.io.File

object Day7_1 {
    val input =
        parse(".......S.......\n" +
                "...............\n" +
                ".......^.......\n" +
                "...............\n" +
                "......^.^......\n" +
                "...............\n" +
                ".....^.^.^.....\n" +
                "...............\n" +
                "....^.^...^....\n" +
                "...............\n" +
                "...^.^...^.^...\n" +
                "...............\n" +
                "..^...^.....^..\n" +
                "...............\n" +
                ".^.^.^.^.^...^.\n" +
                "...............")

    fun testSimple() {
        val suspectedResult = 21

        runTest("Day7_1 simple", { puzzle(input) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 1681
        val inputString = File("input7.txt").readText()

        val inputs = parse(inputString)

        runTest("Day7_1 complex1", { puzzle(inputs) }, suspectedResult)
    }
}