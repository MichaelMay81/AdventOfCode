import tests.day1.Day1_1
import tests.day1.Day1_2
import tests.day2.Day2_1
import tests.day2.Day2_2
import tests.day3.Day3_1
import tests.day3.Day3_2

fun runSimpleTests() {
    Day1_1.testSimple()
    Day1_2.testSimple()
    Day2_1.testSimple()
    Day2_2.testSimple()
    Day3_1.testSimple()
    Day3_2.testSimple1()
    Day3_2.testSimple2()
}
fun runComplexTests() {
    Day1_1.testComplex()
    Day1_2.testComplex()
    Day2_1.testComplex()
    Day2_2.testComplex()
    Day3_1.testComplex()
    Day3_2.testComplex1()
    Day3_2.testComplex2()
}

fun main() {
    runSimpleTests()
    runComplexTests()
}