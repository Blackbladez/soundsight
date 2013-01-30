using Assets.Scripts.Singleton;
using UnityEngine;

namespace Assets.Project.Scripts.Manager
{
    public class HeartManager : MonoBehaviour
    {

        private float snapshotOfRunTime;
        private float snapshotOfChaseTime;
        private float snapshotOfRestTime;

        void Awake()
        {
            
            
        }
	
        // Update is called once per frame
        void Update () 
        {

            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                if (snapshotOfRunTime == 0)
                {
                    snapshotOfRunTime = Time.time + 1;
                }
                else if(snapshotOfRunTime < Time.time)
                {
                    snapshotOfRunTime = Time.time + 1;
                    if (Player.Instance.HeartHealth < 100)
                        Player.Instance.HeartHealth = Player.Instance.HeartHealth +  1;
                }
                
                //Player.Instance.State = "Alert";
                snapshotOfRestTime = 0;
                StateManager.Instance.UpdateState(Model.State.Heart);
                SoundManager.Instance.Refresh();
            }

            if(Player.Instance.IsChased)
            {
                if (snapshotOfChaseTime == 0)
                {
                    snapshotOfChaseTime = Time.time + 1;
                }
                else if(snapshotOfChaseTime < Time.time)
                {
                    snapshotOfChaseTime = Time.time + 1;
                    if (Player.Instance.HeartHealth < 100)
                        Player.Instance.HeartHealth = Player.Instance.HeartHealth + 1;
                }
                snapshotOfRestTime = 0;
                StateManager.Instance.UpdateState(Model.State.Heart);
                SoundManager.Instance.Refresh();
                //Debug.Log("It's going to fuck you with a rake.");
            }

            if (!Player.Instance.IsChased && !Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.RightShift))
            {
                if (snapshotOfRestTime == 0)
                {
                    snapshotOfRestTime = Time.time + 1;
                }
                else if(snapshotOfRestTime < Time.time)
                {
                    snapshotOfRestTime = Time.time + 1;
                    if (Player.Instance.HeartHealth > 0)
<<<<<<< HEAD
                        Player.Instance.HeartHealth = Player.Instance.HeartHealth - 1;
=======
                        Player.Instance.HeartHealth = Player.Instance.HeartHealth + 1;
>>>>>>> commit this shit
                }
                snapshotOfChaseTime = 0;
                snapshotOfRunTime = 0;
                StateManager.Instance.UpdateState(Model.State.Heart);
                SoundManager.Instance.Refresh();
            }
        }
    }
}
