using Assets.Scripts.Singleton;
using UnityEngine;

namespace Assets.Project.Scripts.Manager
{
    public class HeartManager : MonoBehaviour
    {
        
        void Awake()
        {
            
            
        }
	
        // Update is called once per frame
        void Update () 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Player.Instance.State = "Alert";
                StateManager.Instance.UpdateState(Model.State.Heart);
                SoundManager.Instance.Refresh();
            }
        }


    }
}
