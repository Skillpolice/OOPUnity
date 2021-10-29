using UnityEngine;

namespace GeekBrains
{
    public class Player : MonoBehaviour
    {
        Rigidbody _rb;

        [SerializeField] public static Player Instance { get; private set; }

        [SerializeField] public float _speed = 3f;

        [Header("Rotation config")]
        [SerializeField] private float rotationSpeed = 250f;
        [SerializeField] private Camera mainCamera;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;

            _rb = GetComponent<Rigidbody>();
        }

        protected void MoveBall()
        {
            //float horizontal = Input.GetAxis("Horizontal");
            //float vertical = Input.GetAxis("Vertical");

            //Vector3 movement = new Vector3(horizontal, 0f, vertical);

            //_rb.AddForce(movement * _speed);


            float inputH = Input.GetAxis("Horizontal");
            float inputV = Input.GetAxis("Vertical");

            Vector3 forward = mainCamera.transform.forward;
            forward.y = 0;
            forward.Normalize();

            Vector3 right = mainCamera.transform.right;
            right.y = 0;
            right.Normalize();

            Vector3 moveDirection = forward * inputV + right * inputH;

            _rb.AddForce(moveDirection * _speed);
        }



    }
}






