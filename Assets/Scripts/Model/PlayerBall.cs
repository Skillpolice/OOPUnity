using UnityEngine;

namespace GeekBrains
{
    public sealed class PlayerBall : PlayerBase
    {
        private Rigidbody _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public override void Move(float x, float y, float z)
        {
            _rb.AddForce(new Vector3(x, y, z) * _speedBase);
        }


    }
}



