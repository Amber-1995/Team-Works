using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;


namespace ExtraX
{

  
    public class ActionManager : Singleton<ActionManager>
    {
        private static Dictionary<string, UnityAction> actionDic;
        public ActionManager()
        {
            actionDic = new Dictionary<string, UnityAction>();
        }

        public static void Add(string actionName, UnityAction action)
        {
            if (!actionDic.ContainsKey(actionName))
            {
                actionDic[actionName] = action;
            }
            else
            {
                actionDic[actionName] += action;
            }
        }

        public static void Remove(string actionName, UnityAction action)
        {
            if(actionDic.ContainsKey(actionName))
            {
                actionDic[actionName] -= action;
            }
        }

        public static void Invoke(string actionName)
        {
            actionDic[actionName]?.Invoke();
        }

        
    }
}

