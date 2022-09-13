using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



namespace ExtraX
{
    public class MouseManager : Singleton<MouseManager>
    {

        private Ray ray;
        private RaycastHit hit;

        private ActionsMouseButtonSetting OnMouseButton;
        private ActionsMouseButtonSetting OnMouseButtonDown;
        private ActionsMouseButtonSetting OnMouseButtonUp;
        private ScrollWheelActionSetting OnScrollWheelRoll;

        private void Awake()
        {
            OnMouseButton = AssetDatabase.LoadAssetAtPath<ActionsMouseButtonSetting>(@"Assets/Settings/MouseActionSettings/OnMouseButton.asset");
            OnMouseButtonDown = AssetDatabase.LoadAssetAtPath<ActionsMouseButtonSetting>(@"Assets/Settings/MouseActionSettings/OnMouseButtonDown.asset");
            OnMouseButtonUp = AssetDatabase.LoadAssetAtPath<ActionsMouseButtonSetting>(@"Assets/Settings/MouseActionSettings/OnMouseButtonUp.asset");
            OnScrollWheelRoll = AssetDatabase.LoadAssetAtPath<ScrollWheelActionSetting>(@"Assets/Settings/MouseActionSettings/OnScrollWheelRoll");
        }
        
            

        private void Update()
        {
            foreach( var i in OnMouseButton.actionsMouseButton)
            {
                if(Input.GetMouseButton((int)i.mouseButton))
                {
                    ActionManager.Instance.Invoke(i.actionName);
                }
            }

            foreach (var i in OnMouseButtonDown.actionsMouseButton)
            {
                if (Input.GetMouseButtonDown((int)i.mouseButton))
                {
                    ActionManager.Instance.Invoke(i.actionName);
                }
            }

            foreach (var i in OnMouseButtonUp.actionsMouseButton)
            {
                if (Input.GetMouseButtonUp((int)i.mouseButton))
                {
                    ActionManager.Instance.Invoke(i.actionName);
                }
            }
        }
    }
}

