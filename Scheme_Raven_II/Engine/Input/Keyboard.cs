﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Raven.Engine.Input
{
    /// <summary>
    /// 键盘设备的类
    /// </summary>
    public class Keyboard
    {
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(int vKey);

        private Control _openGLControl;
        public KeyPressEventHandler KeyPressEvent;

        /// <summary>
        /// 按键状态
        /// </summary>
        class KeyState
        {
            bool _keyPressDetected = false;
            public bool Held { get; set; }
            public bool Pressed { get; set; }

            public KeyState()
            {
                Held = false;
                Pressed = false;
            }

            internal void OnDown()
            {
                if (Held == false)
                {
                    _keyPressDetected = true;
                }
                Held = true;
            }

            internal void OnUp()
            {
                Held = false;
            }

            internal void Process()
            {
                Pressed = false;
                if (_keyPressDetected)
                {
                    Pressed = true;
                    _keyPressDetected = false;
                }
            }
        }

        private Dictionary<Keys, KeyState> _keyStates = new Dictionary<Keys, KeyState>();

        public Keyboard(Control openGLControl)
        {
            _openGLControl = openGLControl;
            _openGLControl.KeyDown += new KeyEventHandler(OnKeyDown);
            _openGLControl.KeyUp += new KeyEventHandler(OnKeyUp);
            _openGLControl.KeyPress += new KeyPressEventHandler(OnKeyPress);
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (KeyPressEvent != null)
            {
                KeyPressEvent(sender, e);
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            EnsureKeyStateExists(e.KeyCode);
            _keyStates[e.KeyCode].OnUp();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            EnsureKeyStateExists(e.KeyCode);
            _keyStates[e.KeyCode].OnDown();
        }

        private void EnsureKeyStateExists(Keys key)
        {
            if (!_keyStates.Keys.Contains(key))
            {
                _keyStates.Add(key, new KeyState());
            }
        }

        /// <summary>
        /// 是否按下按键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyPressed(Keys key)
        {
            //System.Console.WriteLine(key.ToString());
            EnsureKeyStateExists(key);
            return _keyStates[key].Pressed;
        }

        /// <summary>
        /// 是否按住按键
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool IsKeyHeld(Keys key)
        {
            EnsureKeyStateExists(key);
            return _keyStates[key].Held;
        }

        /// <summary>
        /// 监听当前帧的键盘
        /// </summary>
        public void Process()
        {
            ProcessControlKeys();
            foreach (KeyState state in _keyStates.Values)
            {
                // Reset state.
                state.Pressed = false;
                state.Process();
            }
        }

        private bool PollKeyPress(Keys key)
        {
            return (GetAsyncKeyState((int)key) != 0);
        }

        private void ProcessControlKeys()
        {
            UpdateControlKey(Keys.Left);
            UpdateControlKey(Keys.Right);
            UpdateControlKey(Keys.Up);
            UpdateControlKey(Keys.Down);
            UpdateControlKey(Keys.LMenu); // this is the left alt key
        }

        private void UpdateControlKey(Keys keys)
        {
            if (PollKeyPress(keys))
            {
                System.Console.WriteLine("key down");
                OnKeyDown(this, new KeyEventArgs(keys));
            }
            else
            {
                OnKeyUp(this, new KeyEventArgs(keys));
            }
        }
    }

}
