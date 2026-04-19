using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{

    [SerializeField] private float _speed = 2f;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;

    private bool goingToB = true;

    void Update()
    {
        // set target to B if going to B, or A if not going to A
        Transform target = goingToB ? pointB : pointA;

        // Move object towards point by an increment of _speed (adjusting for computer time)
        transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        // if gameojbect is withing a very small distance of the target point, change the target point
        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            goingToB = !goingToB;
        }
    }
}
