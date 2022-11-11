using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotMove : MonoBehaviour
{
    Rigidbody2D rb;
    public int moveSpeed = 2;

    public enum RoboAiState
    {
        clim,//�o��
        destroy,//�j��
        carry,//�^��
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        /*
        switch (move)
        {
            //�o��
            case 1:

            //�j��
            case 2:
        �@�@//�^��
            case 3:
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void FixedUpdate()
    {
        //velocity: ���x
        //X������moveSpeed���ړ�������
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("gameover");
    }

     
}
