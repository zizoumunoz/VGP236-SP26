using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;
    [SerializeField] Collider2D _killVolume;

    public void Activate()
    {
        animator.SetTrigger("Open");
        _killVolume.enabled = false;
    }

    public void Deactivate()
    {
        animator.SetTrigger("Close");
        _killVolume.enabled = true;
    }
}
