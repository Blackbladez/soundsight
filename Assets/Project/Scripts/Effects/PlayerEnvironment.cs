using UnityEngine;
using System.Collections;
using Assets.Scripts.Singleton;

public class PlayerEnvironment : MonoBehaviour
{
    public float Proximity = 25;
    public Color WallColor = Color.white;
    public Material SightMaterial;

	// Use this for initialization
	void Start () 
    {
        if(SightMaterial == null)
            Debug.LogError("Sight Material has nothing attached!");
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 forward = transform.TransformDirection(Vector3.forward);
        if(Physics.Raycast(transform.position, forward, Proximity))
        {
            SightMaterial.SetColor("_Color", Color.Lerp(WallColor, Color.black, Mathf.Cos(Time.time * 8)));
            //Debug.Log("Hit something");
        }
	}
}
