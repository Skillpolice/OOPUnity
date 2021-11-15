using System;
using UnityEngine;
using UnityEngine.UI;

namespace GeekBrains
{
    public sealed class DisplayBonuses
    {
        private Text _bonusText;

        public DisplayBonuses(GameObject bonus)
        {
            _bonusText = bonus.GetComponentInChildren<Text>();
            _bonusText.text = String.Empty;
        }

        public void Display(int value)
        {
            _bonusText.text = $"Score {value}";
        }
    }
}


