using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]

public class SecondLinePath : MonoBehaviour
{


    public Transform point1; 
    public Transform point2;
    public Transform point3;   
    public Transform point4;
    public Transform point5;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 5;

        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        //lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        //lineRenderer.startColor = Color.cyan;
        //lineRenderer.endColor = Color.magenta;
    }

    void Update()
    {
        if (point1 != null && point5 != null)
        {
            lineRenderer.SetPosition(0, point1.position);
            lineRenderer.SetPosition(1,point2.position);
            lineRenderer.SetPosition(2, point3.position);
            lineRenderer.SetPosition(3,point4.position);
            lineRenderer.SetPosition(4,point5.position);
        }
    }
}