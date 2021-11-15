using UnityEngine;

namespace GeekBrains
{
    public abstract class PlayerBase : MonoBehaviour
    {

        [Header("Ball config speed")]
        [SerializeField, Range(0, 100)] public float _speedBase;

        public abstract void Move(float x, float y, float z);
    }
}






