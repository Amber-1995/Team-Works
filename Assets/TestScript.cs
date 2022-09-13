using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ExtraX
{
    public class TestScript : MonoBehaviour
    {
        Timer timer;

        private void Awake()
        {
            timer = new Timer();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space)&& timer.IsElapse(1.0d))
            {
                Debug.Log("23333");
                timer.Start();
            }
        }
    }

}
