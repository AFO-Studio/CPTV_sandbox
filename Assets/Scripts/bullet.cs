using UnityEngine;

public class Bullet : MonoBehaviour {

    public float Speed;

	void Update () {
        gameObject.GetComponent<Rigidbody>().velocity = transform.right * Speed;
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Untagged")
            Destroy(gameObject);
        
    }
}
