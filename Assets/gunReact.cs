using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunReact : MonoBehaviour {

    [SerializeField]
    Animator anim;

	void Start () {
        
	}

    private void FixedUpdate()
    {
        anim.SetBool("pullBack", false);
    }

    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Untagged")
            anim.SetBool("pullBack", true);
    }

    private void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Untagged")
            anim.SetBool("pullBack", true);
    }

}
