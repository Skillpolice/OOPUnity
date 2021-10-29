using UnityEngine;

namespace GeekBrains
{
    public sealed class BadBonus : InteractiveBaseClass, IFlay, IRotation
    {
        private float _speedRotate;
        private float _lengthFlay;

        private void Awake()
        {
            _lengthFlay = Random.Range(1f, 5f);
            _speedRotate = Random.Range(10f, 50f);
        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * _speedRotate * Time.deltaTime);
        }

        protected override void Interaction()
        {
            Destroy(Player.Instance.gameObject);
        }

        

    }
}