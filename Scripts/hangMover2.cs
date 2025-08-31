using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CesiumForUnity;


  

public class hangMover2 : MonoBehaviour
{
    public LineRenderer lineRenderer2;
    public float speed = 100f;


    private Vector3[] pathPoints2;
    private int targetIndex2 = 0;

    void Update()
    {
        
        pathPoints2 = new Vector3[lineRenderer2.positionCount];
        for (int i = 0; i < lineRenderer2.positionCount; i++)
            pathPoints2[i] = lineRenderer2.GetPosition(i);

        if (targetIndex2 >= pathPoints2.Length) return;

        Vector3 target2 = pathPoints2[targetIndex2];

        float step2 = speed * Time.deltaTime;

        
        if (targetIndex2 >= 4)
        {
            float distance = Vector3.Distance(transform.position, target2);

            
            step2 *= Mathf.Clamp01(distance / 5f);

            
            Vector3 euler = transform.rotation.eulerAngles;
            euler.x = Mathf.Lerp(euler.x, 0f, Time.deltaTime * 0.8f);
            euler.z = Mathf.Lerp(euler.z, 0f, Time.deltaTime * 0.8f);
            transform.rotation = Quaternion.Euler(euler);
        }
        else
        {
           
            Vector3 direction = (target2 - transform.position).normalized;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                targetRotation *= Quaternion.Euler(0, 90, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);
            }
        }

        
        transform.position = Vector3.MoveTowards(transform.position, target2, step2);

        if (Vector3.Distance(transform.position, target2) < 0.1f)
            targetIndex2++;
            
    }
}

