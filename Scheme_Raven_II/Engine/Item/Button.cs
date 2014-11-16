using Raven.Engine.DataStruct;
using Raven.Engine.Font;
using Raven.Engine.Graphics;
using System;

namespace Raven.Engine.Item
{
    /// <summary>
    /// 按钮类
    /// </summary>
    public class Button
    {
        private EventHandler _onPressEvent;
        private Text _label;
        private Vector _position = new Vector();

        /// <summary>
        /// 按钮所在位置
        /// </summary>
        public Vector Position
        {
            get { return _position; }
            set
            {
                _position = value;
                UpdatePosition();
            }
        }

        public Button(EventHandler onPressEvent, Text label)
        {
            _onPressEvent = onPressEvent;
            _label = label;
            _label.SetColor(new Color(0, 0, 0, 1));
            UpdatePosition();
        }

        /// <summary>
        /// 更新按钮位置
        /// </summary>
        public void UpdatePosition()
        {
            _label.SetPosition(_position.X - (_label.Width / 2), _position.Y - (_label.Height / 2));
        }

        /// <summary>
        /// 按钮取得焦点
        /// </summary>
        public void OnGainFocus()
        {
            _label.SetColor(new Color(1, 0, 0, 1));
        }

        /// <summary>
        /// 按钮失去焦点
        /// </summary>
        public void OnLoseFocus()
        {
            _label.SetColor(new Color(0, 0, 0, 1));
        }

        /// <summary>
        /// 选定按钮
        /// </summary>
        public void OnPress()
        {
            _onPressEvent(this, EventArgs.Empty);
        }

        /// <summary>
        /// 渲染按钮
        /// </summary>
        /// <param name="renderer"></param>
        public void Render(Renderer renderer)
        {
            renderer.DrawText(_label);
        }

    }
}
