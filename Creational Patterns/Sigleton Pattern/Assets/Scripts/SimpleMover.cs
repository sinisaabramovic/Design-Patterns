using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMover : MonoBehaviour {

    private int _speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Move(GameManager.Instance.level);
	}

    public void Move(int speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
