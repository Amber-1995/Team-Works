using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ExtraX
{
    public class Initializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void RuntimeInit()
        {
            TimerManager.Init("TimerManger");
            ActionManager.Init("ActionManager");
            MouseManager.Init("MouseManager");
        }


       
}
}

