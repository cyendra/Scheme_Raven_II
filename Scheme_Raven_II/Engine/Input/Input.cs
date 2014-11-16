using Tao.Sdl;

namespace Raven.Engine.Input
{
    /// <summary>
    /// 监听输入设备的类
    /// </summary>
    public class Input
    {
        /// <summary>
        /// 鼠标
        /// </summary>
        public Mouse Mouse { get; set; }
        
        /// <summary>
        /// 键盘
        /// </summary>
        public Keyboard Keyboard { get; set; }
        
        /// <summary>
        /// 是否使用手柄
        /// </summary>
        private bool _usingController = false;
        
        /// <summary>
        /// 手柄
        /// </summary>
        public XboxController Controller { get; set; }

        public Input()
        {
            Sdl.SDL_InitSubSystem(Sdl.SDL_INIT_JOYSTICK);
            if (Sdl.SDL_NumJoysticks() > 0)
            {
                Controller = new XboxController(0);
                _usingController = true;
            }
        }

        /// <summary>
        /// 检测输入信息
        /// </summary>
        /// <param name="elapsedTime"></param>
        public void Update(double elapsedTime)
        {
            if (_usingController)
            {
                Sdl.SDL_JoystickUpdate();
                Controller.Update();
            }
            Mouse.Update(elapsedTime);
            Keyboard.Process();
        }

    }
}
