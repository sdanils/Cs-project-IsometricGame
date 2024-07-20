using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    internal class FinderShortestPath
    {
        public static List<Point> FindShortestPath(Point start, Point end, int[,] adjacencyMatrix, int sizeMap)
        {
            Queue<Point> queue = new Queue<Point>();
            Dictionary<Point, Point> parent = new Dictionary<Point, Point>();

            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                Point current = queue.Dequeue();

                if (current == end)
                    break;

                // Перебор соседей текущей точки
                for (int neighborX = Math.Max(0, current.X - 1); neighborX <= Math.Min(sizeMap - 1, current.X + 1); neighborX++)
                {
                    for (int neighborY = Math.Max(0, current.Y - 1); neighborY <= Math.Min(sizeMap - 1, current.Y + 1); neighborY++)
                    {
                        Point neighbor = new Point(neighborX, neighborY);

                        if (adjacencyMatrix[current.X * sizeMap + current.Y, neighbor.X * sizeMap + neighbor.Y] == 1 && !parent.ContainsKey(neighbor))
                        {
                            queue.Enqueue(neighbor);
                            parent[neighbor] = current;
                        }
                    }
                }
            }

            // Восстанавление пути
            List<Point> path = new List<Point>();
            Point currentPoint = end;

            while (currentPoint != start)
            {
                path.Add(currentPoint);
                if (!parent.ContainsKey(currentPoint))
                {
                    return null;
                }
                currentPoint = parent[currentPoint];
            }

            path.Add(start);
            path.Reverse();

            return path;
        }

    }
}
