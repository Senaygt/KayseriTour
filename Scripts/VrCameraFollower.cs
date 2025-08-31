using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CesiumForUnity;

public class VrCameraFollower : MonoBehaviour
{
    public CesiumGlobeAnchor cesiumAnchor;  
    public Transform xrCamera;              

    void Update()
    {
        if (cesiumAnchor != null && xrCamera != null)
        {
            
            Vector3 globePos = cesiumAnchor.transform.position;

            xrCamera.position = globePos + new Vector3(0, 2f, 0);  
        }
    }
}


