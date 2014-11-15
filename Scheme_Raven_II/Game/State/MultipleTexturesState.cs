using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Raven.Engine;
using Raven.Engine.Graphics;

namespace Raven.Game.State
{
    public class MultipleTexturesState : IGameObject
    {
        private Sprite _spaceship1 = new Sprite();
        private Sprite _spaceship2 = new Sprite();
        Renderer _renderer = new Renderer();

        public MultipleTexturesState(TextureManager textureManager)
        {
            _spaceship1.Texture = textureManager.Get("spaceship");
            _spaceship2.Texture = textureManager.Get("spaceship2");
            _spaceship1.SetPosition(-300, 0);
        }

        public void Update(double elapsedTime)
        {
          
        }

        public void Render()
        {
            _renderer.DrawSprite(_spaceship1);
            _renderer.DrawSprite(_spaceship2);
        }
    }
}
