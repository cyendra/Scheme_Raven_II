using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raven.Demo
{
    public class PersistantGameData
    {
        public bool JustWon { get; set; }
        public LevelDescription CurrentLevel { get; set; }
        public PersistantGameData()
        {
            JustWon = false;
        }
    }
}
