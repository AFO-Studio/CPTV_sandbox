using UnityEngine;

public class Shoot : MonoBehaviour
{
	public Rigidbody bullet;
	public Transform firePoint;

    private Animator anim;

	void Update()
	{
		if (Input.GetAxis("Fire1") != 0)
            Instantiate(bullet, firePoint.position, firePoint.rotation);
	}
}
