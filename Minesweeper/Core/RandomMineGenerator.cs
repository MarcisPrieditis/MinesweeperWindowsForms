using System;
using System.Collections.Generic;

namespace Minesweeper.Core
{
    public class RandomMineGenerator
    {
        public static List<Tuple<int, int>> BoardMines = new();
        public static List<Tuple<int, int>> PossibleMines = new();

        public static void AllBoardPossibleNumber(int height, int width, int xLoc, int yLoc)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    PossibleMines.Add(new Tuple<int, int>(j, i));
                }
            }

            for (int i = 0; i < width * height - 1; i++)
            {
                if (PossibleMines[i].Item1 == xLoc && PossibleMines[i].Item2 == yLoc)
                {
                    PossibleMines.Remove(PossibleMines[i]);
                }
            }
        }

        public static void FinalMineLocations(int numMines, int height, int width, int xLoc, int yLoc)
        {
            AllBoardPossibleNumber(height, width, xLoc, yLoc);

            Random r = new Random();
            for (int i = 0; i < numMines; i++)
            {
                var indice = r.Next(PossibleMines.Count);
                BoardMines.Add(PossibleMines[indice]);
                PossibleMines.RemoveAt(indice);
            }

            BoardMines.Sort();
        }
    }
}
