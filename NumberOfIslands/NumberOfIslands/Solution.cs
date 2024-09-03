using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOfIslands
{
    public class Solution
    {
        public int NumIslands(char[][] grid)
        {
            var visited = new HashSet<string>();
            var numberOfIslands = 0;
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid[0].Length; col++)
                {
                    var currentCharacter = grid[row][col];

                    if (currentCharacter == '0' || visited.Contains(row + "-" + col))
                    {
                        continue;
                    }

                    Dfs(grid, row, col, visited);
                    numberOfIslands++;
                }
            }

            return numberOfIslands;
        }

        private void Dfs(char[][] grid, int row, int col, HashSet<string> visited)
        {
            visited.Add(row+"-"+col);

            var directions = new int[][]{
            new int[] { row - 1, col }, //top
            new int[] { row + 1, col }, //bottom
            new int[] { row, col + 1}, //right
            new int[] { row, col - 1} //left
          };

            for (int i = 0; i < directions.Length; i++)
            {
                var nextDirection = directions[i];
                var nextDirectionAsString = nextDirection[0] + "-" + nextDirection[1];
                var nextRow = nextDirection[0];
                var nextCol = nextDirection[1];

                if (nextDirection[0] < 0 || nextDirection[0] >= grid.Length)
                {
                    continue;
                }

                if (nextDirection[1] < 0 || nextDirection[1] >= grid[0].Length)
                {
                    continue;
                }

                if (visited.Contains(nextDirectionAsString))
                {
                    continue;
                }

                if (grid[nextRow][nextCol] == '0')
                {
                    continue;
                }

                Dfs(grid, nextDirection[0], nextDirection[1], visited);
            }
        }
    }

}
