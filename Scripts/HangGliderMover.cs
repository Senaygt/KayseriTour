using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CesiumForUnity;


public class HangGliderMover : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float speed = 100f;
    public GameObject portal;

    private bool speeded=false;
    
    public Vector3[] pathPoints;
    private int targetIndex = 1;
    private CesiumGlobeAnchor globeAnchor;

    public float swayAmount = 5f;
    public float swaySpeed = 2f;  
    public float pullStrength = 1f;

    
    public double startLatitude = 38.66247667;
    public double startLongitude = 35.55258408;
    public double startHeight = 3964326.8097; 

    void Awake()
    {
        globeAnchor = GetComponent<CesiumGlobeAnchor>();

       
        globeAnchor.latitude = startLatitude;
        globeAnchor.longitude = startLongitude;
        globeAnchor.height = startHeight;
        
    }
     

    void Update()
    {
         pathPoints = new Vector3[lineRenderer.positionCount];
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            pathPoints[i] = lineRenderer.GetPosition(i);
        }
        if (targetIndex >= pathPoints.Length) return;

        if(portal.activeSelf && speeded){
            speed=speed*5;
            speeded=true;
          Vector3 direction = (portal.transform.position - transform.position).normalized;
          Quaternion targetRotation = Quaternion.LookRotation(direction);
            float swayPitch = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
            float swayRoll = Mathf.PerlinNoise(Time.time * swaySpeed, 0f) * swayAmount - swayAmount / 2f;
            Quaternion swayRotation = Quaternion.Euler(swayPitch, 0, swayRoll);
            transform.rotation = transform.rotation*swayRotation;
            transform.position += direction * pullStrength * Time.deltaTime;
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        Vector3 target = pathPoints[targetIndex];
        float step = speed * Time.deltaTime;

        Vector3 newPos = Vector3.MoveTowards(transform.position, target, step);
        transform.position = newPos;

        Vector3 direction2 = (target - transform.position).normalized;
        if (direction2 != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction2);
            targetRotation *= Quaternion.Euler(0, 90, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2f);
        }

        

        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            targetIndex++;
        }
        
    }
}
