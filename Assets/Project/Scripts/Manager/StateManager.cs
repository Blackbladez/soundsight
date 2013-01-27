using Assets.Project.Scripts.Model;
using Assets.Project.Scripts.State;
using UnityEngine;

namespace Assets.Project.Scripts.Manager
{
    public class StateManager : MonoBehaviour
    {
        private SKStateMachine<HeartModel> _heartStateMachine;
        private SKStateMachine<LightModel> _lightStateMachine;
        private static StateManager instance;
    
        void Awake()
        {
            if (instance == null) instance = this;

            var heartModel = new HeartModel();
            _heartStateMachine = new SKStateMachine<HeartModel>(heartModel, new HeartCalmState());

            var lightModel = new LightModel();
            _lightStateMachine = new SKStateMachine<LightModel>(lightModel, new LightOffState());
        }

        public static StateManager Instance
        {
            get { return instance; }
        }

        public void UpdateState(Model.State state)
        {
            switch (state)
            {
                case Model.State.Light:
                    _lightStateMachine.update(Time.deltaTime);
                    break;
                case Model.State.Heart:
                    _heartStateMachine.update(Time.deltaTime);
                    break;
            }
        }

        public SKStateMachine<LightModel> LightState
        {
            get { return _lightStateMachine; }
        }

        public SKStateMachine<HeartModel> HeartState
        {
            get { return _heartStateMachine; }
        }
    }
}
