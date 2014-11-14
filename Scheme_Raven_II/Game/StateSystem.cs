using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheme_Raven_II.Game
{
    class StateSystem
    {
        private Dictionary<string, IGameObject> _stateStore = new Dictionary<string, IGameObject>();
        private IGameObject _currentState = null;
        public void Update(double elapsedTime)
        {
            if (_currentState == null)
            {
                return;
            }
            _currentState.Update(elapsedTime);
        }
        public void Render()
        {
            if (_currentState == null)
            {
                return;
            }
            _currentState.Render();
        }
        public void AddState(string stateId, IGameObject state)
        {
            System.Diagnostics.Debug.Assert(Exists(stateId) == false);
            _stateStore.Add(stateId, state);
        }
        public void ChangeState(string stateId)
        {
            System.Diagnostics.Debug.Assert(Exists(stateId) == true);
            _currentState = _stateStore[stateId];
        }
        public bool Exists(string stateId)
        {
            return _stateStore.ContainsKey(stateId);
        }
    }
}
