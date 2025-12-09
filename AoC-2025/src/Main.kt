import tests.day1.Day1_1
import tests.day1.Day1_2
import tests.day2.Day2_1
import tests.day2.Day2_2

fun runSimpleTests() {
    Day1_1.testSimple()
    Day1_2.testSimple()
    Day2_1.testSimple()
    Day2_2.testSimple()
}
fun runComplexTests() {
    Day1_1.testComplex()
    Day1_2.testComplex()
    Day2_1.testComplex()
    Day2_2.testComplex()
}

fun main() {
    runSimpleTests()
    runComplexTests()
}