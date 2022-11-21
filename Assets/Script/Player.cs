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

    Transform self;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Collider2D collider2d;


    bool isMoveable = true;

    bool isClimbable = false;

    float horizontal;

    float faceDrection;

    float climbDrection = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        self = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();

    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && isClimbable && faceDrection*climbDrection >0.0f)
        {
            StartCoroutine("Climb");
            isClimbable = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       Move();
    }

    void Move()
    {
        if (!isMoveable) return;

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        int direction = (int)Input.GetAxisRaw("Horizontal");

        switch (direction)
        {
            case 1:
                spriteRenderer.flipX = false;
                faceDrection = 1.0f;
                break;
            case -1:
                spriteRenderer.flipX = true;
                faceDrection = -1.0f;
                break;
        }      
     
    }

    IEnumerator Climb()
    {
        isMoveable = false;
        rb.simulated = false;
        collider2d.enabled = false;
        for(int i = 0; i < 25; i++)
        {
            self.position += Vector3.up * 0.04f;
            yield return new WaitForFixedUpdate();
        }
        for(int i = 0; i < 25; i++)
        {
            self.position += Vector3.right * 0.04f * climbDrection;
            yield return new WaitForFixedUpdate();
        }
        for(float i = 0; i < 10; i++)
        {
            yield return new WaitForFixedUpdate();
        }

        isMoveable = true;
        rb.simulated = true;
        collider2d.enabled = true;
    }

    public void SetClimb(bool isClimbable)
    {
        this.isClimbable = isClimbable;
    }

    public void SetClimbDrection(float climbDrection)
    {
        this.climbDrection = climbDrection;
    }

}
