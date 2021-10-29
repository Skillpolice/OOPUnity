using UnityEngine;

namespace GeekBrains
{
    public class CameraController : MonoBehaviour
    {

        [SerializeField] private Player _player;

        [SerializeField] private float _xOffset;
        [SerializeField] private float _yOffset;
        [SerializeField] private float _zOffset;

        private void Update()
        {
            transform.position = _player.transform.position + new Vector3(_xOffset, _yOffset, _zOffset);
            transform.LookAt(_player.transform.position);
        }
    }
}

