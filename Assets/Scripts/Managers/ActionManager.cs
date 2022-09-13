using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor;


namespace ExtraX
{
    
    public class ActionMessage
    {
        public float value;
        public Vector2 axis;
        public Vector2 position2d;
        public Vector3 position3d;
        public string Message;
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

        public void Invoke(string actionName)
        {
            actionDic[actionName]?.Invoke(new ActionMessage());
        }

        public void Invoke(string actionName, ActionMessage actionMessage)
        {
            actionDic[actionName]?.Invoke(actionMessage);
        }

        
    }
}

