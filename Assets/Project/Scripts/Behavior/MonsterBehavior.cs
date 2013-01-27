using Assets.Project.Scripts.Manager;
using Assets.Project.Scripts.Model;
using UnityEngine;
namespace Assets.Project.Scripts.Behavior
{
    public class MonsterBehavior : MonoBehaviour
    {
        void Awake()
        {
        }
        // Use this for initialization
        void Start () 
        {
	
        }
	
        // Update is called once per frame
        void Update ()
        {
            // a monster has 3 behaviors
	        if (LightManager.Instance.CurrentState == LightState.Off)
	        {
                // b. within proximity of player chase player
                // c. if out of leash range, return to patrol path
	        }

            if (LightManager.Instance.CurrentState == LightState.On)
            {
                // a. when its light on - it stops moving
            }
        }
    
        
        
        

    }
}
