using UnityEngine;

public class PlayerMidpoint : MonoBehaviour
{
    [SerializeField] private Transform _player1;
    [SerializeField] private Transform _player2;
    [SerializeField] public float _smoothSpeed = 5f;

    private float _distance;

    // Update is called once per frame
    void LateUpdate()
    {
        if (_player1 == null || _player2 == null)
        {
            return;
        }

        _distance = Vector2.Distance(_player1.position, _player2.position);
        Vector3 _midpoint = (_player1.position + _player2.position) / 2;

        transform.position = Vector3.Lerp(transform.position, _midpoint, _smoothSpeed);
    }
}
