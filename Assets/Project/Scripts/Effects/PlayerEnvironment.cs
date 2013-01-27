using UnityEngine;
using System.Collections;
using Assets.Scripts.Singleton;

public class PlayerEnvironment : MonoBehaviour
{
    public float Proximity = 25;
    public Color WallColor = Color.white;
    public Material SightMaterial;
    public Material SightGroundMaterial;

	// Use this for initialization
	void Start () 
    {
        if(SightMaterial == null)
            Debug.LogError("Sight Material has nothing attached!");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Proximity))
        {
            if(hit.collider.gameObject.tag=="Wall")
            {
                SightMaterial.SetColor("_Color", Color.Lerp(WallColor, Color.black, Mathf.Cos(Time.time * Player.Instance.Sensitivity)));
                SightGroundMaterial.SetColor("_Color", Color.Lerp(WallColor, Color.black, Mathf.Cos(Time.time * Player.Instance.Sensitivity)));
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
            Debug.Log("Player lost");
        }
    }
}
