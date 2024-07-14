namespace Application;

public class Solution
{
    public bool Exist(char[][] board, string word)
    {
        for (var row = 0; row < board.Length; row++)
        {
            var currentRow = board[row];

            for (var col = 0; col < currentRow.Length; col++)
                if (board[row][col] == word[0])
                    if (Dfs(board, row, col, word, 0))
                        return true;
        }

        return false;
    }

    private bool Dfs(char[][] board, int row, int col, string word, int index)
    {
        var maxRowSize = board.Length;
        var maxColSize = board[0].Length;

        if (board.Length == 0) return false;

        if (row < 0 || row >= maxRowSize || col < 0 || col >= maxColSize || word[index] != board[row][col])
            return false;

        if (index == word.Length - 1) return true;

        var directionsToMoveNext = new[]
        {
            //top
            new[] { row - 1, col },
            //down
            new[] { row + 1, col },
            //left
            new[] { row, col - 1 },
            //right
            new[] { row, col + 1 }
        };

        board[row][col] = '#';

        foreach (var direction in directionsToMoveNext)
        {
            var newRow = direction[0];
            var newCol = direction[1];

            var result = Dfs(board, newRow, newCol, word, index + 1);
            if (result) return result;
        }

        board[row][col] = word[index];

        return false;
    }
}