using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raven.Engine;
using Raven.Engine.Graphics;

namespace Raven.Game.State
{
    public class SoundTestState : IGameObject
    {
        private SoundManager _soundManager;
        double _count = 3;

        public SoundTestState(SoundManager soundManager)
        {
            _soundManager = soundManager;
        }

        public void Update(double elapsedTime)
        {
            _count -= elapsedTime;
            if (_count < 0)
            {
                _count = 3;
                _soundManager.PlaySound("effect");
            }
        }

        public void Render()
        {

        }
    }
}
