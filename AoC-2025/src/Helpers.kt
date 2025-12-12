import kotlin.time.Duration.Companion.nanoseconds

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

    fun <T>pair(lists:List<List<T>>) : List<List<T>> {
        if (lists.isEmpty()) return emptyList()

        val length = lists.first().size
        if (lists.any{ list -> list.size != length })
            return emptyList()

        return (0..<length)
            .map { i1 -> (0..<lists.size)
                .map { i2 -> lists[i2][i1] }}
    }
}