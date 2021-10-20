using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] private Player _player;
    [SerializeField] private float _xOffset, _yOffset, _zOffset;

    private void Update()
    {
        transform.position = _player.transform.position + new Vector3(_xOffset, _yOffset, _zOffset);
        transform.LookAt(_player.transform.position);
    }
}
