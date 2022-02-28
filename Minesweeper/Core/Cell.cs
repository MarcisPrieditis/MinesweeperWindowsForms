using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper.Core
{

    public class Cell : Button
    {
        public int NumMines { get; set; }
        public Board Board { get; set; }
        public static int openedCellCount;
        public CellProperties CellProp;

        public void SetupDesign()
        {
            // this.BackColor = SystemColors.ButtonFace;
            this.Location = new Point(CellProp.XLoc * CellProp.CellSize, CellProp.YLoc * CellProp.CellSize);
            this.Size = new Size(CellProp.CellSize, CellProp.CellSize);
            this.UseVisualStyleBackColor = false;
            this.Font = new Font("Verdana", 15.75F, FontStyle.Bold);
        }

        public string OnFlag()
        {
            if (CellProp.CellType == CellType.Flagged)
            {
                CellProp.CellType = CellType.Regular;
                Text = "";
            }
            else if (CellProp.CellType == CellType.FlaggedMine)
            {
                CellProp.CellType = CellType.Mine;
                Text = "";
            }
            else if (CellProp.CellType == CellType.Mine)
            {
                CellProp.CellType = CellType.FlaggedMine;
                Text = "🚩";
            }
            else
            {
                CellProp.CellType = CellType.Flagged;
                Text = "🚩";
            }

            return Text;
        }

        public void OnClick()
        {
            var cell = this;
            openedCellCount++;

            if (openedCellCount == 1)
            {
                PutMineInBoard();
            }

            CellProp.CellState = CellState.Opened;
            BackColor = Color.LightGray;

            if (cell.CellProp.CellType != CellType.Mine)
            {
                Text = CountBombs().ToString() == "0" ? "" : CountBombs().ToString();
                ForeColor = GetCellColour();
            }

            if (CountBombs() == 0)
                AutoOpenCells();

            if (cell.CellProp.CellState == CellState.Closed && cell.CellProp.CellType != CellType.Flagged)
                cell.OnClick();

            GameOverOrWinner();
        }

        public void GameOverOrWinner()
        {
            var cell = this;
            if (cell.CellProp.CellType == CellType.Mine)
            {
                var mines = Board.Cells;

                foreach (var mine in mines)
                {
                    if (mine.CellProp.CellType == CellType.Mine || mine.CellProp.CellType == CellType.FlaggedMine)
                    {
                        mine.Text = "";
                        mine.Image = Image.FromFile("../../bombpng.png");
                    }
                }
                cell.BackColor = Color.Red;
                MessageBox.Show("You Loose!!!");
            }
            else if (CheckWinner())
                MessageBox.Show("You Won!!!");
        }

        public int CountBombs()
        {
            NumMines = 0;

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (CellInBound(i, j))
                        continue;

                    var cell = Board.Cells[CellProp.XLoc + i, CellProp.YLoc + j];
                    if (cell.CellProp.CellType == CellType.Mine || cell.CellProp.CellType == CellType.FlaggedMine)
                        NumMines++;
                }
            }

            return NumMines;
        }

        public void AutoOpenCells()
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (CellInBound(i, j) || Board.Cells[CellProp.XLoc + i, CellProp.YLoc + j].CellProp.CellState == CellState.Opened)
                        continue;

                    var cell = Board.Cells[CellProp.XLoc + i, CellProp.YLoc + j];
                    if (cell.CellProp.CellType == CellType.FlaggedMine)
                        continue;

                    cell.CellProp.CellState = CellState.Opened;
                    cell.OnClick();
                }
            }
        }

        public bool CellInBound(int i, int j)
        {
            return CellProp.XLoc + i >= Board.Width || CellProp.YLoc + j >= Board.Height ||
                   CellProp.XLoc + i < 0 || CellProp.YLoc + j < 0;
        }

        public bool CheckWinner()
        {
            var cellCount = Board.Width * Board.Height;
            return cellCount - openedCellCount == Board.NumMines;
        }

        public void PutMineInBoard()
        {
            RandomMineGenerator.FinalMineLocations(Board.NumMines, Board.Height, Board.Width, CellProp.XLoc, CellProp.YLoc);

            foreach (var mine in RandomMineGenerator.BoardMines)
            {
                var cell = Board.Cells[mine.Item1, mine.Item2];
                cell.CellProp.CellType = CellType.Mine;
                // cell.Text = "M";
            }
        }

        private Color GetCellColour()
        {
            switch (this.NumMines)
            {
                case 1:
                    return ColorTranslator.FromHtml("0x0000FE"); // 1
                case 2:
                    return ColorTranslator.FromHtml("0x186900"); // 2
                case 3:
                    return ColorTranslator.FromHtml("0xAE0107"); // 3
                case 4:
                    return ColorTranslator.FromHtml("0x000177"); // 4
                case 5:
                    return ColorTranslator.FromHtml("0x8D0107"); // 5
                case 6:
                    return ColorTranslator.FromHtml("0x007A7C"); // 6
                case 7:
                    return ColorTranslator.FromHtml("0x902E90"); // 7
                case 8:
                    return ColorTranslator.FromHtml("0x000000"); // 8
                default:
                    return ColorTranslator.FromHtml("0xffffff");
            }
        }
    }
}