using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;


namespace ExtraX
{
    public class ActionMessage
    {
        public Dictionary<string, float> value = new Dictionary<string, float>();
        public Dictionary<string, Vector2> vec2 = new Dictionary<string, Vector2>();
        public Dictionary<string, Vector3> vec3 = new Dictionary<string, Vector3>();
        public Dictionary<string, Vector4> vec4 = new Dictionary<string, Vector4>();
        public Dictionary<string, string> message = new Dictionary<string, string>();
    }
   

    public class ActionManager : Singleton<ActionManager>
    {
        private Dictionary<string, UnityAction<ActionMessage>> actionDic;
        public ActionManager()
        {
            actionDic = new Dictionary<string, UnityAction<ActionMessage>>();
        }

        public void Add(string actionName, UnityAction<ActionMessage> action)
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

        public void Remove(string actionName, UnityAction<ActionMessage> action)
        {
            if(actionDic.ContainsKey(actionName))
            {
                actionDic[actionName] -= action;
            }
        }

        public void Invoke(string actionName, ActionMessage actionMessage)
        {
            actionDic[actionName]?.Invoke(actionMessage);
        }

        
    }
}

