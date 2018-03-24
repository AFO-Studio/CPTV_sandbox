using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArmsMotor : MonoBehaviour {


    public Animator anim;
    public GameObject sword;
    public GameObject shotgun;

    public GameObject muzzleFlash1;
    public GameObject muzzleFlash2;

    bool emptyHands;
    [SerializeField]
    float time = 0.0f;

    [SerializeField] private Rigidbody bullet;
    [SerializeField] private Transform firePoint;

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
        else
        {
            emptyHands = true;
        }


        if(emptyHands == false)
        {
            anim.SetBool("isIdleUnarmed", false);
        }
        if (emptyHands == true)
        {
            anim.SetBool("isIdleUnarmed", true);
        }



        //if (emptyHands == true && Input.GetMouseButtonDown(0))
        //{
        //    anim.SetBool("isPunching", true);
        //}
        //else
        //{
        //    anim.SetBool("isPunching", false);
        //}

        

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




        if (shotgun.activeSelf == true && Input.GetAxisRaw("Fire1") != 0)
        {

            StartCoroutine(ShotgunFire());
            StopCoroutine(ShotgunFire());

        }


    }

    IEnumerator ShotgunFire()
    {
        anim.SetBool("isShootShotgun", true);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        muzzleFlash1.SetActive(true);
        muzzleFlash2.SetActive(true);
        yield return new WaitForSeconds(time);

        anim.SetBool("isShootShotgun", false);
        muzzleFlash1.SetActive(false);
        muzzleFlash2.SetActive(false);
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
