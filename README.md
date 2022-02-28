# Minesweeper

Made a mini project where base code was already given.<br/>
What I learned during this project:<br/>
`Unit testing - i used XUnit`<br/>
`This was first project of Windows Forms for me`<br/>
`Little bit about Enums`<br/>

How to test it: <br/>

Download project and go to:<br/>
[Minesweeper/bin/Release](https://github.com/MarcisPrieditis/MinesweeperWindowsForms/tree/main/Minesweeper/bin/Release) <br/>
Run **minesweeper.exe**<br/>

Second way how to run project and change board size with mine count:<br/>
1)Open **minesweeper.sln** solution file in Visual Studio<br/>
2)![Run](https://user-images.githubusercontent.com/41679124/156057045-33291142-e6f2-4013-9547-0f888f415b1a.png) Press on Start<br/>
3)Enjoy game :) PS. There is no restart function. If you **loose** or **win** you have to close window and start again <br/>

How to change board size:<br/>
1)Open **minesweeper.sln** solution file in Visual Studio<br/>
2)Select **minesweeper.cs** file and double click on white board to open code<br/>
![mine1](https://user-images.githubusercontent.com/41679124/156051113-4b5131da-16e9-4e1b-90db-29da0527a84d.png)
3)Change parameters as you wish like in picture - width, height, mine count on board
![mine2](https://user-images.githubusercontent.com/41679124/156051090-a9884302-2c71-4e33-a9af-fca8ad8bb21b.png)

My result:
![Minesweeper](https://user-images.githubusercontent.com/41679124/156051142-37cf7d75-99fa-469b-826b-ed452a1379ee.png)


Create a classic minesweeper game, you are given some starting point already.
![Minesweeper](./minesweeper.png "Minesweeper")

## Requirements

You are presented with a board of squares. Some squares contain mines (bombs), others don't. If you click on a square containing a bomb, you lose. If you manage to click all the squares (without clicking on any bombs) you win.
Clicking a square which doesn't have a bomb reveals the number of neighbouring squares containing bombs. Use this information plus some guess work to avoid the bombs.
To open a square, point at the square and click on it. To mark a square you think is a bomb, point and right-click.

- A squares "neighbours" are the squares adjacent above, below, left, right, and all 4 diagonals. Squares on the sides of the board or in a corner have fewer neighbors. The board does not wrap around the edges.
- If you open a square with 0 neighboring bombs, all its neighbors will automatically open. This can cause a large area to automatically open.
To remove a bomb marker from a square, point at it and right-click again.
- The first square you open is never a bomb.
- If you mark a bomb incorrectly, you will have to correct the mistake before you can win. Incorrect bomb marking doesn't kill you, but it can lead to mistakes which do.
- You don't have to mark all the bombs to win; you just need to open all non-bomb squares.
