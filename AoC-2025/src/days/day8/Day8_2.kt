package days.day8

import days.day8.Day8_1.Point
import days.day8.Day8_1.PointsWithDistance
import days.day8.Day8_1.combinePoints
import days.day8.Day8_1.distanceTo
import Helpers.permutations

object Day8_2 {

    tailrec fun combinePoints(points:List<Pair<Point,Point>>, circuitCounter:Int, pointsWithCircuits:Map<Point, Int>)
    : Pair<Map<Point, Int>, Pair<Point, Point>> {

        if (points.isEmpty()) {
            val origin = Point(0, 0, 0)
            return Pair(pointsWithCircuits, Pair(origin, origin))
        }

        val head = points.first()
        val tail = points.drop(1)

        val (newCircuitCounter, newPointsWithCircuits) = combinePoints(head, circuitCounter, pointsWithCircuits)

        val circuits = newPointsWithCircuits
            .map { it.value }
            .distinct()

        if (circuits.size == 1)
            return Pair(pointsWithCircuits, head)

        return combinePoints(tail, newCircuitCounter, newPointsWithCircuits)
    }

    fun puzzle(points:List<Point>) : Int {
        val pointsWithoutCircuits = points.associateWith { _ -> 0 }

        val permutations = points.permutations()
        val pointsWithDistance = permutations.map { (point1, point2) -> PointsWithDistance(Pair(point1, point2), point1.distanceTo(point2)) }
        val pointsWithDistanceSorted = pointsWithDistance.sortedBy { (_, distance) -> distance }
        val pointsSorted = pointsWithDistanceSorted.map { it.points }

        val (_, points) = combinePoints(pointsSorted, 0, pointsWithoutCircuits)

        return points.first.x * points.second.x
    }
}