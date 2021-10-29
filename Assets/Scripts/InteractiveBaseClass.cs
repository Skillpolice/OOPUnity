using UnityEngine;
using UnityEngine.UI;

namespace GeekBrains
{
    public abstract class InteractiveBaseClass : MonoBehaviour
    {
        
        protected abstract void Interaction();

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("trigger");

                Destroy(gameObject);
                Interaction();
            }
        }
    }
}


