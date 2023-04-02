using Arcanoid.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Objects
{
    internal class Frame
    {
        private GameObject playerPlatform;

        private GameObject ball;

        private List<GameObject> blocks;

        private readonly GameSettings gameSettings;

        public GameObject PlayerPlatform { get { return playerPlatform; } }
        public GameObject Ball { get { return ball; } }
        public List<GameObject> Blocks { get { return blocks; } }

        public Frame(GameSettings gameSettings)
        {
            this.gameSettings = gameSettings;
            PlayerPlatformFactory playerPlatformFactory = new PlayerPlatformFactory(gameSettings);
            playerPlatform = playerPlatformFactory.GetPlayerPlatform();

            BallFactory ballFactory = new BallFactory(gameSettings);
            ball = ballFactory.GetBall();

            BlockFactory blockFactory = new BlockFactory(gameSettings);
            blocks = blockFactory.GetBlocks();
        }
    }
}
