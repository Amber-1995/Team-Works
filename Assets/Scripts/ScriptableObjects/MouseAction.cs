using UnityEngine;



namespace ExtraX
{
    public enum MouseButton : int
    {
        RightClick = 0,
        LeftClick = 1,
        MiddleClick = 2,
        Count =3,
    }

    [System.Serializable]
    public class MouseButtonBindAction
    {
        public MouseButton mouseButton;
        public string actionName;
    }



    [CreateAssetMenu(menuName = "ExtraX/MouseBottonAction")]
    public class MouseButtonAction : ScriptableObject
    {
        public MouseButtonBindAction[] mouseButtonBindAction;
    }

    [CreateAssetMenu(menuName = "ExtraX/ScrollWheelAction")]
    public class ScrollWheelAction : ScriptableObject
    {
        public string[] action;
    }

}

