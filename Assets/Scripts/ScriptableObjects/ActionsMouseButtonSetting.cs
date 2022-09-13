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

    [System.Serializable]
    public class ActionsMouseButton
    {
        public string actionName;
        public MouseButton mouseButton;
    }

    [CreateAssetMenu(menuName = "ExtraX/ActionsMouseButtonSetting")]
    public class ActionsMouseButtonSetting : ScriptableObject
    {
        public List<ActionsMouseButton> actionsMouseButton;
    }

}

