import kotlin.time.Duration.Companion.nanoseconds
import kotlin.time.Duration.Companion.seconds

object Helpers {
    fun <T>runTest(testName:String, testSubject:() -> T, suspectedResult:T) {
        print("Running Test for $testName. ")
        val startTime = System.nanoTime()
        val result = testSubject()
        val duration = (System.nanoTime() - startTime).nanoseconds

        if (result == suspectedResult) {
            print("SUCCESS!")
        } else {
            print("FAILURE, should be: $suspectedResult!")
        }

        println(" Result: $result, Duration: $duration")
    }
}