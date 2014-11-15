using Raven.Engine.Graphics;

namespace Raven.Engine.Font
{
    /// <summary>
    /// 字母精灵类
    /// </summary>
    public class CharacterSprite
    {
        public Sprite Sprite { get; set; }
        public CharacterData Data { get; set; }

        public CharacterSprite(Sprite sprite, CharacterData data)
        {
            Data = data;
            Sprite = sprite;
        }
    }
}
