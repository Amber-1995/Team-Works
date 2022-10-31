using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{ 
    [SerializeField]
    float speed;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    float climbSpeed;

    [SerializeField]
    int climbSteps;


    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Collider2D collider2d;

    bool isClimbable = false;


    float faceDrection;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();

    }
    private void Update()
    {
        if (spriteRenderer.flipX)
        {
            faceDrection = -1.0f;
        }
        else
        {
            faceDrection = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&isClimbable)
        {
            StartCoroutine("Climb");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(h * speed, rb.velocity.y);


        int facedirection = (int)Input.GetAxisRaw("Horizontal");

        switch (facedirection)
        {
            case 1:
                spriteRenderer.flipX = false;
                break;
            case -1:
                spriteRenderer.flipX = true;
                break;
        }      
     
    }

    IEnumerator Climb()
    {
        for(int i = 0; i < climbSteps; i++)
        {
            transform.position += Vector3.up * Time.deltaTime * climbSpeed ;
            yield return null;
        }
        for (int i = 0; i < climbSteps; i++)
        {
            transform.position += Vector3.right * Time.deltaTime * climbSpeed * faceDrection;
            yield return null;
        }
    }


    public void SetClimb(bool isClimb)
    {
        isClimbable = isClimb;
    }
}
