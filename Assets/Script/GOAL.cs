using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GOAL : MonoBehaviour
{


  
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("GOAL!!");
            SceneManager.LoadScene("clear");
        }

        if(collision.gameObject.tag == "Robot")
        { 
            Debug.Log("GAMEOVER!");
            SceneManager.LoadScene("gameover");
        }
    }


}
