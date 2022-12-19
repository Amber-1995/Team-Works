using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GOAL : MonoBehaviour
{
    [SerializeField]
    GameObject goal;

    [SerializeField]
    GameObject gameOver;

    [SerializeField]
    GameObject menu;


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("GOAL!!");
            goal.SetActive(true);
            menu.SetActive(true);
            Player.instance.GetComponent<Player>().enabled = false;
            Robot.instance.GetComponent<Robot>().enabled = false;
            //SceneManager.LoadScene("clear");
        }

        if(collision.gameObject.tag == "Robot")
        { 
            Debug.Log("GAMEOVER!");
            gameOver.SetActive(true);
            menu.SetActive(true);
            Player.instance.GetComponent<Player>().enabled = false;
            Robot.instance.GetComponent<Robot>().enabled = false;
            // SceneManager.LoadScene("gameover");
        }
    }

    public void ToTitle()
    {
        SceneManager.LoadScene("title");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
