using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace su_code_u_4
{
    internal class Board
    {   
        // the sudoku grid and the list of unfilled cells
        public readonly Cell[,] sudokuGrid = new Cell[9, 9];
        public readonly List<Cell> notFilledCells = new();

        public Board(int[,] unfilled)
        {
            // convert the int grid into the Cell grid
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    sudokuGrid[i, j] = new Cell(unfilled[i, j], i, j, GetBox(i, j));
                    
                    // adding the cell to the list of unfilled cells
                    if (sudokuGrid[i, j].value == 0)
                    {
                        notFilledCells.Add(sudokuGrid[i, j]);
                    }

                    // enables creation of completed random grids
                    Shuffle(sudokuGrid[i, j].possibleValues);
                    sudokuGrid[i, j].possibleValues.Insert(0, 0);
                    sudokuGrid[i, j].possibleValues.Add(10);
                }
            }
        }

        public bool BacktrackingForSolution()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            bool endReached = false;
            int count = 0;
            Cell testing;

            // runs until board verified to be unsolvable or is solved, or is already full
            while (!endReached && count != -1 && notFilledCells.Count != 0)
            {
                // sets up new variables for ease of use
                int value = notFilledCells[count].value;
                int row = notFilledCells[count].row;
                int col = notFilledCells[count].col;

                // increments value until cell placement into board is valid
                do
                {
                    value++;
                    testing = new Cell(value, row, col, notFilledCells[count].box);
                } while (!Valid(testing) && value < 10);
                sudokuGrid[row, col].value = value;

                // indicates earlier value placed into grid is incorrect
                if (sudokuGrid[row, col].value > 9)
                {
                    sudokuGrid[row, col].value = 0;
                    count--;
                }
                else
                {
                    count++;
                    if (count == notFilledCells.Count)
                    {
                        endReached = true;
                    }
                }
            }

            watch.Stop();

            if (count == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool BacktrackingForCreation()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            bool endReached = false;
            int count = 0;
            Cell testing;

            // runs until board verified to be unsolvable or is solved, or is already full
            while (!endReached && count != -1)
            {
                // sets up new variables for ease of use
                int row = notFilledCells[count].row;
                int col = notFilledCells[count].col;
                int value = notFilledCells[count].value;
                int indexOfValue = sudokuGrid[row, col].possibleValues.IndexOf(value);

                // increments value until cell placement into board is valid
                do
                {
                    indexOfValue++;
                    testing = new Cell(sudokuGrid[row, col].possibleValues[indexOfValue], row, col, notFilledCells[count].box);
                } while (!Valid(testing) && indexOfValue < 10);
                sudokuGrid[row, col].value = sudokuGrid[row, col].possibleValues[indexOfValue];

                // indicates earlier value placed into grid is incorrect
                if (indexOfValue > 9)
                {
                    sudokuGrid[row, col].value = sudokuGrid[row, col].possibleValues[0];
                    count--;
                }
                else
                {
                    value = sudokuGrid[row, col].possibleValues[indexOfValue];
                    count++;
                    if (count == notFilledCells.Count)
                    {
                        endReached = true;
                    }
                }
            }

            watch.Stop();

            if (count == -1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public void Shuffle(List<int> list)
        {
            int placeHolder = list.Count;
            Random random = new();
            while (placeHolder > 1)
            {
                placeHolder--;
                int temp = random.Next(placeHolder + 1);
                int value = list[temp];
                list[temp] = list[placeHolder];
                list[placeHolder] = value;
            }
        }

        public bool Valid(Cell testing)
        {
            // indicates whether cell placement into a board is valid

            for (int i = 0; i < 9; i++)
            {
                if (sudokuGrid[testing.row, i].value == testing.value)
                {
                    return false;
                }
                else if (sudokuGrid[i, testing.col].value == testing.value)
                {
                    return false;
                }
                for (int j = 0; j < 9; j++)
                {
                    if (testing.box == sudokuGrid[i, j].box && testing.value == sudokuGrid[i, j].value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static int GetBox(int i, int j)
        {
            //returns the box given a coordinate - only used when initialising box values for cells
            //O(1)
            int row = i;
            int col = j;
            if (row < 3)
            {
                if (col < 3)
                {
                    return 1;
                }
                else if (col > 5)
                {
                    return 3;
                }
                else
                {
                    return 2;
                }
            }
            else if (row > 5)
            {
                if (col < 3)
                {
                    return 7;
                }
                else if (col > 5)
                {
                    return 8;
                }
                else
                {
                    return 9;
                }
            }
            else
            {
                if (col < 3)
                {
                    return 4;
                }
                else if (col > 5)
                {
                    return 6;
                }
                else
                {
                    return 5;
                }
            }
        }
    }
}
