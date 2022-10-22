using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.01f, 0 );
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.01f, 0 );
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, 0.05f);
        }
        //if (Input.GetKey(KeyCode.Shift))
        //{
        //    transform.position += new Vector3(0, 0.05f);
        //}

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("clear");
    }
}
