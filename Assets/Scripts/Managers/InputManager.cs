using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



namespace ExtraX
{
    public class InputManager : Singleton<InputManager>
    {
        public static float ScrollWheelValue { get { return 0.0f; } }

        public static RaycastHit? CursorHit { get { return nullableHit; } }

        public static Vector3 CursorPosition { get { return cursorPositin; } }

        public static Vector3 LeftStick { get { return leftStick; } }

        public static Vector3 RightStick { get { return rightStick; } }

        public static Vector3 Acceleration { get { return acceleration; } }

        private static KeyActionSetting keyActionSetting;

        private static ActionSetting scrollWheelActionSetting;

        private static ActionSetting leftStickActionSetting;

        private static ActionSetting rightStickActionSetting;

        private static float scrollWheelValue;

        private static Ray ray;

        private static RaycastHit hit;

        private static RaycastHit? nullableHit;

        private static Vector3 cursorPositin;

        private static Vector3 leftStick;

        private static Vector3 rightStick;

        private static Vector3 acceleration;


        private void Awake()
        {
            keyActionSetting = AssetDatabase.LoadAssetAtPath<KeyActionSetting>(@"Assets/Settings/InputActionSettings/KeyActionSetting.asset");

            scrollWheelActionSetting = AssetDatabase.LoadAssetAtPath<ActionSetting>(@"Assets/Settings/InputActionSettings/ScrollWheelActionSetting.asset");

            leftStickActionSetting = AssetDatabase.LoadAssetAtPath<ActionSetting>(@"Assets/Settings/InputActionSettings/LeftStickActionSetting.asset");

            rightStickActionSetting = AssetDatabase.LoadAssetAtPath<ActionSetting>(@"Assets/Settings/InputActionSettings/RightStickActionSetting.asset");
        }
        
        private void Update()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            scrollWheelValue = Input.GetAxis("Mouse ScrollWheel");

            if (Physics.Raycast(ray, out hit))
            {
                nullableHit = hit;
            }
            else
            {
                nullableHit = null;
            }

            cursorPositin = Input.mousePosition;

            leftStick = new Vector3(Input.GetAxis("Left Stick Horizontal"), 0.0f, Input.GetAxis("Left Stick Vertical"));

            rightStick = new Vector3(Input.GetAxis("Right Stick Horizontal"), 0.0f, Input.GetAxis("Right Stick Vertical"));

            acceleration = Input.acceleration;

            ProcessKeyAction();

            ProcessScrollWheelAction();

            ProcessLeftStickAction();

            ProcessRightStickAction();
        }

        private static void ProcessKeyAction()
        {
            foreach( var actionTrigger in keyActionSetting.actionTriggers)
            {
                if(ProcessTriggerSet(actionTrigger.triggerSet))
                {
                    ActionManager.Invoke(actionTrigger.actionName);
                }
            }
        }


        private static bool ProcessTriggerSet(List<MouseTrigger> triggerSet)
        {
            foreach (var trigger in triggerSet)
            {
                if(!ProcessTrigger(trigger)) return false;
            }
            return true;
        }

        private static bool ProcessTrigger(MouseTrigger trigger)
        {
            switch(trigger.buttonState)
            {
                case KeyState.Down:
                    return Input.GetKeyDown(trigger.keyCode);
                case KeyState.Up:
                    return Input.GetKeyUp(trigger.keyCode);
                case KeyState.Hold:
                    return Input.GetKey(trigger.keyCode);
            }
            return false;
        }

        private static void ProcessScrollWheelAction()
        {
            if(scrollWheelValue != 0.0f)
            {
                foreach(var actionName in scrollWheelActionSetting.actions)
                {
                    ActionManager.Invoke(actionName);
                }
            }
        }

        private static void ProcessLeftStickAction()
        {
            if (leftStick.sqrMagnitude != 0.0f)
            {
                foreach (var actionName in leftStickActionSetting.actions)
                {
                    ActionManager.Invoke(actionName);
                }
            }
        }

        private static void ProcessRightStickAction()
        {
            if (rightStick.sqrMagnitude != 0.0f)
            {
                foreach (var actionName in rightStickActionSetting.actions)
                {
                    ActionManager.Invoke(actionName);
                }
            }
        }
    }
}

