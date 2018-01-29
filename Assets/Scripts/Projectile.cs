using UnityEngine;

public class  Projectile : MonoBehaviour
{
	public float maxSpeed = 25f;
	public Rigidbody projectile;

	void Update()
	{
			projectile.velocity = transform.forward * maxSpeed;
			Physics.IgnoreCollision(projectile.GetComponent<Collider>(), GetComponent<Collider>());
	}
    void OnCollisionExit(Collision col)
    {

        Destroy(gameObject);

        if (col.gameObject.tag == "Untagged")
        {
            Destroy(gameObject);
        }
    }
}
