using Arkanoid.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid.Factories
{
    internal abstract class AbstractFactory
    {
        protected readonly GameSettings gameSettings;
        protected AbstractFactory(GameSettings gameSettings) 
        {
            this.gameSettings = gameSettings;
        }
        public abstract GameObject GetGameObject(int top, int left, bool isDestructable);
    }
}
