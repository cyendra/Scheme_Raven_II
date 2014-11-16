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
    public class GameOverState : IGameObject
    {
        private const double _timeOut = 4;
        private double _countDown = _timeOut;

        private StateSystem _system;
        private Input _input;
        private Font _generalFont;
        private Font _titleFont;
        private PersistantGameData _gameData;
        private Renderer _renderer =new Renderer();

        private Text _titleWin;
        private Text _blurbWin;
        private Text _titleLose;
        private Text _blurbLose;

        public GameOverState(PersistantGameData data, StateSystem system, Input input, Font generalFont, Font titleFont)
        {
            _gameData = data;
            _system = system;
            _input = input;
            _generalFont = generalFont;
            _titleFont = titleFont;

            _titleWin = new Text("Complete!", _titleFont);
            _blurbWin = new Text("Congratulations, you win!", _generalFont);

            _titleLose = new Text("Game Over!", _titleFont);
            _blurbLose = new Text("Please try again...", _generalFont);

            FormatText(_titleWin, 150);
            FormatText(_blurbWin, 50);
            FormatText(_titleLose, 150);
            FormatText(_blurbLose, 50);

        }

        private void FormatText(Text _text, int yPosition)
        {
            _text.SetPosition(-_text.Width / 2, yPosition);
            _text.SetColor(new Color(0, 0, 0, 1));
        }



        public void Update(double elapsedTime)
        {
            _countDown -= elapsedTime;
            if (_countDown <= 0 || _input.Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Enter) || _input.Keyboard.IsKeyPressed(System.Windows.Forms.Keys.Space))
            {
                Finish();
            }
        }

        private void Finish()
        {
            _gameData.JustWon = false;
            _system.ChangeState("start_menu");
            _countDown = _timeOut;
        }

        public void Render()
        {
            Gl.glClearColor(1, 1, 1, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            if (_gameData.JustWon)
            {
                _renderer.DrawText(_titleWin);
                _renderer.DrawText(_blurbWin);
            }
            else
            {
                _renderer.DrawText(_titleLose);
                _renderer.DrawText(_blurbLose);
            }
            _renderer.Render();
        }
    }
}
