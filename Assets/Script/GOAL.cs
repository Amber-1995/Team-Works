using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAL : MonoBehaviour
{
    [SerializeField] GameObject Goaltext;
    [SerializeField] GameObject GameOvertext;

  
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("GOAL!!");
            Goaltext.SetActive(true);
        }

        if(collision.gameObject.tag == "Robot")
        { 
            Debug.Log("GAMEOVER!");
            GameOvertext.SetActive(true);
        }
    }


}
