using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Engine;
using Raven.Engine.Graphics;
using Raven.Engine.Font;
using Raven.Engine.DataStruct;
using System.Windows.Forms;

namespace Raven.Engine.Item
{
    /// <summary>
    /// 菜单的类
    /// </summary>
    public class VerticalMenu
    {
        private Vector _position = new Vector();
        private Input.Input _input;
        private List<Button> _buttons = new List<Button>();
        public double Spacing { get; set; }

        private int _currentFocus = 0;

        public VerticalMenu(double x, double y, Input.Input input)
        {
            _input = input;
            _position = new Vector(x, y, 0);
            Spacing = 50;
        }

        /// <summary>
        /// 向菜单中添加按钮
        /// </summary>
        /// <param name="button"></param>
        public void AddButton(Button button)
        {
            double _currentY = _position.Y;

            if (_buttons.Count != 0)
            {
                _currentY = _buttons.Last().Position.Y;
                _currentY -= Spacing;
            }
            else
            {
                button.OnGainFocus();
            }

            button.Position = new Vector(_position.X, _currentY, 0);
            _buttons.Add(button);
        }

        /// <summary>
        /// 渲染菜单中的所有按钮
        /// </summary>
        /// <param name="renderer"></param>
        public void Render(Renderer renderer)
        {
            _buttons.ForEach(x => x.Render(renderer));
        }
        
        /// <summary>
        /// 接受输入信息
        /// </summary>
        public void HandleInput()
        {
            if (_input.Keyboard.IsKeyPressed(Keys.Down) || _input.Keyboard.IsKeyPressed(Keys.S))
            {
                OnDown();
            }
            else if (_input.Keyboard.IsKeyPressed(Keys.Up) || _input.Keyboard.IsKeyPressed(Keys.W))
            {
                OnUp();
            }
            else if (_input.Keyboard.IsKeyPressed(Keys.Enter) || _input.Keyboard.IsKeyPressed(Keys.Space))
            {
                OnButtonPress();
            }
        }

        private void OnButtonPress()
        {
            _buttons[_currentFocus].OnPress();
        }

        private void OnUp()
        {
            int oldFocus = _currentFocus;

            _currentFocus++;

            if (_currentFocus == _buttons.Count)
            {
                _currentFocus = 0;
            }
            ChangeFocus(oldFocus, _currentFocus);
        }

        private void OnDown()
        {
            int oldFocus = _currentFocus;

            _currentFocus--;
            if (_currentFocus == -1)
            {
                _currentFocus = (_buttons.Count - 1);
            }
            ChangeFocus(oldFocus, _currentFocus);
        }

        private void ChangeFocus(int from, int to)
        {
            if (from != to)
            {
                _buttons[from].OnLoseFocus();
                _buttons[to].OnGainFocus();
            }
        }

    }
}
