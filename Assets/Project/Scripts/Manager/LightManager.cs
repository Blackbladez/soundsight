using Assets.Project.Scripts.Model;
using UnityEngine;

namespace Assets.Project.Scripts.Manager
{
    public class LightManager : MonoBehaviour
    {
        private static LightManager instance;
        private LightState _currentState;
        
        void Awake()
        {
            if (instance == null) instance = this;
            _currentState = LightState.Off;
        }

        public static LightManager Instance { get { return instance; } }

        public LightState CurrentState 
        { 
            get { return _currentState; }
            set
            {
                if (Equals(value, _currentState))
                    return;
                _currentState = value;
            }
        }
    }
}
