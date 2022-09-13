using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ExtraX
{
    public class TestScript : MonoBehaviour
    {
  

        private void Start()
        {
            ActionManager.Instance.Add("Test", fun);
        }


        private void fun(ActionMessage am )
        {
            Debug.Log("99999");
        }

        private void OnDestroy()
        {
            ActionManager.Instance.Remove("Test", fun);
        }


    }

}
