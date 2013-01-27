using Assets.Project.Scripts.Manager;
using Assets.Project.Scripts.Model;
using Assets.Scripts.Singleton;
using UnityEngine;
namespace Assets.Project.Scripts.Behavior
{
    public class MonsterBehavior : MonoBehaviour
    {
        public float Proximity;
        public float Speed = 0.00000000000001f;
        private hoMove MonsterPath;
        private Rigidbody rigidBody;
        private bool IsMoving;


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
                    Player.Instance.IsChased = true;
                    Vector3 facing = LevelManager.Instance.Player.transform.position - transform.position;
                    //rigidBody.velocity = facing.normalized * Speed;
                    rigidBody.velocity = facing.normalized * Speed;
                    //Debug.Log("F=ma is" + this.transform.TransformDirection(LevelManager.Instance.Player.transform.localPosition));
                    //rigidBody.AddForce(this.transform.TransformDirection(LevelManager.Instance.Player.transform.localPosition));
                    //rigidBody.velocity = Vector3.forward;
                }
                else
                {
                    MonsterPath.Resume();
                    Player.Instance.IsChased = false;
                }
	        }

            if (LightManager.Instance.CurrentState == LightState.On)
            {
                // a. when its light on - it stops moving
                MonsterPath.Pause();
                rigidBody.velocity = Vector3.zero;
                Player.Instance.IsChased = false;
            }
        }
    
        
        
        

    }
}
