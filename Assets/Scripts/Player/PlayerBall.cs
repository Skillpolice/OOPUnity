using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerBall : Player
{
    private void FixedUpdate()
    {
        MoveBall();
    }
}

