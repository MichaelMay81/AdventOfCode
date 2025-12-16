import kotlin.math.min
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

    fun <T>List<List<T>>.transposed() : List<List<T>> {
        if (this.isEmpty()) return emptyList()

        val length = this.first().size
        if (this.any{ list -> list.size != length })
            return emptyList()

        return (0..<length)
            .map { i1 -> (0..<this.size)
                .map { i2 -> this[i2][i1] }}
    }

    fun <T,E>pair(list1:List<T>, list2:List<E>) : List<Pair<T, E>> {
        val length = min(list1.size, list2.size)

        return (0..<length)
            .map { i -> Pair(list1[i], list2[i]) }
    }
}