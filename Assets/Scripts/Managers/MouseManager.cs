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

        private MouseButtonActionSetting mouseButtonActionSetting;
        private ScrollWheelActionSetting scrollWheelActionSetting;

        private ActionMessage actionMessage;


        private void Awake()
        {
            actionMessage = new ActionMessage();

            mouseButtonActionSetting = AssetDatabase.LoadAssetAtPath<MouseButtonActionSetting>(@"Assets/Settings/MouseActionSettings/MouseButtonActionSetting.asset");
            scrollWheelActionSetting = AssetDatabase.LoadAssetAtPath<ScrollWheelActionSetting>(@"Assets/Settings/MouseActionSettings/ScrollWheelActionSetting.asset");
        }
        
        private void Update()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            actionMessage.value["ScrollWheel"] = Input.GetAxis("Mouse ScrollWheel");
            actionMessage.vec2["CursorPosition"] = Input.mousePosition;

            if(Physics.Raycast(ray, out hit))
            {
                actionMessage.vec3["HitPosition"] = hit.point;

                actionMessage.message["Tag"] = hit.collider.tag;
            }
            

            ProcessMouseButtonAction();

            ProcessScrollWheelAction();
        }

        private void ProcessMouseButtonAction()
        {
            foreach( var actionTrigger in mouseButtonActionSetting.actionTriggers)
            {
                if(ProcessTriggerSet(actionTrigger.triggerSet))
                {
                    ActionManager.Instance.Invoke(actionTrigger.actionName,actionMessage);
                }
            }
        }


        private bool ProcessTriggerSet(List<MouseTrigger> triggerSet)
        {
            foreach (var trigger in triggerSet)
            {
                if(!ProcessTrigger(trigger)) return false;
            }
            return true;
        }

        private bool ProcessTrigger(MouseTrigger trigger)
        {
            switch(trigger.buttonState)
            {
                case ButtonState.Down:
                    return Input.GetMouseButtonDown((int)trigger.mouseButton);
                case ButtonState.Up:
                    return Input.GetMouseButtonUp((int)trigger.mouseButton);
                case ButtonState.Hold:
                    return Input.GetMouseButton((int)trigger.mouseButton);
            }
            return false;
        }

        private void ProcessScrollWheelAction()
        {
            if( actionMessage.value["ScrollWheel"] != 0.0f)
            {
                foreach( var actionName in scrollWheelActionSetting.actions)
                {
                    ActionManager.Instance.Invoke(actionName,actionMessage);
                }
            }
        }
    }
}

