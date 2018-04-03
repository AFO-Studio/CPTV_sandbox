using UnityEngine;

public class GunReact : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

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
