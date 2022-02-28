using Microsoft.VisualStudio.TestTools.UnitTesting;
using Minesweeper.Core;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Minesweeper.Tests
{
    [TestClass]
    public class CellTests
    {
        private Cell _cell;
        private Board _board;

        public CellTests()
        {
            _cell = new Cell();
            _board = new Board(5, 5, 5);
            _cell.Board = _board;
        }

        [Theory]
        [InlineData(-1, -1, true)]
        [InlineData(-1, 0, true)]
        [InlineData(-1, 1, true)]
        [InlineData(0, -1, true)]
        [InlineData(0, 0, false)]
        [InlineData(0, 1, false)]
        [InlineData(1, -1, true)]
        [InlineData(1, 0, false)]
        [InlineData(1, 1, false)]
        public void CellInBound_CheckIfOutOfBoundIsSkipped(int i, int j, bool expected)
        {
            //Arrange
            var c = new Cell
            {
                CellProp = new CellProperties(0, 0, 50, CellState.Opened, CellType.Regular)
            };
            c.Board = _board;
            
            //Act
            var res = c.CellInBound(i, j);

            //Assert
            Assert.AreEqual(expected, res);
        }

        [Fact]
        public void CheckWinner_OpenedCells20_ShouldReturnTrue()
        {
            //Arrange
            Cell.openedCellCount = 20;

            //Assert
            Assert.AreEqual(true, _cell.CheckWinner());
        }

        [Fact]
        public void CheckWinner_OpenedCells19_ShouldReturnFalse()
        {
            //Arrange
            Cell.openedCellCount = 19;

            //Assert
            Assert.AreEqual(false, _cell.CheckWinner());
        }

        [Theory]
        [InlineData(CellType.Flagged, "", CellType.Regular)]
        [InlineData(CellType.FlaggedMine, "", CellType.Mine)]
        [InlineData(CellType.Mine, "🚩", CellType.FlaggedMine)]
        [InlineData(CellType.Regular, "🚩", CellType.Flagged)]
        public void OnFlag_RightClickCheck_CheckCellTypes_CheckTextReturn
            (CellType cellType, string expected, CellType expectedReturnCellType)
        {
            //Arrange
            var c = new Cell
            {
                CellProp = new CellProperties(0, 0, 50, CellState.Opened, cellType)
            };

            //Assert
            Assert.AreEqual(expected, c.OnFlag());
            Assert.AreEqual(expectedReturnCellType, c.CellProp.CellType);
        }

        [Fact]
        public void CountBombs_3mines_ShouldReturn3()
        {
            //Arrange
            _board = new Board(2, 2, 3);

            var c = new Cell
            {
                CellProp = new CellProperties(0, 0, 50, CellState.Opened, CellType.Regular)
            };
            _board.Cells[0, 0] = c;

            var c2 = new Cell
            {
                CellProp = new CellProperties(0, 1, 50, CellState.Closed, CellType.Mine)
            };
            _board.Cells[0, 1] = c2;

            var c3 = new Cell
            {
                CellProp = new CellProperties(1, 0, 50, CellState.Closed, CellType.Mine)
            };
            _board.Cells[1, 0] = c3;

            var c4 = new Cell
            {
                CellProp = new CellProperties(1, 1, 50, CellState.Closed, CellType.Mine)
            };
            _board.Cells[1, 1] = c4;

            c.Board = _board;

            //Act
            var res = c.CountBombs();
            c.OnClick();

            //Assert
            Assert.AreEqual(3, res);
            Assert.AreEqual(50, c.CellProp.CellSize);
            Assert.AreEqual("Opened", c.CellProp.CellState.ToString());
            Assert.AreEqual("Closed", c2.CellProp.CellState.ToString());
            Assert.AreEqual("3", c.Text);
        }
    }
}