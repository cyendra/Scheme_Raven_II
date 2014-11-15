using Engine.DataStruct;
using Engine.Font;
using Tao.OpenGl;

namespace Engine.Graphics
{
    /// <summary>
    /// 渲染器
    /// </summary>
    public class Renderer
    {
        public Renderer()
        {
            Gl.glEnable(Gl.GL_TEXTURE_2D);
            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
        }

        /// <summary>
        /// 立即绘制顶点模式
        /// </summary>
        /// <param name="position"></param>
        /// <param name="color"></param>
        /// <param name="uvs"></param>
        public void DrawImmediateModeVertex(Vector position, Color color, Point uvs)
        {
            Gl.glColor4f(color.Red, color.Green, color.Blue, color.Alpha);
            Gl.glTexCoord2f(uvs.X, uvs.Y);
            Gl.glVertex3d(position.X, position.Y, position.Z);
        }

        private Batch _batch = new Batch();

        private int _currentTextureId = -1;

        /// <summary>
        /// 绘制精灵
        /// </summary>
        /// <param name="sprite"></param>
        public void DrawSprite(Sprite sprite)
        {
            if (sprite.Texture.Id == _currentTextureId)
            {
                _batch.AddSprite(sprite);
            }
            else
            {
                _batch.Draw(); // Draw all with current texture

                // Update texture info
                _currentTextureId = sprite.Texture.Id;
                Gl.glBindTexture(Gl.GL_TEXTURE_2D, _currentTextureId);
                _batch.AddSprite(sprite);
            }
        }

        /// <summary>
        /// 渲染
        /// </summary>
        public void Render()
        {
            _batch.Draw();
        }

        /// <summary>
        /// 绘制文字
        /// </summary>
        /// <param name="text"></param>
        public void DrawText(Text text)
        {
            foreach (CharacterSprite c in text.CharacterSprites)
            {
                DrawSprite(c.Sprite);
            }
        }
    }
}
