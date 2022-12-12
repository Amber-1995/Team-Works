using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RobotMotion : int
{
    CLIMB = 0,
    PUSH = 1,
    DESTORY = 2,
}

public class Robot: MonoBehaviour
{
    public static GameObject instance;

    [SerializeField]
    float speed;

    [HideInInspector]
    public bool[] robotMotionReady = new bool[3];

    [HideInInspector]
    public bool[] robotMotionAction = new bool[3];


    Transform self;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Collider2D collider2d;


    bool isMoveable = true;

    bool isClimbable = false;

    bool activeClimbable = false;

    bool onClimbable = false;

    float climbDrection = 1.0f;

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

    }
    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (!isMoveable) return;

        rb.velocity = new Vector2(speed, rb.velocity.y);

        int direction = 1;

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
        Debug.Log("233");
    }



}
