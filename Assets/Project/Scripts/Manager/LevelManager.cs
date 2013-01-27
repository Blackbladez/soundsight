using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject Player;
    private static LevelManager instance;


    public static LevelManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance == null) instance = this;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
