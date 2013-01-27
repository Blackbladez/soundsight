using Assets.Project.Scripts.Model;
using UnityEngine;

namespace Assets.Project.Scripts.Manager
{
    public class LightManager : MonoBehaviour
    {
        private static LightManager instance;
        private LightState _currentState;

        private float LightsOffTime;
        private float LightsOnTime;
        
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

        void Update()
        {
            if(CurrentState == LightState.Off)
            {
                if(LightsOffTime == 0)
                {
                    LightsOffTime = Time.time + Random.Range(10f, 25f);
                    LightsOnTime = 0;
                }
                else if(Time.time > LightsOffTime)
                {
                    CurrentState = LightState.On;
                    StateManager.Instance.UpdateState(Model.State.Light);
                }
            }
            else //LightState.On
            {
                if(LightsOnTime == 0)
                {
                    LightsOnTime = Time.time + Random.Range(5f, 15f);
                    LightsOffTime = 0;
                }
                else if(Time.time > LightsOnTime)
                {
                    CurrentState = LightState.Off;
                    StateManager.Instance.UpdateState(Model.State.Light);
                }
            }
        }
    }
}
