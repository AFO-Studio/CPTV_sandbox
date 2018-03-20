using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
	public Rigidbody bullet;
	public Transform firePoint;

    Animator anim;
	void Start()
	{
	}

	void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{
            Instantiate(bullet, firePoint.position, firePoint.rotation);
		}
	}
}
