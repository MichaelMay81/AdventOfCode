package tests.day8

import Helpers.runTest
import days.day8.Day8_1.parse
import days.day8.Day8_1.puzzle
import java.io.File

object Day8_1 {
    val input =
        parse("162,817,812\n" +
                "57,618,57\n" +
                "906,360,560\n" +
                "592,479,940\n" +
                "352,342,300\n" +
                "466,668,158\n" +
                "542,29,236\n" +
                "431,825,988\n" +
                "739,650,466\n" +
                "52,470,668\n" +
                "216,146,977\n" +
                "819,987,18\n" +
                "117,168,530\n" +
                "805,96,715\n" +
                "346,949,466\n" +
                "970,615,88\n" +
                "941,993,340\n" +
                "862,61,35\n" +
                "984,92,344\n" +
                "425,690,689")

    fun testSimple() {
        val suspectedResult = 40

        runTest("Day8_1 simple", { puzzle(input, 10) }, suspectedResult)
    }

    fun testComplex() {
        val suspectedResult = 54180
        val inputString = File("input8.txt").readText()

        val inputs = parse(inputString)

        runTest("Day8_1 complex", { puzzle(inputs, 1000) }, suspectedResult)
    }
}