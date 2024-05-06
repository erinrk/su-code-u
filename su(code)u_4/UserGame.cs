using static su_code_u_4.UserInput;

//this will be going in the report

namespace su_code_u_4
{
    public partial class UserGame : Form
    {
        public UserGame()
        {
            InitializeComponent();

            GetRunSettings();

            buttonsGrid = new Button[9, 9];
            numberSelectionButtons = new Button[10];
            solvedBoard = new(initialGrid);
        }

        private void GetRunSettings()
        {
            // get current settings of how the game should start
            // will be either normal game started, playing the entered sudoku from userInput()

            string runSettings = "run settings.txt";
            string[] lines = File.ReadAllLines(runSettings);

            // indicates whether isHelp was on or off
            isHelp = Convert.ToBoolean(lines[0]);

            if (Convert.ToBoolean(lines[1]) == true)
            {
                // random sudoku fetched
                initialGrid = GetSudoku(-1);
            }
            else
            {
                // specified sudoku fetched
                initialGrid = GetSudoku(Convert.ToInt32(lines[2]));
            }

            // resetting the file for next game loaded to start normally
            File.WriteAllText(runSettings, "true\ntrue");
        }

        private int[,] GetSudoku(int newSID)
        {
            // takes the ID of the sudoku to be fetched

            // read all sudokus from the storage sudokus 
            string sudokuStorage = "unsolved.txt";
            string[] sudokus = File.ReadAllLines(sudokuStorage);
            int numberOfSudokus = sudokus.Length;
            Random random = new();

            int[,] newGrid = new int[9, 9];

            if (newSID == -1)
            {
                // indicates that the sudoku returned should be random
                sudokuID = random.Next(numberOfSudokus);
            }
            else
            {
                // indicates the sudoku ID has been given
                sudokuID = newSID;
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    newGrid[i, j] = Convert.ToInt16(Convert.ToString(sudokus[sudokuID][(9 * i) + j]));
                }
            }

            return newGrid;
        }

        //variables for the grids
        const int squareSize = 85;
        readonly Button[] numberSelectionButtons;
        readonly Button[,] buttonsGrid;
        int[,] initialGrid = { { 1, 0, 2, 8, 4, 9, 0, 0, 0 }, { 8, 3, 0, 5, 7, 0, 6, 0, 0 }, { 5, 0, 0, 0, 0, 6, 0, 0, 0 }, { 2, 0, 0, 9, 6, 1, 7, 5, 0 }, { 0, 0, 0, 0, 5, 7, 0, 1, 8 }, { 0, 0, 0, 0, 0, 0, 0, 9, 0 }, { 4, 1, 0, 0, 0, 3, 0, 6, 2 }, { 0, 6, 3, 2, 9, 4, 1, 8, 5 }, { 0, 0, 0, 0, 0, 5, 3, 7, 0 } };
        Board solvedBoard;
        int sudokuID;

        // colours for the grid
        readonly Color userEnteredColor = Color.Blue;
        readonly Color highlightForPeers = Color.DarkGray;
        readonly Color highlightForNumbers = Color.Gray;
        
        UserInput userInputForm;

        Button buttonSelected = new();
        bool isHelp = true;

        // indicates how many values will be taken out (81 - value below)
        int difficulty; //1: >50, 2: 49>>36, 3: 35>>32, 4: 31>>28; 5: 27>>17 ///// 0: 50>>41, 1: 40>>31, 2: 30>>18

        int row;
        int column;

        private void UserGame_Load(object sender, EventArgs e)
        {
            MakeButtons();
            solvedBoard.BacktrackingForSolution();
        }

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
                        Size = new Size(squareSize, squareSize),
                        Location = new Point(squareSize * j + addingJ * 10, squareSize * i + addingI * 10),
                        Font = new Font("Segoe UI", 13)
                    };
                    
                    // setting up each button
                    buttonsGrid[i, j].Click += new EventHandler(ButtonGrid_Click);
                    Controls.Add(buttonsGrid[i, j]);
                    buttonsGrid[i, j].Text = Convert.ToString(initialGrid[i, j]);
                    
                    if (buttonsGrid[i, j].Text == "0")
                    {
                        buttonsGrid[i, j].ForeColor = highlightForPeers;
                    }
                }
            }

            // makes the buttons for entering numbers
            for (int i = 0; i < 10; i++)
            {
                numberSelectionButtons[i] = new Button()
                {
                    Size = new Size(100, 50),
                    Location = new Point(834, 80 + (55 * i))
                };
                
                // setting up each button
                numberSelectionButtons[i].Click += new EventHandler(NumberSelection_Click);
                Controls.Add(numberSelectionButtons[i]);
                
                if (i == 0)
                {
                    numberSelectionButtons[i].Text = "empty";
                }
                else
                {
                    numberSelectionButtons[i].Text = Convert.ToString(i);
                }
            }

        }

        private void FormatButtonGrid()
        {
            // usually called after click events have happened
            // only does writing colour, highlighting is handled by click events

            int countFilled = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (buttonsGrid[i, j].Text == "0")
                    {
                        // formatting empty cells
                        buttonsGrid[i, j].ForeColor = buttonsGrid[i, j].BackColor;
                    }
                    else if (buttonsGrid[i, j].Text == Convert.ToString(initialGrid[i, j]))
                    {
                        // formatting given cells
                        buttonsGrid[i, j].ForeColor = Color.Black;
                        countFilled++;
                    }
                    else if (buttonsGrid[i, j].Text == Convert.ToString(solvedBoard.sudokuGrid[i, j].value) || !isHelp)
                    {
                        // formatting correctly entered cells
                        buttonsGrid[i,j].ForeColor = userEnteredColor;
                        countFilled++;
                    }
                    else
                    {
                        // formatting incorrectly entered cells
                        buttonsGrid[i, j].ForeColor = Color.Red;
                    }
                }
            }

            if (countFilled == 81)
            {
                completedSudoku.Visible = true;
            }
            else
            {
                completedSudoku.Visible = false;
            }
        }

        private void ButtonGrid_Click(object sender, EventArgs e)
        {
            buttonSelected = (Button)sender;
            row = (buttonSelected.Bounds.Y) / squareSize;
            column = (buttonSelected.Bounds.X) / squareSize;

            // highlighting cells (with isHelp enabled)
            if (isHelp)
            {
                buttonSelected.BackColor = highlightForNumbers;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        if (buttonsGrid[i, j].Text == buttonSelected.Text && buttonSelected.Text != "0")
                        {
                            // formatting buttons with same value as selected cell
                            buttonsGrid[i, j].BackColor = highlightForNumbers;
                        }
                        else if (solvedBoard.sudokuGrid[i, j].col == column || solvedBoard.sudokuGrid[i, j].row == row || Board.GetBox(row, column) == Board.GetBox(i, j))
                        {
                            // formatting buttons that are peers of selected cell
                            buttonsGrid[i, j].BackColor = highlightForPeers;
                        }
                        else
                        {
                            // formatting all other buttons to default
                            buttonsGrid[i, j].BackColor = Color.FromArgb(255, 240, 240, 240);
                        }
                    }
                }
            }

            FormatButtonGrid();
        }

        private void NumberSelection_Click(object sender, EventArgs e)
        {
            // checking the cell is not a given value
            if (buttonSelected.ForeColor != Color.Black)
            {
                Button selectedButton = (Button)sender;

                buttonSelected.ForeColor = userEnteredColor;
                
                // changing the text of the grid button last selected
                if (selectedButton.Text == "empty")
                {
                    buttonSelected.Text = "0";
                }
                else
                {
                    buttonSelected.Text = selectedButton.Text; 
                    if (isHelp && !(buttonSelected.Text == Convert.ToString(solvedBoard.sudokuGrid[row, column].value)))
                    {
                        buttonSelected.ForeColor = Color.Red;
                    }
                }
            }

            // updating formatting
            ButtonGrid_Click(buttonSelected, e);
            buttonSelected.Focus();
        }

        private void HelpRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isHelp = true;
            GetValueButton.Visible = true;

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    buttonsGrid[i, j].BackColor = Color.FromArgb(255, 240, 240, 240);
                    if (buttonsGrid[i, j].Text != Convert.ToString(solvedBoard.sudokuGrid[i,j].value) && buttonsGrid[i,j].Text != "0")
                    {
                        buttonsGrid[i, j].ForeColor = Color.Red;
                    }
                }
            }

            FormatButtonGrid();
        }

        private void NoHelpRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            isHelp = false;
            GetValueButton.Visible = false;
            
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    buttonsGrid[i, j].BackColor = Color.FromArgb(255, 240, 240, 240);
                }
            }

            FormatButtonGrid();
        }

        private void GetValueButton_Click(object sender, EventArgs e)
        {
            if (buttonSelected.ForeColor != Color.Black)
            {
                buttonSelected.Text = Convert.ToString(solvedBoard.sudokuGrid[row, column].value);
                buttonSelected.ForeColor = userEnteredColor;
                ButtonGrid_Click(buttonSelected, e);
                buttonSelected.Focus();
            }
        }

        private void SolveGameMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    buttonsGrid[i, j].Text = Convert.ToString(solvedBoard.sudokuGrid[i, j].value);
                }
            }

            FormatButtonGrid();
        }

        private void ResetGameMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    buttonsGrid[i, j].Text = Convert.ToString(initialGrid[i, j]);
                }
            }

            FormatButtonGrid();
        }

        private void InputSudokuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Application.OpenForms.OfType<UserInput>().Any())
            {
                userInputForm = new UserInput();
                userInputForm.Show();
            }
            else
            {
                userInputForm.Focus();
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            string currentSave = "current save.txt";
            string userChangedGrid = "";

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (buttonsGrid[i, j].ForeColor != Color.Black)
                    {
                        userChangedGrid += buttonsGrid[i, j].Text;
                    }
                    else
                    {
                        userChangedGrid += "0";
                    }
                }
            }

            // saves: whether isHelp is enabled, the sudoku ID of the current sudoku, and filled parts of the grid
            File.WriteAllText(currentSave, (Convert.ToString(isHelp) + "\n" + Convert.ToString(sudokuID)+ "\n" + userChangedGrid));
        }

        private void OpenLastSavedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string userChangedGrid = "current save.txt";
            string[] lines = File.ReadAllLines(userChangedGrid);

            // gets whether isHelp was enabled
            isHelp = Convert.ToBoolean(lines[0]);
            helpRadioButton.Checked = isHelp;
            noHelpRadioButton.Checked = !isHelp;

            // gets the inital grid of the sudoku from the sudoku ID given
            initialGrid = GetSudoku(Convert.ToInt32(lines[1]));
            solvedBoard = new(initialGrid);
            solvedBoard.BacktrackingForSolution();

            // filling in values from user edited grid and inital grid
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // formatting for cells writing colour
                    if (initialGrid[i, j] == 0)
                    {
                        buttonsGrid[i, j].ForeColor = userEnteredColor;
                    }
                    else
                    {
                        buttonsGrid[i, j].ForeColor = Color.Black;
                    }

                    if (Convert.ToString(lines[2][(i * 9) + j]) == "0")
                    {
                        // formatting cells not edited by user
                        buttonsGrid[i, j].Text = Convert.ToString(initialGrid[i, j]);
                    }
                    else
                    {
                        // formatting cells edited by user
                        buttonsGrid[i, j].Text = Convert.ToString(lines[2][(i * 9) + j]);
                        if (buttonsGrid[i, j].Text != Convert.ToString(solvedBoard.sudokuGrid[i, j].value))
                        {
                            buttonsGrid[i, j].ForeColor = Color.Red;
                        }
                    }
                }
            }

            FormatButtonGrid();
        }

        private void RandomSudokuFromFileMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void PlayWithNewBoard()
        {
            // generate new int grid
            int[,] newGrid = new int[9, 9];
            newGrid = GenerateGrid(newGrid);
            
            // counting current number of grids in order to get new sudoku ID
            string sudokuStorage = "unsolved.txt";
            string[] sudokus = File.ReadAllLines(sudokuStorage);
            int numberOfSudokus = sudokus.Length;

            // updating file so it will run with specified sudoku when restarted
            File.WriteAllText("run settings.txt", "true\n" + "false\n" + Convert.ToString(numberOfSudokus));

            // saving new sudoku into sudoku storage
            string saveToFile = "";
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    saveToFile += newGrid[i, j];
                }
            }

            File.AppendAllText(sudokuStorage, "\n" + saveToFile);

            Application.Restart();
        }

        private int[,] GenerateGrid(int[,] checkingGrid)
        {
            int cellsToDig = difficulty;
            int cellsDug = 0;

            // making completed board
            Board boardToDig = new(checkingGrid);
            boardToDig.BacktrackingForCreation();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    checkingGrid[i, j] = boardToDig.sudokuGrid[i, j].value;
                }
            }

            // making randomised list for order to try and take cells out in
            List<int> orderToDig = new();
            for (int i = 0; i < 81; i++)
            {
                orderToDig.Add(i);
            }
            boardToDig.Shuffle(orderToDig);

            // digging through list until cells dug out meets aim, or until no more digging can be done
            for (int i = 0; i < 81; i++)
            {
                int row = orderToDig[i] / 9;
                int col = orderToDig[i] % 9;

                checkingGrid[row, col] = 0;
                if (CheckUniqueness(checkingGrid) == true)
                {
                    boardToDig.sudokuGrid[row, col].value = 0;
                    cellsDug++;
                }
                else
                {
                    checkingGrid[row, col] = boardToDig.sudokuGrid[row, col].value;
                }

                if (cellsToDig == cellsDug)
                {
                    i = 81;
                }
            }

            return checkingGrid;
        }

        private void EasyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random random = new();
            difficulty =  81 - random.Next(41, 55);

            PlayWithNewBoard();
        }

        private void MediumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random random = new();
            difficulty = 81 - random.Next(31, 41);

            PlayWithNewBoard();
        }

        private void HardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random random = new();
            difficulty = 81 - random.Next(25, 31);

            PlayWithNewBoard();
        }
    }
}
