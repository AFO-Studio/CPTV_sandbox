using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {

  Light flashLight;
  
	void Start ()
  {
    flashLight = GetComponent<Light>();
	}

	void Update ()
  {
    if (Input.GetKeyDown(KeyCode.Tab) || Input.GetButtonDown("X"))
    {
      flashLight.enabled = !flashLight.enabled;
    }
	}
}
