using System;
using Unity.Cinemachine;
using UnityEngine;


public class CameraPlayerZoom : MonoBehaviour
{
    [SerializeField] Transform _player1;
    [SerializeField] Transform _player2;

    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float _maxZoom = 15f;
    [SerializeField] private float _zoomLimiter = 10f;
    [SerializeField] private float _smoothSpeed = 3f;


    private CinemachineCamera _vcam;


    void Awake()
    {
        _vcam = GetComponent<CinemachineCamera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (_player1 == null || _player2 == null)
        {
            return;
        }

        float distance = Vector2.Distance(_player1.position, _player2.position);

        float targetZoom = Mathf.Lerp(minZoom, _maxZoom, distance / _zoomLimiter);

        _vcam.Lens.OrthographicSize = Mathf.Lerp(
                _vcam.Lens.OrthographicSize,
                targetZoom,
                Time.deltaTime * _smoothSpeed
            );
    }
}
