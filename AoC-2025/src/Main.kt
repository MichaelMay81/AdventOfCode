import tests.day1.Day1_1
import tests.day1.Day1_2
import tests.day2.Day2_1
import tests.day2.Day2_2
import tests.day3.Day3_1

fun runSimpleTests() {
    Day1_1.testSimple()
    Day1_2.testSimple()
    Day2_1.testSimple()
    Day2_2.testSimple()
    Day3_1.testSimple()
}
fun runComplexTests() {
    Day1_1.testComplex()
    Day1_2.testComplex()
    Day2_1.testComplex()
    Day2_2.testComplex()
    Day3_1.testComplex()
}

fun main() {
    runSimpleTests()
    runComplexTests()
}