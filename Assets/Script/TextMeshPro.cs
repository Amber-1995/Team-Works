using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro; // TextMeshPro���g���ꍇ

public class TextMeshPro : MonoBehaviour
{
    /*
    public float speed;
    private float time;
    private TextMeshProUGUI text; // TextMeshPro���g���ꍇ
    */

    public float speed = 1.0f;
    private Text text;
    private float time;

    void Start()
    {
        // text = gameObject.GetComponent<TextMeshProUGUI>();
        text = this.gameObject.GetComponent<Text>();
        //time = 0;
    }

   
    void Update()
    {
        /*
        Color color = text.color;
        time += Time.deltaTime * speed;
        // Mathf.Sin()��-1�`1��Ԃ�
        // color��0�`1�Ŏw�肷��
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;
        text.color = color;
        */
        
        text.color = GetAlphaColor(text.color);

    }

    Color GetAlphaColor(Color color)
    {
        time += Time.deltaTime * 4.0f * speed;
        color.a = Mathf.Sin(time);

        if(Input.GetKeyUp("space"))
        {
            Debug.Log("hello");
            time += Time.deltaTime * 20.0f * speed;
        }

        return color;
    }
}
