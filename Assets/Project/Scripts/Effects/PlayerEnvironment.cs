using Assets.Project.Scripts.Manager;
using Assets.Project.Scripts.Model;
using UnityEngine;
using System.Collections;
using Assets.Scripts.Singleton;

public class PlayerEnvironment : MonoBehaviour
{
    public float Proximity = 25;
    public Color WallColor = Color.white;
    public Material SightMaterial;
    public Material SightGroundMaterial;
    private CharacterController cc;
    private Vector3 initialPos;

	// Use this for initialization
	void Start () 
    {
        if(SightMaterial == null)
            Debug.LogError("Sight Material has nothing attached!");
	    cc = gameObject.GetComponent<CharacterController>();

        initialPos = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
	{
        if(Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            cc.stepOffset = 1;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
        {
            cc.stepOffset = .4f;
        }

<<<<<<< HEAD
=======

        Debug.Log("Intensity levels 2 dam high: " + Player.Instance.Sensitivity);
        //SightMaterial.SetColor("_Color", Color.Lerp(WallColor, Color.black, Mathf.Cos(Time.time * Player.Instance.Sensitivity)));
        //SightGroundMaterial.SetColor("_Color", Color.Lerp(WallColor, Color.black, Mathf.Cos(Time.time * Player.Instance.Sensitivity)));

>>>>>>> commit this shit
	    RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Proximity))
        {
            if(hit.collider.gameObject.tag=="Wall")
            {
<<<<<<< HEAD
                SightMaterial.SetColor("_Color", Color.Lerp(WallColor, Color.black, Mathf.Cos(Time.time * Player.Instance.Sensitivity)));
                SightGroundMaterial.SetColor("_Color", Color.Lerp(WallColor, Color.black, Mathf.Cos(Time.time * Player.Instance.Sensitivity)));
=======
                
>>>>>>> commit this shit
            }
                
        }
        else
        {
            SightMaterial.SetColor("_Color", Color.black);
        }
	}

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "WinBox")
        {
            Debug.Log("Player wins");
        }
        if(hit.collider.gameObject.tag == "Monster")
        {
           transform.position = initialPos;
            Player.Instance.IsChased = false;
            Player.Instance.HeartHealth = 1;
            StateManager.Instance.UpdateState(State.Heart);
            StartCoroutine(PlayDead());
        }
    }

    IEnumerator PlayDead()
    {
        SoundManager.Instance.YoureFuckingDead(true);
        yield return new WaitForSeconds(6);
        SoundManager.Instance.YoureFuckingDead(false);
    }
}
