using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour 
{
    public GameObject Player;
    public AudioClip StoryClip;
    public float RenderProximity;
    public float StoryProximity;
    private AudioSource StorySource;
    private bool rendered = false;
    private bool playedStory = false;

	// Use this for initialization
	void Start ()
	{
	    renderer.enabled = false;
	    StorySource = gameObject.AddComponent<AudioSource>();
	    StorySource.clip = StoryClip;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(Vector3.Distance(Player.transform.position, transform.position) <= RenderProximity && !renderer)
        {
            renderer.enabled = true;
            rendered = true;
        }
        if(Vector3.Distance(Player.transform.position, transform.position) <= StoryProximity && !playedStory)
        {
            StorySource.Play(3);
            playedStory = true;
        }
        if(rendered && playedStory)
        {
            renderer.enabled = false;
        }
	}
}
