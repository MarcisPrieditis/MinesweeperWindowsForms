using System.Windows.Forms;

namespace Minesweeper.Core
{
    public class Board
    {
        public Minesweeper Minesweeper { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int NumMines { get; set; }
        public Cell[,] Cells { get; set; }

        public Board(int width, int height, int mines)
        {
            this.Width = width;
            this.Height = height;
            this.NumMines = mines;
            this.Cells = new Cell[width, height];
        }

        public Board(Minesweeper minesweeper, int width, int height, int mines)
            : this(width, height, mines)
        {
            this.Minesweeper = minesweeper;
            this.Cells = new Cell[width, height];
        }

        public void SetupBoard()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    var c = new Cell()
                    {
                        CellProp = new CellProperties(i, j, 50, CellState.Closed, CellType.Regular),
                        Board = this
                    };

                    c.SetupDesign();
                    c.MouseDown += Cell_MouseClick;
                    this.Cells[i, j] = c;
                    this.Minesweeper.Controls.Add(c);
                }
            }
        }

        private void Cell_MouseClick(object sender, MouseEventArgs e)
        {
            var cell = (Cell)sender;

            if (cell.CellProp.CellState == CellState.Opened)
                return;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    if (cell.CellProp.CellType == CellType.Flagged || cell.CellProp.CellType == CellType.FlaggedMine)
                        return;

                    cell.OnClick();
                    break;

                case MouseButtons.Right:
                    cell.OnFlag();
                    break;

                default:
                    return;
            }
        }
    }
}
