using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDestroy : MonoBehaviour
{
    [SerializeField]
    GameObject block;

    bool isDestroy = false;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isDestroy = true;
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && isDestroy)
        {
            Destroy(gameObject);
            Destroy(block);
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        isDestroy = false;
    }
}