using Arcanoid.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.Factories
{
    internal class PlayerPlatformFactory : AbstractFactory
    {
        public PlayerPlatformFactory(GameSettings gameSettings) : base(gameSettings)
        {
        }

        public GameObject GetPlayerPlatform()
        {
            return GetGameObject(gameSettings.PlayerPlatformStartTop, gameSettings.PlayerPlatformStartLeft, false);
        }

        public override GameObject GetGameObject(int top, int left, bool isDestructable)
        {
            return new PlayerPlatform(top, left, isDestructable, gameSettings.PlatformColor, 8, 2, gameSettings.PlatformSymbol);
        }
    }
}
