using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAL : MonoBehaviour
{
    [SerializeField] GameObject Goaltext;
    [SerializeField] GameObject GameOvertext;

    void Start()
    {
        Goaltext.SetActive(false);
        GameOvertext.SetActive(false);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("GOAL!!");
            Goaltext.SetActive(true);
        }

        if(collision.gameObject.name == "Robot")
        { 
            Debug.Log("GAMEOVER!");
            GameOvertext.SetActive(true);
        }
    }


}
