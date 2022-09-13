using ExtraX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ExtraX
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        private static T instance;
        public static T Instance { get { return instance; } }
        public static bool IsInitialized { get { return instance != null; } }

        protected virtual void OnDestroy()
        {
            if(instance == this)
            {
                instance = null;
            }
        }
        public static void Init(string objName)
        {
            if (instance != null) return;

            var gameObj = new GameObject { name = objName };
            instance = gameObj.AddComponent<T>();
            DontDestroyOnLoad(gameObj);
        }

    }
}

