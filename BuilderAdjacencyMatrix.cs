using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsometryTwo
{
    internal class BuilderAdjacencyMatrix
    {
        //Метод для получения матрицу путей для карты. Метод BFS
        static public int[,] BuildAdjacencyMatrix(Map map)
        {
            int sizeMap = map.sizeMap;

            int[,] matrix = new int[sizeMap * sizeMap, sizeMap * sizeMap];

            for (int col = 0; col < sizeMap; col++)
            {
                for (int row = 0; row < sizeMap; row++)
                {
                    int i = row * sizeMap + col; // Индекс текущей клетки в матрице

                    if (row - 1 >= 0)
                    {
                        if (map.GetCell(row - 1, col).typeObject > 6 || map.GetCell(row - 1, col).typeObject == 0)
                        { 
                             matrix[i, (row - 1) * sizeMap + col] = 1; // верхняя клетка
                        }
                    }
                    if (row + 1 < sizeMap)
                    {
                        CellMap cell = map.GetCell(row + 1, col);

                        if (cell.typeObject > 6 || cell.typeObject == 0)
                        {
                            matrix[i, (row + 1) * sizeMap + col] = 1; // нижняя клетка
                        }
                    }
                    if (col - 1 >= 0)
                    {
                        CellMap cell = map.GetCell(row, col - 1);

                        if (cell.typeObject > 6 || cell.typeObject == 0)
                        {
                            matrix[i, row * sizeMap + col - 1] = 1; // левая клетка
                        }
                    }
                    if (col + 1 < sizeMap)
                    {
                        CellMap cell = map.GetCell(row, col + 1);

                        if (cell.typeObject > 6 || cell.typeObject == 0)
                        {
                            matrix[i, row * sizeMap + col + 1] = 1; // правая клетка
                        }
                    }
                }
            }

            return matrix;
        }
    }
}
