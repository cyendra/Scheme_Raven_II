using System;
using System.Collections.Generic;
using Tao.DevIl;
using Tao.OpenGl;

namespace Raven.Engine.Graphics
{
    /// <summary>
    /// 纹理管理器
    /// </summary>
    public class TextureManager : IDisposable
    {
        private Dictionary<string, Texture> _textureDatabase = new Dictionary<string, Texture>();

        /// <summary>
        /// 获取纹理
        /// </summary>
        /// <param name="textureId"></param>
        /// <returns></returns>
        public Texture Get(string textureId)
        {
            return _textureDatabase[textureId];
        }

        /// <summary>
        /// 加载纹理
        /// </summary>
        /// <param name="textureId"></param>
        /// <param name="path"></param>
        public void LoadTexture(string textureId, string path)
        {
            int devilId = 0;
            Il.ilGenImages(1, out devilId);
            Il.ilBindImage(devilId); // set as the active texture.

            if (!Il.ilLoadImage(path))
            {
                System.Diagnostics.Debug.Assert(false,
                    "Could not open file, [" + path + "].");
            }

            Ilu.iluFlipImage();

            int width = Il.ilGetInteger(Il.IL_IMAGE_WIDTH);
            int height = Il.ilGetInteger(Il.IL_IMAGE_HEIGHT);
            int openGLId = Ilut.ilutGLBindTexImage();

            System.Diagnostics.Debug.Assert(openGLId != 0);
            Il.ilDeleteImages(1, ref devilId);

            _textureDatabase.Add(textureId, new Texture(openGLId, width, height));
        }


        #region IDisposable Members

        public void Dispose()
        {
            foreach (Texture t in _textureDatabase.Values)
            {
                Gl.glDeleteTextures(1, new int[] { t.Id });
            }
        }

        #endregion

    }
}
