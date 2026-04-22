using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private ScoreHandler _scoreHandler;

    [Header("Movement Area")]
    public Vector2 areaMin = new Vector2(-4f, -3f);
    public Vector2 areaMax = new Vector2(4f, 3f);

    void Start()
    {
        _scoreHandler = FindAnyObjectByType<ScoreHandler>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            _scoreHandler.AddPoint(10);
            MoveToRandomPosition();
        }
    }

    void MoveToRandomPosition()
    {
        float x = Random.Range(areaMin.x, areaMax.x);
        float y = Random.Range(areaMin.y, areaMax.y);

        transform.position = new Vector2(x, y);
    }
}
