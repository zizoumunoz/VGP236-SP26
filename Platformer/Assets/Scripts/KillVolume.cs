using System;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    // death message for this specific volume
    [SerializeField] private string _deathMessage = "You died";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerDeath>().Die(_deathMessage);
        }
    }
}
