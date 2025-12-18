package days.day8

import kotlin.math.sqrt

object Day8_1 {

    data class Point(val x: Int, val y: Int, val z: Int)

    data class PointsWithDistance(val points:Pair<Point, Point>, val distance:Double)

    fun Point.distanceSquaredTo(point:Point) : Long {
        val x = (this.x - point.x).toLong()
        val y = (this.y - point.y).toLong()
        val z = (this.z - point.z).toLong()

        return x * x + y * y + z * z
    }

    fun Point.distanceTo(point:Point) : Double {
        val distanceSquared = this.distanceSquaredTo(point)
        return sqrt(distanceSquared.toDouble())
    }

    fun <T>List<T>.permutations() : List<Pair<T, T>> {
        tailrec fun permutate(list:List<T>, result:List<Pair<T,T>>):List<Pair<T,T>> {
            if (list.isEmpty())
                return result

            val head = list.first()
            val tail = list.drop(1)
            val newPermutations = tail.map { Pair(head, it) }

            return permutate(tail, result + newPermutations)
        }

        return permutate(this, emptyList())
    }

    fun parse(input:String) : List<Point> {
        try {
            val lines =
                input
                .replace("\r", "")
                .split('\n')

            val points = lines
                .map { line -> line.split(',').map(String::toInt) }
                .map { Point(it[0], it[1], it[2]) }

            return points
        } catch (e: Exception) {
            println(e)
            return emptyList()
        }
    }

    fun combinePoints(points:Pair<Point, Point>, circuitCounter:Int, pointsWithCircuits:Map<Point, Int>) : Pair<Int,Map<Point, Int>> {
        val circuit1 = pointsWithCircuits[points.first] as Int
        val circuit2 = pointsWithCircuits[points.second] as Int

        if (circuit1 == 0 && circuit2 == 0) {
            val nextCircuit = circuitCounter + 1
            return Pair(
                nextCircuit,
                pointsWithCircuits + (points.first to nextCircuit) + (points.second to nextCircuit)
            )
        }

        val newPointsWithCircuits =
            if (circuit2 == 0)
                pointsWithCircuits + (points.second to circuit1)
            else if (circuit1 == 0)
                pointsWithCircuits + (points.first to circuit2)
            else if (circuit1 == circuit2)
                pointsWithCircuits
            else
                pointsWithCircuits
                .map { (point, circuit) -> if (circuit == circuit2) Pair(point, circuit1) else Pair(point, circuit) }
                .toMap()

        return Pair(circuitCounter, newPointsWithCircuits)
    }

    tailrec fun combinePoints(points:List<Pair<Point,Point>>, circuitCounter:Int, pointsWithCircuits:Map<Point, Int>, maxCircuitCounter: Int) : Map<Point, Int> {
        if (points.isEmpty())
            return pointsWithCircuits
        if (maxCircuitCounter == 0)
            return pointsWithCircuits

        val head = points.first()
        val tail = points.drop(1)

        val (newCircuitCounter, newPointsWithCircuits) = combinePoints(head, circuitCounter, pointsWithCircuits)

        return combinePoints(tail, newCircuitCounter, newPointsWithCircuits, maxCircuitCounter - 1)
    }

    fun puzzle(points:List<Point>, maxConnections:Int) : Int {
        val pointsWithoutCircuits = points.associateWith { _ -> 0 }

        val permutations = points.permutations()
        val pointsWithDistance = permutations.map { (point1, point2) -> PointsWithDistance(Pair(point1, point2), point1.distanceTo(point2)) }
        val pointsWithDistanceSorted = pointsWithDistance.sortedBy { (_, distance) -> distance }
        val pointsSorted = pointsWithDistanceSorted.map { it.points }

        val pointsWithCircuits = combinePoints(pointsSorted, 0, pointsWithoutCircuits, maxConnections)
        val circuitGroups = pointsWithCircuits
            .toList()
            .filter { it.second != 0 }
            .groupBy { (_, circuit) -> circuit }
        val circuitGroupsSorted = circuitGroups
            .map { (circuit, points) -> Pair(circuit, points.size) }
            .sortedByDescending { (_, size) -> size }
            .take(3)

        val result = circuitGroupsSorted
            .map { it.second }
            .reduce(Int::times)

        return result
    }
}