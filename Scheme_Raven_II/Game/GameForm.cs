using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Tao.OpenGl;


namespace Scheme_Raven_II
{
    namespace Game
    {
        public partial class GameForm : Form
        {
            private GameLoop _gameLoop;

            public GameForm()
            {
                _gameLoop = new GameLoop(GameLoop);
                InitializeComponent();
                _openGLControl.InitializeContexts();
            }

            private void GameLoop(double elapsedTime)
            {
                Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
                Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);

                Gl.glPointSize(5.0f);

                Gl.glRotated(100 * elapsedTime, 1, 1, 0);
                Gl.glBegin(Gl.GL_TRIANGLE_STRIP);
                {
                    //Gl.glColor3d(1.0, 0.0, 0.0);
                    Gl.glColor4d(1.0, 0.0, 0.0, 0.5);
                    Gl.glVertex3d(-0.5, 0, 0);

                    Gl.glColor3d(0.0, 0.1, 0.0);
                    Gl.glVertex3d(0.5, 0, 0);

                    Gl.glColor3d(0.0, 0.0, 0.1);
                    Gl.glVertex3d(0, 0.5, 0);
                }
                Gl.glEnd();

                Gl.glFinish();

                _openGLControl.Refresh();
            }
        }

    }
}
