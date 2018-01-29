using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmsMotor : MonoBehaviour {


    public Animator anim;
    public GameObject sword;

    bool Activate;

	// Use this for initialization
	void Start ()
    {
        anim.SetBool("isIdleUnarmed", true);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(sword.activeSelf == true)
        {
            anim.SetBool("isIdleUnarmed", false);

        }
        if (sword.activeSelf == false && Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isPunching", true);
        }
        else
        {
            anim.SetBool("isPunching", false);
        }

        

        if (sword.activeSelf == false)
        {
            anim.SetBool("isIdleUnarmed", true);
        }

        if (sword.activeSelf == true && Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isStabbingSword", true);
        }
        else
        {
            anim.SetBool("isStabbingSword", false);
        }
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Untagged")
        {
            anim.SetBool("HitDeWall", true);
        }

    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Untagged")
        {
            anim.SetBool("HitDeWall", false);
        }

    }
}
