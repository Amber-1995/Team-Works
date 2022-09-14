using System.Collections.Generic;
using UnityEngine;



namespace ExtraX
{
    public enum MouseButton : int
    {
        LeftClick = 0,
        RightClick = 1,
        MiddleClick = 2,
    }

    public enum ButtonState : int
    {
        Down = 0,
        Up = 1,
        Hold =2,
    }

    [System.Serializable]
    public class MouseTrigger
    {
        public MouseButton mouseButton;
        public ButtonState buttonState;
    }

    [System.Serializable]
    public class MouseActionTrigger
    {
        public string actionName;
        public List<MouseTrigger> triggerSet;
    }

    [CreateAssetMenu(menuName = "ExtraX/MouseButtonActionSetting")]
    public class MouseButtonActionSetting : ScriptableObject
    {
        public List<MouseActionTrigger> actionTriggers;
    }

}

