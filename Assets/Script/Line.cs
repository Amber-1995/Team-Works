using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField]
    Transform target;

    Transform self;

    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        self = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(self.position,target.position) < 1.5)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, self.position - new Vector3(0.0f, 0.0f, 1.0f));
            lineRenderer.SetPosition(1, target.position - new Vector3(0.0f, 0.0f, 1.0f));
        }
        else
        {
            lineRenderer.enabled = false;
        }
       
    }
}
