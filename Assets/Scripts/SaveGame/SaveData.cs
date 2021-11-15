using UnityEngine;

namespace GeekBrains
{
    public sealed class SaveData<T> where T : struct
    {
        public int _countBonuses;
        public static T _IdPlayer = default;
    }
}

