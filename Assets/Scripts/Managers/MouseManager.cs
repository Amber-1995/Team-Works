using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ExtraX
{
    public class MouseManager : Singleton<MouseManager>
    {

    

        public string[,] OnMouseButton;
        public string[,] OnMouseButtonUp;
        public string[,] OnMouseButtonDown;


        private Ray ray;
        private RaycastHit hit;

        private void Update()
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                switch(hit.collider.tag)
                {
                    case "":
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
