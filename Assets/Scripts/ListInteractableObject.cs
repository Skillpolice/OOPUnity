using System;
using System.Collections;
using Object = UnityEngine.Object;

namespace GeekBrains
{
    public sealed class ListInteractableObject : IEnumerator, IEnumerable
    {
        private InteractiveBaseClass[] _interactiveObjects;
        private int _index = -1;
        private InteractiveBaseClass _current;

        public ListInteractableObject()
        {
            _interactiveObjects = Object.FindObjectsOfType<InteractiveBaseClass>();
            Array.Sort(_interactiveObjects);
        }

        public InteractiveBaseClass this[int index]
        {
            get => _interactiveObjects[index];
            set => _interactiveObjects[index] = value;
        }

        public int Count => _interactiveObjects.Length;


        public bool MoveNext()
        {
            if (_index == _interactiveObjects.Length - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset() => _index = -1;

        public object Current => _interactiveObjects[_index];

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}
