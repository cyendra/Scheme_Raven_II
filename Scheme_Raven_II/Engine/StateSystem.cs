using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Engine
{
    /// <summary>
    /// 控制游戏状态的类
    /// </summary>
    public class StateSystem
    {
        private Dictionary<string, IGameObject> _stateStore = new Dictionary<string, IGameObject>();
        private IGameObject _currentState = null;

        /// <summary>
        /// 更新函数
        /// </summary>
        /// <param name="elapsedTime"></param>
        public void Update(double elapsedTime)
        {
            if (_currentState == null)
            {
                return; // nothing to process
            }
            _currentState.Update(elapsedTime);
        }

        /// <summary>
        /// 渲染函数
        /// </summary>
        public void Render()
        {
            if (_currentState == null)
            {
                return; // nothing to render
            }
            _currentState.Render();
        }

        /// <summary>
        /// 添加游戏状态
        /// </summary>
        /// <param name="stateId">状态的名字</param>
        /// <param name="state">状态的对象</param>
        public void AddState(string stateId, IGameObject state)
        {
            System.Diagnostics.Debug.Assert(Exists(stateId) == false);
            _stateStore.Add(stateId, state);
        }

        /// <summary>
        /// 改变游戏状态
        /// </summary>
        /// <param name="stateId">目标状态</param>
        public void ChangeState(string stateId)
        {
            System.Diagnostics.Debug.Assert(Exists(stateId));
            _currentState = _stateStore[stateId];
        }

        /// <summary>
        /// 检查一个状态是否存在
        /// </summary>
        /// <param name="stateId">要检查的状态名字</param>
        /// <returns>如果状态存在返回true，否则返回false</returns>
        public bool Exists(string stateId)
        {
            return _stateStore.ContainsKey(stateId);
        }
    }
}
