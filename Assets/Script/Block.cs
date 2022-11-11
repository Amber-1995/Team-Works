using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Block : MonoBehaviour
{
    [SerializeField]
    float dragRangeH;
    [SerializeField]
    float dragRangeV;

    [SerializeField]
    Transform player;

    Transform self;

    SpriteRenderer playerSpriteRenderer;

    float faceDirection;

    bool isOnDrag;

    void Start()
    {
        self = GetComponent<Transform>();

        playerSpriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isOnDrag)
        {
            faceDirection = playerSpriteRenderer.flipX ? -1.0f : 1.0f;
        }
       

        if (IsDraggable() && Input.GetKey(KeyCode.F))
        {
            Drag();
            isOnDrag = true;
        }
        else
        {
            isOnDrag = false;
        }


    }


    bool IsDraggable()
    {
        return (player.position.x > self.position.x - dragRangeH) &&
            (player.position.x < self.position.x + dragRangeH) &&
            (player.position.y > self.position.y - dragRangeV) &&
            (player.position.y < self.position.y + dragRangeV);
    }

    void Drag()
    {
        self.position = player.position + Vector3.right * faceDirection;
    }

}
