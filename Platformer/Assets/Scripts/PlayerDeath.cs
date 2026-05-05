using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Transform _respawnPoint;
    [SerializeField] private PlayerDeath _otherPlayer;




    public void Die(string reason)
    {

        DeathMessage._instance.ShowMessage(reason);

        Respawn();
        _otherPlayer.Respawn();
        
        
    }

    public void Respawn()
    {
        // disable movement script
        GetComponent<PlayerController>().enabled = false;

        transform.position = _respawnPoint.position;

        // enable after respawning
        GetComponent<PlayerController>().enabled = true;
    }
}
