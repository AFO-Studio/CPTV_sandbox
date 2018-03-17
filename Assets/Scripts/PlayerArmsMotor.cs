using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmsMotor : MonoBehaviour {


    public Animator anim;
    public GameObject sword;
    public GameObject shotgun;

    bool emptyHands;

	
	void Start ()
    {
        anim.SetBool("isIdleUnarmed", true);
    }
	
	
	void Update ()
    {
		if(sword.activeSelf == true 
            || shotgun.activeSelf == true)
        {
            emptyHands = false;
        }


        if(emptyHands == false)
        {
            anim.SetBool("isIdleUnarmed", false);
        }
        if (emptyHands == true)
        {
            anim.SetBool("isIdleUnarmed", true);
        }



        if (emptyHands == true && Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isPunching", true);
        }
        else
        {
            anim.SetBool("isPunching", false);
        }

        

        if (sword.activeSelf == true && Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isStabbingSword", true);
        }
        else
        {
            anim.SetBool("isStabbingSword", false);
        }



        if (shotgun.activeSelf == true)
        {
            anim.SetBool("isIdleShotgun", true);
        }
        else
        {
            anim.SetBool("isIdleShotgun", false);
        }




        if (shotgun.activeSelf == true && Input.GetMouseButtonDown(0))
        {
            anim.SetBool("isShootShotgun", true);
        }
        else
        {
            anim.SetBool("isShootShotgun", false);
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
