using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NewTitleMove : MonoBehaviour
{
    


    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {

            {
                Invoke("A", 3.0f);
                //SceneManager.LoadScene("test3");
            }
        }

    }
    private void A()
    {
        SceneManager.LoadScene("test3");
    }

}

