using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;

    public void Activate()
    {
        animator.SetTrigger("Open");
    }

    public void Deactivate()
    {
        animator.SetTrigger("Close");
    }
}
