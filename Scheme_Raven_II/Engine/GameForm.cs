using Raven.Engine;
using Raven.Engine.Graphics;
using Raven.Engine.Input;
using System;
using System.Drawing;
using System.Windows.Forms;
using Tao.DevIl;
using Tao.OpenGl;

namespace Raven.Engine
{
    public partial class GameForm : Form
    {
        private bool _fullscreen;               // 全屏化标记

        private GameLoop _gameLoop;             // 游戏循环
        private StateSystem _system;            // 游戏状态管理器
        private Input.Input _input;                   // 输入管理器
        private TextureManager _textureManager; // 纹理管理器
        private SoundManager _soundManager;     // 声音管理器

        public GameForm()
        {
            InitializeComponent();
            _openGLControl.InitializeContexts();
            InitGame();
        }

        /// <summary>
        /// 初始化游戏系统
        /// </summary>
        private void InitGame()
        {
            _fullscreen = false;
            _system = new StateSystem();
            _input = new Input.Input();
            _textureManager = new TextureManager();
            _soundManager = new SoundManager();

            InitDisplay();
            InitTextures();
            InitGameState();
            InitSound();
            InitInput();

            _gameLoop = new GameLoop(GameLoop);

        }

        /// <summary>
        /// 初始化输入设备
        /// </summary>
        private void InitInput()
        {
            _input.Mouse = new Mouse(this, _openGLControl);
            _input.Keyboard = new Keyboard(_openGLControl);
        }

        /// <summary>
        /// 初始化显示
        /// </summary>
        private void InitDisplay()
        {
            if (_fullscreen)
            {
                FormBorderStyle = FormBorderStyle.None;
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                ClientSize = new Size(580, 460);
            }
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
        }

        /// <summary>
        /// 初始化纹理
        /// </summary>
        private void InitTextures()
        {
            // 初始化 DevIl
            Il.ilInit();
            Ilu.iluInit();
            Ilut.ilutInit();
            Ilut.ilutRenderer(Ilut.ILUT_OPENGL);

            // 使用纹理管理器加载纹理

        }

        /// <summary>
        /// 初始化游戏状态
        /// </summary>
        private void InitGameState()
        {
            // 加载游戏状态
            
            //_system.ChangeState("");
        }

        /// <summary>
        /// 初始化声音
        /// </summary>
        private void InitSound()
        {
            // 加载声音
        }

        /// <summary>
        /// 更新输入
        /// </summary>
        private void UpdateInput(double elapsedTime)
        {
            _input.Update(elapsedTime);
        }

        /// <summary>
        /// 游戏循环
        /// </summary>
        /// <param name="elapsedTime"></param>
        private void GameLoop(double elapsedTime)
        {
            UpdateInput(elapsedTime);
            _system.Update(elapsedTime);
            _system.Render();

            _openGLControl.Refresh();
        }

        private void Setup2DGraphics(double width, double height)
        {
            double halfWidth = width / 2;
            double halfHeight = height / 2;
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(-halfWidth, halfWidth, -halfWidth, halfHeight, -100, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();
        }

        protected override void OnClientSizeChanged(EventArgs e)
        {
            base.OnClientSizeChanged(e);
            Gl.glViewport(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            Setup2DGraphics(ClientSize.Width, ClientSize.Height);
        }
    }
}
