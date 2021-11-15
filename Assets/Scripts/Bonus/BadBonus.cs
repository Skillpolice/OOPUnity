using System;
using UnityEngine;
using static UnityEngine.Random;

namespace GeekBrains
{
    public sealed class BadBonus : InteractiveBaseClass, IFlay, IRotation
    {
        PlayerBase _player;

        public event Action<string, Color> OnCaughtPlayerChange = delegate (string str, Color color) { };

        private float _speedRotate;
        private float _lengthFlay;


        private void Awake()
        {
            _lengthFlay = Range(1f, 5f);
            _speedRotate = Range(10f, 50f);
        }

        private void Start()
        {
            _player = FindObjectOfType<PlayerBase>();
        }


        protected override void Interaction()
        {
            OnCaughtPlayerChange.Invoke(gameObject.name, _color);

            Destroy(_player.gameObject);
        }

        public override void Execute()
        {
            if (!IsInteractable)
            {
                return;
            }

            Flay();
            Rotate();

        }

        public void Flay()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _lengthFlay), transform.localPosition.z);
        }

        public void Rotate()
        {
            transform.Rotate(Vector3.up * _speedRotate * Time.deltaTime);
        }


    }
}