using Arcanoid.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Factories
{
    internal class BlockFactory : AbstractFactory
    {
        public BlockFactory(GameSettings gameSettings) : base(gameSettings)
        {
        }

        public List<GameObject> GetBlocks()
        {
            List<GameObject> blocks = new List<GameObject>();
            for (int i = 0; i < gameSettings.LinesOfBlocks; i++)
            {
                if (i != gameSettings.LinesOfBlocks - 1)
                {
                    for (int j = 0; j < gameSettings.ConsoleWidth; j += 4)
                    {
                        blocks.Add(GetGameObject(gameSettings.BlocksStartTop + (i * 2), gameSettings.BlocksStartLeft + j, true));
                    }
                }
                else
                {
                    for (int j = 0; j < gameSettings.ConsoleWidth; j += 4)
                    {
                        if (j % 12 == 0)
                        {
                            blocks.Add(GetGameObject(gameSettings.BlocksStartTop + (i * 2), gameSettings.BlocksStartLeft + j, false));
                        }
                        else
                        {
                            blocks.Add(GetGameObject(gameSettings.BlocksStartTop + (i * 2), gameSettings.BlocksStartLeft + j, true));
                        }
                        
                    }
                }
            }

            return blocks;
        }

        public override GameObject GetGameObject(int top, int left, bool isDestructable)
        {
            return new Block(   top, left, isDestructable,
                                isDestructable ? gameSettings.BlockColor : gameSettings.IndestructableBlockColor,
                                3,
                                1,
                                gameSettings.BlockSymbol);
        }
    }
}
