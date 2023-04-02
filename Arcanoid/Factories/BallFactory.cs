using Arcanoid.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Factories
{
    internal class BallFactory : AbstractFactory
    {
        public BallFactory(GameSettings gameSettings) : base(gameSettings)
        {
        }

        public GameObject GetBall()
        {
            return GetGameObject(gameSettings.BallStartTop, gameSettings.BallStartLeft, false);
        }

        public override GameObject GetGameObject(int top, int left, bool isDestructable)
        {
            return new Ball(top, left, isDestructable, gameSettings.BallColor, 1, 1, gameSettings.BallSymbol);
        }
    }
}
