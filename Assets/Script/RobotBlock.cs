using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class RobotBlock : MonoBehaviour
{ 
    [SerializeField]
    float rangeX;

    [SerializeField]
    float rangeY;

    [SerializeField]
    Transform[] matherBlocks;

    [SerializeField]
    bool push;

    [SerializeField]
    bool pull;

    [SerializeField]
    KeyCode ctrlKey = KeyCode.F;

    [SerializeField]
    GameObject[] climbPoints;

    LineRenderer lineRenderer;

    Transform playerTrans;

    Transform self;

    Rigidbody2D rb;

    float x;

    bool onCtrl;

    Animator playerAnimator;


    void Start()
    {
        playerTrans = Player.instance.GetComponent<Transform>();

        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.enabled = false;

        self = GetComponent<Transform>();

        rb = GetComponent<Rigidbody2D>();

        playerAnimator = Player.instance.GetComponent<Animator>();

        x = playerTrans.position.x;

        onCtrl = false;
    }

   
    void Update()
    {
        bool lineEnabled = false;
        foreach(var matherBlock in matherBlocks)
        {
            if (Vector3.Distance(self.position, matherBlock.position) < 1.1f)
            {
                lineRenderer.SetPosition(0, self.position - new Vector3(0.0f, 0.0f, 1.0f));
                lineRenderer.SetPosition(1, matherBlock.position - new Vector3(0.0f, 0.0f, 1.0f));
                lineEnabled |= true;
                Robot.instance.GetComponent<Robot>().robotMotionReady[(int)matherBlock.GetComponent<MatherBlock>().robotMotion] = true;
            }
            else
            {
                lineEnabled |= false;
            }
        }
        lineRenderer.enabled = lineEnabled;



        if (Input.GetKey(ctrlKey) && IsInRange(playerTrans))
        {
            if (!onCtrl)
            {
                self.position += playerTrans.position.x > self.position.x ? Vector3.left * 0.1f : Vector3.right * 0.1f;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation; 
                SetClimbPointsActive(false);
            }
            onCtrl = true;
            playerAnimator.SetBool("isPush", true);
            
        }
        else
        {
            if (onCtrl)
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                SetClimbPointsActive(true);
            }
            onCtrl = false;
            playerAnimator.SetBool("isPush", false);
        }
       
    }

    private void FixedUpdate()
    {
        if (onCtrl)
        {
           
            if (push && x < playerTrans.position.x)
            {
                self.position += Vector3.right * (playerTrans.position.x - x);
            }
            if (pull && x > playerTrans.position.x)
            {
                self.position += Vector3.right * (playerTrans.position.x - x);
            }
        }
        x = playerTrans.position.x;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position + new Vector3(-rangeX, rangeY, 0.0f), transform.position + new Vector3(rangeX, rangeY, 0.0f));
        Gizmos.DrawLine(transform.position + new Vector3(-rangeX, -rangeY, 0.0f), transform.position + new Vector3(rangeX, -rangeY, 0.0f));
        Gizmos.DrawLine(transform.position + new Vector3(rangeX, -rangeY, 0.0f), transform.position + new Vector3(rangeX, rangeY, 0.0f));
        Gizmos.DrawLine(transform.position + new Vector3(-rangeX, -rangeY, 0.0f), transform.position + new Vector3(-rangeX, rangeY, 0.0f));
    }


    bool IsInRange(Transform trans)
    {
        return (trans.position.x > self.position.x - rangeX) &&
            (trans.position.x < self.position.x + rangeX) &&
            (trans.position.y > self.position.y - rangeY) &&
            (trans.position.y < self.position.y + rangeY);
    }

    void SetClimbPointsActive(bool active)
    {
        foreach( var cp in climbPoints)
        {
            cp.SetActive(active);
        }
    }

}
