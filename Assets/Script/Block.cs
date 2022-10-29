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

    void Start()
    {
        self = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDraggable() && Input.GetKey(KeyCode.F))
        {
            Drag();
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
        self.position = player.position + Vector3.right;
    }

}
