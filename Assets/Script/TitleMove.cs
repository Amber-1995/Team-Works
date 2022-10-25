using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleMove : MonoBehaviour
{
    public void Onclick()
    {
        //Debug.Log("‰Ÿ‚µ‚½");
        SceneManager.LoadScene("maingame");
    }
}
