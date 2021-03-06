using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameLogic : MyGenericSingleton<GameLogic>
{

    public Action<float> platformQueue;

    public void ExecutePlatformJump(float force)
    {
        platformQueue?.Invoke(force);
    }

}
