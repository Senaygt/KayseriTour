using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CesiumForUnity;

public class portalCollider : MonoBehaviour

{
    public ParticleSystem starParticles;
    private CesiumGlobeAnchor globeAnchor;
    private double startLatitude=38.68491673;
    private double startLongitude=35.54146895;
    private double startHeight=1192.9083;
    public float swayAmount = 0.5f;  
    public float swaySpeed = 1f;    
    private Vector3 initialPosition;
    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        globeAnchor=GetComponent<CesiumGlobeAnchor>();
        
        
        if(!gameObject.activeSelf){
            return;
        }
        globeAnchor.latitude=startLatitude;
        globeAnchor.longitude=startLongitude;

        float noise = (Mathf.PerlinNoise(Time.time * swaySpeed, 0f) - 0.5f) * 2f * swayAmount;
        globeAnchor.height = startHeight + noise;
    }


    
}







   
