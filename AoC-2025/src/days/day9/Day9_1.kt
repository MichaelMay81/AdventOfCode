package days.day9

import Helpers.permutations
import kotlin.math.abs

object Day9_1 {

    data class Point(val x: Int, val y: Int)

    data class PointsWithSize(val points:Pair<Point, Point>, val size:Long)

    fun Point.size(point:Point) : Long {
        val x = abs(this.x - point.x).toLong() + 1
        val y = abs(this.y - point.y).toLong() + 1

        return x * y
    }

    fun parse(input:String) : List<Point> {
        try {
            val lines =
                input
                .replace("\r", "")
                .split('\n')

            val points = lines
                .map { line -> line.split(',').map(String::toInt) }
                .map { Point(it[0], it[1]) }

            return points
        } catch (e: Exception) {
            println(e)
            return emptyList()
        }
    }

    fun puzzle(points:List<Point>) : Long {
        val permutations = points.permutations()
        val pointsWithSizes = permutations.map { (point1, point2) -> PointsWithSize(Pair(point1, point2), point1.size(point2)) }
        val pointsWithDistanceSorted = pointsWithSizes.sortedByDescending { it.size }

        val result = pointsWithDistanceSorted.first().size
        return result
    }
}