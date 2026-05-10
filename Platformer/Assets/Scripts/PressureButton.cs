using UnityEngine;

public class PressureButton : MonoBehaviour
{
    [SerializeField] private Animator animator;   // for button anim
    [SerializeField] private GameObject targetObject; // object that will be affected

    private int playersOnButton = 0;
    [SerializeField] private int playersNeeded = 1;
    [SerializeField] private string _message = "Activate";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersOnButton++;

            if (playersOnButton >= playersNeeded)
            {
                if (animator != null)
                    animator.SetBool("Pressed", true);

                targetObject.SendMessage(_message, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersOnButton--;

            if (playersOnButton == 0)
            {
                if (animator!= null)
                {
                    animator.SetBool("Pressed", false);
                }

                targetObject.SendMessage("Deactivate", SendMessageOptions.DontRequireReceiver);
            }
        }
    }

}
