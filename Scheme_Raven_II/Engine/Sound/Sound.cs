
namespace Raven.Engine
{
    /// <summary>
    /// 代表播放的声音的类
    /// </summary>
    public class Sound
    {
        public int Channel { get; set; }

        public bool FailedToPlay
        {
            get
            {
                // minus is an error state.
                return (Channel == -1);
            }
        }

        public Sound(int channel)
        {
            Channel = channel;
        }

    }
}
