using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton pattern to use global 
// So that we not need multiple instance of the same 
public class GameManager : MonoBehaviour {

    public int level = 1;

    public static GameManager _instance;

    public static GameManager Instance{
        get { return _instance; }
    }

    private void Awake()
    {
        if(_instance == null){

            // if we dont have instance 
            _instance = this;
        }

        // for example if we wont to save data on load
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
