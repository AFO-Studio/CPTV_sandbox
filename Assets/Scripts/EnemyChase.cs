using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;
    private float minDistance = 3f;
    private float range;

    void Update()
    {
        range = Vector2.Distance(transform.position, target.position);

        if (range > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (range < minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -1 * speed * Time.deltaTime);
        }

    }
}