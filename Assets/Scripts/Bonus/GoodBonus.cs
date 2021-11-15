using System;
using UnityEngine;
using static UnityEngine.Random;

namespace GeekBrains
{
    public sealed class GoodBonus : InteractiveBaseClass, IFlay, IRotation, IFlicker
    {
        private PlayerBase _player;
        private Material _material;

        public event Action<int> OnPointChange = delegate (int i) { };

        [Header("Bonus Ball")]
        [SerializeField, Range(1, 10)] private float _speedBall = 1f;

        public int _point;
        private float _speedRotate;
        private float _lengthFlay;

        private void Awake()
        {
            _material = GetComponent<Renderer>().material;

            _lengthFlay = Range(1f, 5f);
            _speedRotate = Range(5f, 10f);
        }

        private void Start()
        {
            _player = FindObjectOfType<PlayerBase>(); //Затратно
        }

        protected override void Interaction() //Add bonus
        {
            _player._speedBase += _speedBall;
            OnPointChange.Invoke(_point);
        }

        public override void Execute()
        {
            if (!IsInteractable)
            {
                return;
            }

            Flay();
            Flicker();
            Rotate();
        }


        public void Flicker()
        {
            _material.color = new Color(_material.color.r, _material.color.g, _material.color.b, Mathf.PingPong(Time.time, 1f));
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