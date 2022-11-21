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

    Transform self;

    Player player;

    private void Start()
    {
        self = GetComponent<Transform>();

        player = playerTrans.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Check(playerTrans.position.x, playerTrans.position.y))
        {
            player.SetClimb(true);
            player.SetClimbDrection(playerTrans.position.x < self.position.x ? 1.0f : -1.0f);
        }
        else
        {
            Debug.Log("2333");
            player.SetClimb(false);
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
