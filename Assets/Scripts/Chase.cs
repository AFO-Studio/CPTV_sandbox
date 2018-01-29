using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Chase : MonoBehaviour 
{
	NavMeshAgent agent;
	public Transform player;
    public Transform IdleHome;

    private float timer;
    public float speed = 0.05f;
    public float distanceFromTarget = 10;

	private Animator anim;
    public float directionChangeInterval = 1;
    public float maxHeadingChange = 30;
    float heading;
    Vector3 targetRotation;

    void Awake()
    {
        // Set random initial rotation
        heading = Random.Range(0, 360);
        transform.eulerAngles = new Vector3(0, heading, 0);

        StartCoroutine(NewHeading());
    }

    void Start()
	{
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();

       
    }
void Update()
	{


    Vector3 direction = player.position - transform.position;

		//float angle = Vector3.Angle (direction, transform.forward);

        if (Vector3.Distance(player.position, transform.position) > distanceFromTarget)
        {
            transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, targetRotation, Time.deltaTime * directionChangeInterval);
		    //var forward = transform.TransformDirection(Vector3.forward);
            //agent.SetDestination(IdleHome.position);
        }

        if (Vector3.Distance (player.position, transform.position) < distanceFromTarget)
		{
            direction.y = 180;
			anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            agent.SetDestination(player.position);
        }
		else
		{
            transform.position += transform.forward * 0 * Time.deltaTime;
            anim.SetBool("isIdle", true);
			anim.SetBool("isWalking", false);
		 	anim.SetBool("isAttacking", false);
		}

		
	}
    IEnumerator NewHeading()
    {
        while (true)
        {
            NewHeadingRoutine();
            yield return new WaitForSeconds(directionChangeInterval);
        }
    }
    void NewHeadingRoutine()
    {
        var floor = transform.eulerAngles.y - maxHeadingChange;
        var ceil = transform.eulerAngles.y + maxHeadingChange;
        heading = Random.Range(floor, ceil);
        targetRotation = new Vector3(0, heading, 0);
    }
}
