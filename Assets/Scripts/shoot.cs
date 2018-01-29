using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
	public Rigidbody bullet;
	public Transform firePoint;
    public GameObject Player;

    Animator anim;
	void Start()
	{
        anim = Player.GetComponent<Animator>();
	}

	void Update()
	{

		if (Input.GetMouseButton(0))
		{
            anim.Play("isShooting", -1, 0f);
            Instantiate(bullet, firePoint.position, firePoint.rotation);
		}
	}
}
