using Assets.Project.Scripts.Manager;
using Assets.Project.Scripts.Model;
using UnityEngine;
namespace Assets.Project.Scripts.Behavior
{
    public class MonsterBehavior : MonoBehaviour
    {
        public float Proximity;
        private hoMove MonsterPath;
        private Rigidbody rigidBody;

        void Awake()
        {
            MonsterPath = this.GetComponent<hoMove>();
            rigidBody = this.GetComponent<Rigidbody>();
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
	            var currentDistance = Vector3.Distance(this.transform.position,
	                                                   LevelManager.Instance.Player.transform.position);
                if(currentDistance <= Proximity)
                {
                    MonsterPath.Pause();
                    
                    rigidBody.AddForce(this.transform.TransformDirection(LevelManager.Instance.Player.transform.position));
                }
                else
                {
                    MonsterPath.Resume();
                }
	        }

            if (LightManager.Instance.CurrentState == LightState.On)
            {
                // a. when its light on - it stops moving
                MonsterPath.Pause();
            }
        }
    
        
        
        

    }
}
