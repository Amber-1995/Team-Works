using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotPushBlock : MonoBehaviour
{
    [SerializeField]
    float rangeX;

    [SerializeField]
    float rangeY;

    [SerializeField]
    Vector3 target;

    [SerializeField]
    GameObject[] climbPoints;

    Rigidbody2D rb;

    Transform self;

    Transform robotTrans;

    Robot robot;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        self = GetComponent<Transform>();

        robotTrans = Robot.instance.GetComponent<Transform>();

        robot = Robot.instance.GetComponent<Robot>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + new Vector3(-rangeX, rangeY, 0.0f), transform.position + new Vector3(rangeX, rangeY, 0.0f));
        Gizmos.DrawLine(transform.position + new Vector3(-rangeX, -rangeY, 0.0f), transform.position + new Vector3(rangeX, -rangeY, 0.0f));
        Gizmos.DrawLine(transform.position + new Vector3(rangeX, -rangeY, 0.0f), transform.position + new Vector3(rangeX, rangeY, 0.0f));
        Gizmos.DrawLine(transform.position + new Vector3(-rangeX, -rangeY, 0.0f), transform.position + new Vector3(-rangeX, rangeY, 0.0f));

        Gizmos.DrawSphere(target, 0.1f);

    }

    private void Update()
    {
        if(Vector3.Distance(self.position,target) < 0.1f)
        {
            self.position = target;
            foreach(GameObject cp in climbPoints)
            {
                cp.SetActive(true);
            }
            rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }
        else
        {
            foreach (GameObject cp in climbPoints)
            {
                cp.SetActive(false);
            }
            if (Check(robotTrans.position.x, robotTrans.position.y) && robot.robotMotionReady[(int)RobotMotion.PUSH])
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
            else
            {
                rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            }
        }
    }

    bool Check(float x, float y)
    {
        return (x > self.position.x - rangeX && x < self.position.x + rangeX && y > self.position.y - rangeY && y < self.position.y + rangeY);
    }
}
