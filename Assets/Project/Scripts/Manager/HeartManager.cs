using Assets.Project.Scripts.State;
using UnityEngine;

namespace Assets.Project.Scripts.Manager
{
    public class HeartManager : MonoBehaviour
    {
        private SKStateMachine<HeartModel> _heartState; 
        void Awake()
        {
            var heartState = new HeartModel();
            _heartState = new SKStateMachine<HeartModel>(heartState, new HeartCalmState());
        }
	
        // Update is called once per frame
        void Update () {
	
        }
    }
}
