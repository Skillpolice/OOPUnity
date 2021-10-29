using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GeekBrains
{
    public sealed class GoodBonus : InteractiveBaseClass, IFlay, IRotation
    {
        LevelManager _manager;

        [Header("Bonus Ball")]
        [SerializeField] private float _speedBall = 1f;

        private float _speedRotate;
        private float _lengthFlay;

        private int _blockCount = 0;

        private void Awake()
        {
            _lengthFlay = Random.Range(1f, 5f);
            _speedRotate = Random.Range(10f, 50f);

            _manager = new LevelManager();
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
            //Add bonus
            Player.Instance._speed += _speedBall;

            _blockCount++;
            if(_blockCount >= 2)
            {
                _manager.Display(1);
                SceneManager.LoadScene(0);
            }
        }

    }
}