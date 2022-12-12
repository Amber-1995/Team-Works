using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbPoint : MonoBehaviour
{

    [SerializeField]
    float rangeX;

    [SerializeField]
    float rangeY;

    [SerializeField]
    Vector3[] routeKey;

    [SerializeField]
    KeyCode ctrlKey = KeyCode.Space;

    Transform playerTrans;

    Transform robotTrans;

    Transform self;

    Player player;

    Robot robot;

    bool isPlayerOnClimb = false;

    bool isRobotOnClimb = false;

    private void Start()
    {
        playerTrans = Player.instance.GetComponent<Transform>();

        robotTrans = Robot.instance.GetComponent<Transform>();

        self = GetComponent<Transform>();

        player = playerTrans.GetComponent<Player>();

        robot = robotTrans.GetComponent<Robot>();

    }
    void Update()
    {
        if (Check(playerTrans.position.x, playerTrans.position.y) && !isPlayerOnClimb && Input.GetKeyDown(ctrlKey))
        {
            isPlayerOnClimb=true;
            StartCoroutine("PlayerClimb");
        }


        if(Check(robotTrans.position.x, robotTrans.position.y) && robot.robotMotionReady[(int)RobotMotion.CLIMB])
        {
            isRobotOnClimb = true;
            StartCoroutine("RobotClimb");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position + new Vector3(-rangeX, rangeY, 0.0f), transform.position + new Vector3(rangeX, rangeY, 0.0f));
        Gizmos.DrawLine(transform.position + new Vector3(-rangeX, -rangeY, 0.0f), transform.position + new Vector3(rangeX, -rangeY, 0.0f));
        Gizmos.DrawLine(transform.position + new Vector3(rangeX, -rangeY, 0.0f), transform.position + new Vector3(rangeX, rangeY, 0.0f));
        Gizmos.DrawLine(transform.position + new Vector3(-rangeX, -rangeY, 0.0f), transform.position + new Vector3(-rangeX, rangeY, 0.0f));

        foreach(Vector3 key in routeKey)
        {
            Gizmos.DrawSphere(transform.position + key,0.1f);
        }
    }

    bool Check(float x, float y)
    {
        return (x > self.position.x - rangeX && x < self.position.x + rangeX && y > self.position.y - rangeY && y < self.position.y + rangeY);
    }

    IEnumerator PlayerClimb()
    {
        player.Climb();
        //playerTrans.position = self.position;
        foreach(Vector3 key in routeKey)
        {
            Vector3 start = playerTrans.position;
            for(float i = 0.0f; i <=1.0f;i+=0.05f)
            {
                playerTrans.position = Vector3.Lerp(start, self.position + key, i);
                yield return new WaitForFixedUpdate();
            }
        }
        player.Climb();
        isPlayerOnClimb = false;

    }

    IEnumerator RobotClimb()
    {
        robot.Climb();
        foreach (Vector3 key in routeKey)
        {
            Vector3 start = robotTrans.position;
            for (float i = 0.0f; i <= 1.0f; i += 0.05f)
            {
                robotTrans.position = Vector3.Lerp(start, self.position + key, i);
                yield return new WaitForFixedUpdate();
            }
        }
        robot.Climb();
        isRobotOnClimb = false;

    }
}
