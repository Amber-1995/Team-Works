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
            ActionManager.Init("ActionManager");
            InputManager.Init("MouseManager");
        }


       
}
}

