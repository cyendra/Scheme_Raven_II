using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raven.Engine
{
    /// <summary>
    /// 游戏对象接口
    /// </summary>
    public interface IGameObject
    {
        /// <summary>
        /// 更新函数
        /// </summary>
        /// <param name="elapsedTime"></param>
        void Update(double elapsedTime);
        
        /// <summary>
        /// 渲染函数
        /// </summary>
        void Render();
    }
}
