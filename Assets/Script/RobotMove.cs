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

        switch (move)
        {
            //ìoÇÈ
            case 1:

            //îjâÛ
            case 2:
        Å@Å@//â^Ç‘
            case 3:
        }
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void FixedUpdate()
    {
        //velocity: ë¨ìx
        //Xï˚å¸Ç÷moveSpeedï™à⁄ìÆÇ≥ÇπÇÈ
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("gameover");
    }

     
}
