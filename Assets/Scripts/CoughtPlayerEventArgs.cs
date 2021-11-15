using System;
using System.Collections;
using UnityEngine;

namespace GeekBrains
{
    public sealed class CoughtPlayerEventAgrs : EventArgs
    {
        public Color Color { get; }

        public CoughtPlayerEventAgrs(Color color)
        {
            Color = color;
        }
    }
}