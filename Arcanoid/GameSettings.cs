using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid
{
    public class GameSettings
    {
        public GameSettings()
        {
            Console.CursorVisible = false;
        }

        public int ConsoleWidth { get; } = 80;
        public int ConsoleHeight { get; } = 20;
        public int BlocksStartTop { get; } = 2;
        public int BlocksStartLeft { get; } = 1;
        public int PlayerPlatformStartTop { get; } = 17;
        public int PlayerPlatformStartLeft { get; } = 36;
        public int BallStartTop { get; } = 16;
        public int BallStartLeft { get; } = 39;
        public char BlockSymbol { get; } = '*';
        public char PlatformSymbol { get; } = '#';
        public char BallSymbol { get; } = 'O';
        public ConsoleColor PlatformColor { get; } = ConsoleColor.DarkBlue;
        public ConsoleColor BallColor { get; } = ConsoleColor.Cyan;
        public ConsoleColor IndestructableBlockColor { get; } = ConsoleColor.DarkRed;
        public ConsoleColor BlockColor { get; } = ConsoleColor.Yellow;
        public int LinesOfBlocks { get; } = 4;
        public int BlocksInOneLine { get; } = 20;
        public int PlayerLives { get; } = 3;

    }
}
