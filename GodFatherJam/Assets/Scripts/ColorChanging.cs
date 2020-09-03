using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public Renderer rendCube;
    public Transform playerPos;
    public Transform cubePos;
    private float distance;

    private float MaxDistance;
    
    void Start()
    {
        MaxDistance = GetComponent<SphereCollider>().radius;
    }

    
    void Update()
    {
        distance = Vector3.Distance(cubePos.position, playerPos.position);
        Debug.Log(distance);
    }

    void OnTriggerStay(Collider collision)
    {
      if(collision.gameObject.tag == "Player")
        {


            // rendCube.material.color = Color.Lerp(startColor, endColor, distance);
            //Debug.Log(cubePos.position);
            //Debug.Log(playerPos.position);


            float distanceApart = getSqrDistance(cubePos.position, playerPos.position);
           

            //Convert 0 and 200 distance range to 0f and 1f range
            float lerp = mapValue(distanceApart, 0, MaxDistance, 0f, 1f);

            //Lerp Color between near and far color
            Color lerpColor = Color.Lerp(startColor, endColor, lerp);
            cubePos.GetComponent<Renderer>().material.color = lerpColor;

        }

    }

    public float getSqrDistance(Vector3 v1, Vector3 v2)
    {
        return (v1 - v2).sqrMagnitude;
    }

    float mapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
    {
        return (mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin) + outValueMin;
    }
}
