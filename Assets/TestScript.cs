using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ExtraX
{
    public class TestScript : MonoBehaviour
    {
        Timer timer;
        void Awake()
        {
            timer = TimerManager.Instance.CreaterTimer();
            timer.Add("Test", 1.0f);
            ActionManager.Instance.Add("Test", fun);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space) && timer.IsItDone("Test"))
            {
                Debug.Log("2333");
                ActionManager.Instance.Invoke("Test");
                timer.Countdown("Test");
            }
        }

        void fun(ActionMessage am)
        {
            Debug.Log("aaaaaaa");
        }

        private void OnDestroy()
        {
            timer.Destroy();
            ActionManager.Instance?.Remove("Test", fun);
        }
    }

}
