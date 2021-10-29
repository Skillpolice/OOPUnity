using UnityEngine;

namespace GeekBrains
{
    public class GameController : MonoBehaviour
    {
        InteractiveBaseClass[] _interactive;

        private void Awake()
        {
            _interactive = FindObjectsOfType<InteractiveBaseClass>();
        }

        private void Update()
        {
            for (int i = 0; i < _interactive.Length; i++)
            {
                var interObj = _interactive[i];

                if (interObj == null)
                {
                    continue;
                }

                if (interObj is IFlay flay)
                {
                    flay.Flay();
                }

                if (interObj is IRotation rotate)
                {
                    rotate.Rotate();
                }

            }
        }
    }
}


