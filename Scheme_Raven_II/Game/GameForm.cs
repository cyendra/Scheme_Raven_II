using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Tao.OpenGl;


namespace Scheme_Raven_II.Game
{
    public partial class GameForm : Form
    {
        private GameLoop _gameLoop;
        private StateSystem _system;

        public GameForm()
        {
            _gameLoop = new GameLoop(GameLoop);
            _system = new StateSystem();
            _system.AddState("title_menu", new TitleMenuState());
            _system.AddState("splash", new SplashScreenState(_system));
            _system.ChangeState("splash");
            InitializeComponent();
            _openGLControl.InitializeContexts();
        }

        private void GameLoop(double elapsedTime)
        {
            _system.Update(elapsedTime);
            _system.Render();

            _openGLControl.Refresh();
        }
    }
}
