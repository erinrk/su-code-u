using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.Design;
using System.Globalization;

namespace su_code_u_4
{
    public partial class UserInput : Form
    {
        public UserInput()
        {
            InitializeComponent();
        }

        private void UserInput_Load(object sender, EventArgs e)
        {
            MakeButtons();
            EnsureValidity();
        }

        private void EnsureValidity()
        {
            ShowSolution.Visible = false;
            PlayInputtedSudoku.Visible = false;
            SaveSudoku.Visible = false;
        }

        readonly Button[,] buttonsGrid = new Button[9, 9];
        readonly Button[] numberSelectionButtons = new Button[10];
        readonly int[,] inputtedGrid = new int[9, 9];
        Board solvedBoard;

        string currentNumberSelected = "1";

        private void MakeButtons()
        {
            // makes the sudoku grid buttons
            // spreads the buttons out into the sudoku grid
            int addingI = 0;
            for (int i = 0; i < 9; i++)
            {
                if (i % 3 == 0)
                {
                    addingI = i / 3;
                }
                int addingJ = 0;
                for (int j = 0; j < 9; j++)
                {
                    if (j % 3 == 0)
                    {
                        addingJ = j / 3;
                    }
                    buttonsGrid[i, j] = new Button()
                    {
                        Size = new Size(85, 85),
                        Location = new Point(85 * j + addingJ * 10, 85 * i + addingI * 10),
                        Font = new Font("Segoe UI", 11)
                    };

                    // setting up each button
                    buttonsGrid[i, j].Click += new EventHandler(ButtonGrid_Click);
                    Controls.Add(buttonsGrid[i, j]);
                }
            }

            // makes the buttons for entering numbers
            for (int i = 0; i < 10; i++)
            {
                numberSelectionButtons[i] = new Button()
                {
                    Size = new Size(100, 50),
                    Location = new Point(834, 180 + (50 * i))
                };

                //setting up each button
                numberSelectionButtons[i].Click += new EventHandler(NumberSelection_Click);
                Controls.Add(numberSelectionButtons[i]);

                if (i == 0)
                {
                    numberSelectionButtons[i].Text = Convert.ToString("empty");
                }
                else
                {
                    numberSelectionButtons[i].Text = Convert.ToString(i);
                }
            }
            numberSelectionButtons[0].Focus();
        }

        private void NumberSelection_Click(object sender, EventArgs e)
        {
            ShowSolution.Visible = false;
            PlayInputtedSudoku.Visible = false;

            Button selectedButton = (Button)sender;
            if (selectedButton.Text != "empty")
            {
                currentNumberSelected = selectedButton.Text;
            }
            else
            {
                currentNumberSelected = "";
            }

            EnsureValidity();
        }

        private void ButtonGrid_Click(object sender, EventArgs e)
        {
            Button selectedButton = (Button)sender;
            selectedButton.Text = currentNumberSelected;

            ShowSolution.Visible = false;
            PlayInputtedSudoku.Visible = false;

            EnsureValidity();
        }

        private void CheckValidity_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (buttonsGrid[i, j].Text == "")
                    {
                        inputtedGrid[i, j] = 0;
                    }
                    else
                    {
                        inputtedGrid[i, j] = Convert.ToInt32(buttonsGrid[i, j].Text);
                    }
                }
            }

            //checking whether board entered is a valid sudoku
            solvedBoard = new(inputtedGrid);
            solvedBoard.BacktrackingForSolution();

            if (CheckPuzzleFollowsRules(inputtedGrid) && CheckUniqueness(inputtedGrid))
            {
                // actions on the board become available if sudoku is valid
                ShowSolution.Visible = true;
                PlayInputtedSudoku.Visible = true;
                SaveSudoku.Visible = true;
            }
        }

        private void PlayInputtedSudoku_Click(object sender, EventArgs e)
        {
            string sudokuStorage = "unsolved.txt";
            string[] sudokus = File.ReadAllLines(sudokuStorage);
            int numberOfSudokus = sudokus.Length;

            // updating file so it will run with new specified sudoku when restarted
            File.WriteAllText("run settings.txt", "true\n" + "false\n" + Convert.ToString(numberOfSudokus));

            SaveSudoku_Click(sender, e);

            Application.Restart();
        }

        private void ShowSolution_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (buttonsGrid[i, j].Text == "")
                    {
                        buttonsGrid[i, j].ForeColor = Color.Blue;
                    }
                    buttonsGrid[i, j].Text = Convert.ToString(solvedBoard.sudokuGrid[i, j].value);
                }
            }
        }

        private void SaveSudoku_Click(object sender, EventArgs e)
        {
            string sudokuStorage = "unsolved.txt";
            string saveToFile = "";

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (buttonsGrid[i, j].ForeColor == Color.Blue)
                    {
                        saveToFile += "0";
                    }
                    else
                    {
                        saveToFile += buttonsGrid[i, j].Text;
                    }
                }
            }

            File.AppendAllText(sudokuStorage, "\n" + saveToFile);
        }

        public static bool CheckUniqueness(int[,] gridToCheck)
        {
            Board temporaryBoard = new(gridToCheck);
            temporaryBoard.BacktrackingForSolution();
            
            // holding the completed board in an int grid
            int[,] solvedGrid = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    solvedGrid[i, j] = temporaryBoard.sudokuGrid[i, j].value;
                }
            }

            // comparing solution found from each empty cell to original 
            for (int i = 0; i < temporaryBoard.notFilledCells.Count - 1; i++)
            {
                temporaryBoard = new Board(gridToCheck);

                // changing order cells will be filled in
                temporaryBoard.notFilledCells.AddRange(temporaryBoard.notFilledCells.GetRange(0, i + 1));
                temporaryBoard.notFilledCells.RemoveRange(0, i + 1);

                temporaryBoard.BacktrackingForSolution();

                // comparing grids, if any values don't match then the board is invalid
                for (int j = 0; j < 9; j++)
                {
                    for (int k = 0; k < 9; k++)
                    {
                        if (!(temporaryBoard.sudokuGrid[j, k].value == solvedGrid[j, k]))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private static bool CheckPuzzleFollowsRules(int[,] gridToCheck)
        {
            // fills in cells to empty board and checks if placement is valid

            int[,] gridForEmptyBoard = new int[9, 9];
            Board testingBoard = new(gridForEmptyBoard);

            Board boardToCheck = new(gridToCheck);

            for (int i = 0; i < 81; i++)
            {
                if (boardToCheck.sudokuGrid[i / 9, i % 9].value != 0)
                { 
                    Cell testingCell = new(boardToCheck.sudokuGrid[i / 9, i % 9].value, i / 9, i % 9, Board.GetBox(i / 9, i % 9));
                
                    if (testingBoard.Valid(testingCell))
                    {
                        testingBoard.sudokuGrid[i / 9, i % 9].value = testingCell.value;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
