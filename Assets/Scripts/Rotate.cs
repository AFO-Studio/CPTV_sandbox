using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public Transform target;

    public int speed;

	public bool spinLeft 	= false;
	public bool spinRight 	= false;
	public bool spinUp 		= false;
	public bool spinDown 	= false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.LookAt(target);
		if(spinUp == true)
        	transform.Rotate(Vector3.up * speed * Time.fixedDeltaTime);
		if(spinDown == true)
			transform.Rotate(Vector3.down * speed * Time.fixedDeltaTime);
		if(spinRight == true)
			transform.Rotate(Vector3.right * speed * Time.fixedDeltaTime);
		if(spinLeft == true)
			transform.Rotate(Vector3.left * speed * Time.fixedDeltaTime);

    }
}
