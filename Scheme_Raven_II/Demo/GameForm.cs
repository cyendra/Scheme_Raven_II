using Raven.Engine;
using Raven.Engine.Graphics;
using Raven.Engine.Input;
using System;
using System.Drawing;
using System.Windows.Forms;
using Tao.DevIl;
using Tao.OpenGl;
using Raven.Engine.Font;
using Raven.Demo.State;
namespace Raven.Demo
{
    public partial class GameForm : Form
    {
        private bool _fullscreen = false;                                    // 全屏化标记

        private GameLoop _gameLoop;                                          // 游戏循环
        private StateSystem _system = new StateSystem();                    // 游戏状态管理器
        private Input _input = new Input();                                  // 输入管理器
        private TextureManager _textureManager = new TextureManager();       // 纹理管理器
        private SoundManager _soundManager = new SoundManager();             // 声音管理器

        private PersistantGameData _persistantGameData = new PersistantGameData();
        
        private Engine.Font.Font _titleFont;
        private Engine.Font.Font _generalFont;

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

            InitDisplay();
            InitTextures();
            InitGameData();
            InitSound();
            InitInput();
            InitFonts();

            InitGameState();


            _gameLoop = new GameLoop(GameLoop);

        }

        private void InitGameData()
        {
            LevelDescription level = new LevelDescription();
            level.Time = 1;
            _persistantGameData.CurrentLevel = level;
        }

        private void InitFonts()
        {
            _titleFont = new Engine.Font.Font(_textureManager.Get("title_font"), FontParser.Parse("Demo/data/title_font.fnt"));
            _generalFont = new Engine.Font.Font(_textureManager.Get("general_font"), FontParser.Parse("Demo/data/general_font.fnt"));
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
            _textureManager.LoadTexture("title_font", "Demo/data/title_font.tga");
            _textureManager.LoadTexture("general_font", "Demo/data/general_font.tga");
        }

        /// <summary>
        /// 初始化游戏状态
        /// </summary>
        private void InitGameState()
        {
            // 加载游戏状态
            _system.AddState("start_menu", new StartMenuState(_titleFont, _generalFont, _input, _system));
            _system.AddState("inner_game", new InnerGameState(_system, _input, _persistantGameData, _generalFont));
            _system.AddState("game_over", new GameOverState(_persistantGameData, _system, _input, _generalFont, _titleFont));

            _system.ChangeState("start_menu");
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
