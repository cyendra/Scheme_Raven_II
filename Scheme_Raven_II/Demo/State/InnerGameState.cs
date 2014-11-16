using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Engine;
using Raven.Engine.Graphics;
using Raven.Engine.Font;
using Raven.Engine.DataStruct;
using Raven.Engine.Item;
using Raven.Engine.Input;
using Tao.OpenGl;
namespace Raven.Demo.State
{
    public class InnerGameState : IGameObject
    {
        private Renderer _renderer = new Renderer();
        private Engine.Input.Input _input;
        private StateSystem _system;
        private PersistantGameData _gameData;
        private Font _generalFont;

        private double _gameTime;

        public InnerGameState(StateSystem system, Input input, PersistantGameData gameData, Font generalFont)
        {
            _input = input;
            _system = system;
            _gameData = gameData;
            _generalFont = generalFont;
            OnGameStart();
        }

        public void OnGameStart()
        {
            _gameTime = _gameData.CurrentLevel.Time;
        }



        public void Update(double elapsedTime)
        {
            _gameTime -= elapsedTime;
            if (_gameTime <= 0)
            {
                OnGameStart();
                _gameData.JustWon = true;
                _system.ChangeState("game_over");
            }
        }

        public void Render()
        {
            Gl.glClearColor(1, 0, 1, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.Render();
        }
    }
}
