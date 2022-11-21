using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotMove : MonoBehaviour
{
    Rigidbody2D rb;
    public int moveSpeed = 2;

    


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void FixedUpdate()
    {
        //velocity: ‘¬“x
        //X•ûŒü‚ÖmoveSpeed•ªˆÚ“®‚³‚¹‚é
        //rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //SceneManager.LoadScene("gameover");
    }

     
}
