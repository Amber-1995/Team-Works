using ExtraX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ExtraX
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        protected static T instance;
        public static void Init(string name)
        {
            if (instance != null) return;

            var gameObj = new GameObject { name = name };
            instance = gameObj.AddComponent<T>();
            DontDestroyOnLoad(gameObj);
        }

    }
}

