﻿using System.Collections;
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

		if (Input.GetAxis("Fire1") != 0)
		{
            Instantiate(bullet, firePoint.position, firePoint.rotation);
		}
	}
}
