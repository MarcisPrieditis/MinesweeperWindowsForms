using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Minesweeper.Tests
{
    [TestClass]
    public class RandomMineGenerator
    {
        [Fact]
        public void AllBoardPossibleNumber_2_2_ShouldReturnListOf3Versions()
        {
            //Act
            Core.RandomMineGenerator.AllBoardPossibleNumber(2, 2, 0, 0);
            var res = String.Join(" ", Core.RandomMineGenerator.PossibleMines);

            //Assert
            Assert.AreEqual("(1, 0) (0, 1) (1, 1)", res);
        }

        [Fact]
        public void FinalMineLocations_3mineIn2x2Board_ShouldReturnEmptyPossibleList_And3BombLocationsInBoardMinesSortedWay()
        {
            //Act
            Core.RandomMineGenerator.FinalMineLocations(3, 2, 2, 0, 0);
            var possibleMine = String.Join(" ", Core.RandomMineGenerator.PossibleMines);
            var boardMines = String.Join(" ", Core.RandomMineGenerator.BoardMines);

            //Assert
            Assert.AreEqual("", possibleMine);
            Assert.AreEqual("(0, 1) (1, 0) (1, 1)", boardMines);
        }

    }
}
