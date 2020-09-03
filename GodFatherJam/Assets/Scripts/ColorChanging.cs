using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    public Color startColor;
    public Color endColor;

    public Renderer rendCube;
    private Transform playerPos;
    public Transform cubePos;
    private float distance;

    private float lerp = 0.0f;
    //private Transform playerTransform;
    private Vector3 playerPosition;
    private float maxDistance;
    private float minDistance = 1.9f;

    private GameManager gm;

    void Start()
    {
        gm = GameManager.Instance;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        //playerTransform = playerPos.GetChild(0).transform;
        maxDistance = GetComponent<SphereCollider>().radius;

        minDistance = gameObject.GetComponentInParent<BoxCollider>().size.x;

    }


    void Update()
    {
        playerPosition = playerPos.position;
        distance = Vector3.Distance(cubePos.position, playerPosition);

        if (gm.alarmMode)
        {
            lerp = 1;
        }
        else
        {
            if (distance > maxDistance)
            {
                lerp = 0;
            }
            else if (distance <= 1)
            {
                lerp = 1;
            }
            else
            {
                lerp = 1 - ((distance - minDistance) / (maxDistance - minDistance));
            }
        }

        cubePos.GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, lerp);
    }
}