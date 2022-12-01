using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbCheck : MonoBehaviour
{
    [SerializeField]
    Transform playerTrans;

    [SerializeField]
    Transform robotTrans;

    [SerializeField]
    float rangeX;

    [SerializeField]
    float rangeY;

    [SerializeField]
    Vector3[] routeKey;

    Transform self;

    Player player;

    bool isPlayerOnClimb = false;

    Robot robot;

    private void Start()
    {
        self = GetComponent<Transform>();

        player = playerTrans.GetComponent<Player>();

        //robot = robotTrans.GetComponent<Robot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Check(playerTrans.position.x, playerTrans.position.y) && !isPlayerOnClimb && Input.GetKeyDown(KeyCode.Space))
        {
            isPlayerOnClimb=true;
            StartCoroutine("PlayerClimb");
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
}
