using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    public class SnakeGame
    {
        private readonly int _minWidth;
        private readonly int _maxWidth;
        private readonly int _minHeight;
        private readonly int _maxHeight;
        private readonly int[][] _foods;
        private LinkedList<int[]> _snake;
        private int _score = 0;
        private HashSet<string> _snakeBody = new HashSet<string>();
        private int _currentFood = 0;
        public SnakeGame(int width, int height, int[][] food)
        {
            _minHeight = 0;
            _minWidth = 0;
            _maxWidth = width - 1;
            _maxHeight = height - 1;
            _foods = food;
            _snake = new LinkedList<int[]>(); //O(width * height) Space
            _snake.AddFirst(new int[] { 0, 0 });
            _snakeBody.Add(0 + "-" + 0); //O(width * height) Space
        }

        public int Move(string direction) //O(1)
        {
            var head = _snake.First; 
           var potentialDirection =  MoveInner(head.Value, direction);

           if (potentialDirection[0] > _maxHeight || potentialDirection[0] < _minHeight ||
               potentialDirection[1] > _maxWidth || potentialDirection[1] < _minWidth)
           {
               return -1;
           }

           bool shouldEatFood = false;

           if (_currentFood < _foods.Length)
           {
               var currentFoodLocation = _foods[_currentFood];
               if (currentFoodLocation[0] == potentialDirection[0] && currentFoodLocation[1] == potentialDirection[1])
               {
                    //eat the food
                    shouldEatFood = true;
                    _currentFood++;
                    _score++;
               }
           }

           if (!shouldEatFood)
           {
               var tail = _snake.Last;
               _snake.RemoveLast();
               _snakeBody.Remove(tail.Value[0] + "-" + tail.Value[1]);
           }

           if (_snakeBody.Contains(potentialDirection[0] + "-" + potentialDirection[1]))
           {
               return -1;
           }

            //remove the tail
           _snake.AddFirst(potentialDirection); //move the tail to the head
           _snakeBody.Add(potentialDirection[0] + "-" + potentialDirection[1]);

           return _score;
        }

        private int[] MoveInner(int[] location,string direction) //O(1)
        {
            switch (direction)
            {
                case "U":
                    return new int[] { location[0] - 1, location[1] };
                case "D":
                    return new int[] { location[0] + 1, location[1] };
                case "L":
                    return new int[] { location[0], location[1] - 1 };
                case "R":
                    return new int[] { location[0], location[1] + 1 };
                default:
                    throw new ArgumentException(nameof(direction));
            }
        }
    }
}
