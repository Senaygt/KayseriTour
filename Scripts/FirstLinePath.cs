using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]

public class FirstLinePath : MonoBehaviour
{


    public Transform startPoint; 
    public Transform middlePoint;
    public Transform endPoint;   

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 3;

        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        //lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        //lineRenderer.startColor = Color.cyan;
        //lineRenderer.endColor = Color.magenta;
    }

    void Update()
    {
        if (startPoint != null && endPoint != null)
        {
            lineRenderer.SetPosition(0, startPoint.position);
            lineRenderer.SetPosition(1,middlePoint.position);
            lineRenderer.SetPosition(2, endPoint.position);
        }
    }
}


    



