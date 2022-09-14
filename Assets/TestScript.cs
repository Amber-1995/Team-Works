using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace ExtraX
{
    public class TestScript : MonoBehaviour
    {
  

        private void OnEnable()
        {
            ActionManager.Add("Test", fun);
        }


        private void fun()
        {
            Debug.Log(InputManager.RightStick);
        }

        private void OnDisable()
        {
            ActionManager.Remove("Test", fun);
        }


    }

}
