using UnityEngine;

public class PickupScript : MonoBehaviour
{

    private ScoreHandler _scoreHandler;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get the scoreHandler so we can add points to it
        _scoreHandler = FindAnyObjectByType<ScoreHandler>();
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            _scoreHandler.AddPoint(10);
            Destroy(gameObject);
        }
    }
}
