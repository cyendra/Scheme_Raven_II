using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raven.Engine;
using Raven.Engine.Graphics;
using Raven.Engine.Input;

namespace Raven.Game.State
{
    public class SoundTestState : IGameObject
    {
        private SoundManager _soundManager;
        private Input _input;
        double _count = 0;

        public SoundTestState(SoundManager soundManager, Input input)
        {
            _soundManager = soundManager;
            _input = input;
        }

        public void Update(double elapsedTime)
        {
            if (_count<=0 && _input.Mouse.LeftPressed)
            {
                _count = 1;
                _soundManager.PlaySound("effect");
            }
            if (_count > 0) _count -= elapsedTime;
        }

        public void Render()
        {

        }
    }
}
