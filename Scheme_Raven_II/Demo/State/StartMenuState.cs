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
using Tao.OpenGl;

namespace Raven.Demo.State
{
    class StartMenuState : IGameObject
    {
        private Renderer _renderer = new Renderer();
        private Text _title;
        private Font _generalFont;
        private Raven.Engine.Input.Input _input;
        private VerticalMenu _menu;
        private StateSystem _system;

        public StartMenuState(Engine.Font.Font titleFont, Engine.Font.Font generalFont, Raven.Engine.Input.Input input, StateSystem system)
        {
            _title = new Text("Shooter", titleFont);
            _title.SetColor(new Color(0, 0, 0, 1));
            _title.SetPosition(-_title.Width / 2, 200);

            _input = input;
            _generalFont = generalFont;
            _system = system;

            InitMenu();
        }

        private void InitMenu()
        {
            _menu = new VerticalMenu(0, 0, _input);

            Button startGame = new Button(
                delegate(object o, EventArgs e)
                {
                    // start
                    _system.ChangeState("inner_game");
                },
                new Text("Start", _generalFont));
            
            Button exitGame = new Button(
                delegate(object o, EventArgs e)
                {
                    System.Windows.Forms.Application.Exit();
                },
                new Text("Exit", _generalFont));

            _menu.AddButton(startGame);
            _menu.AddButton(exitGame);
        }

        public void Update(double elapsedTime)
        {
            _menu.HandleInput();
        }

        public void Render()
        {
            Gl.glClearColor(1, 1, 1, 0);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            _renderer.DrawText(_title);
            _menu.Render(_renderer);
            _renderer.Render();
        }
    }
}
