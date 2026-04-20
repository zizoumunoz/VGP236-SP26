using System;
using UnityEngine;

public class ScoringScript : MonoBehaviour
{

    private ScoreHandler _scoreHandler;
    [SerializeField] int _scoreAmount = 0;
    void Start()
    {
        //first set up the score manager    
        _scoreHandler = FindAnyObjectByType<ScoreHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            _scoreHandler.AddPoint(_scoreAmount);
        }
    }


}
