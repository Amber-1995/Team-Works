using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
    public static GameObject instance;

    //アニメーションで使用する変数
   public static Animator anim;

    [SerializeField]
    float speed;

    Transform self;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Collider2D collider2d;


    bool isMoveable = true;

    float horizontal;

    

    private void Awake()
    {
        if (instance == null)
        {
            instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
      
        self = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2d = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        
    }

    

    // Update is called once per frame
    void FixedUpdate()
    {
        if (horizontal != 0)
        {
           anim.SetBool("isWalk", true);
           anim.SetBool("isPush", false);
        }
        else
        {
           anim.SetBool("isWalk", false);
            //anim.SetBool("isPush", true);
        }

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
                break;
            case -1:
                spriteRenderer.flipX = true;
                break;
        }      
     
    }

    public void Climb()
    {
        isMoveable = !isMoveable;
        rb.simulated = !rb.simulated;
        collider2d.enabled = !collider2d.enabled;
    }

    

}
