import tests.day1.Day1_1
import tests.day1.Day1_2
import tests.day2.Day2_1
import tests.day2.Day2_2
import tests.day3.Day3_1
import tests.day3.Day3_2
import tests.day4.Day4_1
import tests.day4.Day4_2
import tests.day5.Day5_1
import tests.day5.Day5_2
import tests.day6.Day6_1
import tests.day6.Day6_2
import tests.day7.Day7_1
import tests.day7.Day7_2
import tests.day8.Day8_1
import tests.day8.Day8_2
import tests.day9.Day9_1
import kotlin.time.Duration.Companion.nanoseconds

fun runSimpleTests() {
    val startTime = System.nanoTime()
    Day1_1.testSimple()
    Day1_2.testSimple()
    Day2_1.testSimple()
    Day2_2.testSimple()
    Day3_1.testSimple()
    Day3_2.testSimple1()
    Day3_2.testSimple2()
    Day4_1.testSimple()
    Day4_2.testSimple()
    Day5_1.testSimple()
    Day5_2.testSimple()
    Day6_1.testSimple()
    Day6_2.testSimple()
    Day7_1.testSimple()
    Day7_2.testSimple()
    Day8_1.testSimple()
    Day8_2.testSimple()
    Day9_1.testSimple()
    val duration = (System.nanoTime() - startTime).nanoseconds
    println("Total duration: $duration")
}
fun runComplexTests() {
    val startTime = System.nanoTime()
    Day1_1.testComplex()
    Day1_2.testComplex()
    Day2_1.testComplex()
    Day2_2.testComplex()
    Day3_1.testComplex()
    Day3_2.testComplex1()
    Day3_2.testComplex2()
    Day4_1.testComplex()
    Day4_2.testComplex()
    Day5_1.testComplex1()
    Day5_1.testComplex2()
    Day5_2.testComplex()
    Day6_1.testComplex()
    Day6_2.testComplex()
    Day7_1.testComplex()
    Day7_2.testComplex()
    Day8_1.testComplex()
    Day8_2.testComplex()
    Day9_1.testComplex()
    val duration = (System.nanoTime() - startTime).nanoseconds
    println("Total duration: $duration")
}

fun main() {
    runSimpleTests()
    println()
    runComplexTests()
}