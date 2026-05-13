using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private int _collisionCount = 0;
    public bool IsGrounded
    {
        get
        {
            return _collisionCount > 0;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        ++_collisionCount;
    }

    public void OnTriggerExit(Collider other)
    {
        --_collisionCount;
    }
}
