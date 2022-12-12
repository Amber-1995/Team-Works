using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryableBlock : MonoBehaviour
{
    [SerializeField]
    float rangeX;

    [SerializeField]
    float rangeY;

    [SerializeField]
    KeyCode ctrlKey = KeyCode.G;

    Transform self;

    Transform playerTrans;

    Transform robotTrans;

    Robot robot;

    private void Start()
    {
        self = GetComponent<Transform>();

        playerTrans = Player.instance.GetComponent<Transform>();

        robotTrans = Robot.instance.GetComponent<Transform>();

        robot = Robot.instance.GetComponent<Robot>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(ctrlKey) && Check(playerTrans.position.x,playerTrans.position.y))
        {
            Destroy(gameObject);
        }

        if(robot.robotMotionReady[(int)RobotMotion.DESTORY]&& Check(robotTrans.position.x, robotTrans.position.y))
        {
            Destroy(gameObject);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + new Vector3(-rangeX, rangeY, 0.0f), transform.position + new Vector3(rangeX, rangeY, 0.0f));
        Gizmos.DrawLine(transform.position + new Vector3(-rangeX, -rangeY, 0.0f), transform.position + new Vector3(rangeX, -rangeY, 0.0f));
        Gizmos.DrawLine(transform.position + new Vector3(rangeX, -rangeY, 0.0f), transform.position + new Vector3(rangeX, rangeY, 0.0f));
        Gizmos.DrawLine(transform.position + new Vector3(-rangeX, -rangeY, 0.0f), transform.position + new Vector3(-rangeX, rangeY, 0.0f));

    }

    bool Check(float x, float y)
    {
        return (x > self.position.x - rangeX && x < self.position.x + rangeX && y > self.position.y - rangeY && y < self.position.y + rangeY);
    }

}