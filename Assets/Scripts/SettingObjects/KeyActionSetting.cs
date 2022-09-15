using System.Collections.Generic;
using UnityEngine;



namespace ExtraX
{


    public enum KeyState
    {
        Down = 0,
        Up = 1,
        Hold =2,
    }

    [System.Serializable]
    public class MouseTrigger
    {
        public KeyCode keyCode;
        public KeyState buttonState;
    }

    [System.Serializable]
    public class ActionTrigger
    {
        public string actionName;
        public List<MouseTrigger> triggerSet;
    }

    [CreateAssetMenu(menuName = "ExtraX/KeyActionSetting")]
    public class KeyActionSetting : ScriptableObject
    {
        public List<ActionTrigger> actionTriggers;
    }

}

