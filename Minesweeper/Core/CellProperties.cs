using System.Windows.Forms;

namespace Minesweeper.Core
{
    public enum CellType
    {
        Regular, Mine, Flagged, FlaggedMine
    }

    public enum CellState
    {
        Opened, Closed
    }

    public class CellProperties : Button
    {
        public int XLoc { get; set; }
        public int YLoc { get; set; }
        public int CellSize { get; set; }
        public CellState CellState { get; set; }
        public CellType CellType { get; set; }

        public CellProperties(int xLoc, int yLoc, int cellSize, CellState cellState, CellType cellType)
        {
            XLoc = xLoc;
            YLoc = yLoc;
            CellSize = cellSize;
            CellState = cellState;
            CellType = cellType;
        }
    }
}