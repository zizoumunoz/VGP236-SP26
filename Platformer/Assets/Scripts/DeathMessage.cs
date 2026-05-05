using System.Collections;
using TMPro;
using UnityEngine;

public class DeathMessage : MonoBehaviour
{
    // make a globally accessible death message that we can modify
    [SerializeField] public static DeathMessage _instance;

    private TextMeshProUGUI text;

    private void Awake()
    {
        _instance = this;
        text = GetComponent<TextMeshProUGUI>();
    }

    public void ShowMessage(string message, float duration = 1.5f)
    {
        StopAllCoroutines();
        StartCoroutine(ShowRoutine(message, duration));
    }

    private IEnumerator ShowRoutine(string message, float duration)
    {
        text.text = message;

        // Fade in
        text.alpha = 1f;

        // hang on text for a little bit
        yield return new WaitForSeconds(duration);

        text.alpha = 0f;
    }
}
