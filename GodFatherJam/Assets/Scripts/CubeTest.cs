using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTest : MonoBehaviour
{
    public GameObject entity;

    public GameObject center;
    public GameObject up;
    public GameObject down;
    public GameObject right;
    public GameObject left;

    public int step = 9;

    public float speed = 0.01f;
    public float speed2 = 1.0f;

    
    public GameObject controlPoint;
    private int nbControl;
    private GameObject[] controlPoints;
    private GameObject currentPoint;
    private int currentPointNumber = 0;

    public float timeBetweenMovement = 0.5f;
    public float movementTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        nbControl = controlPoint.transform.childCount;
        controlPoints = new GameObject[nbControl];
        currentPoint = controlPoints[0];
        //StartCoroutine("Pathing");
    }

    private void Update()
    {
        Pathing();
    }


    void Pathing()
    {
        Vector3 target = new Vector3();
        target = currentPoint.transform.position - transform.position;
        if (target.x > 0 && target.z > 0)
        {
            StartCoroutine("moveUp");
        }
        else if (target.x > 0 && target.z < 0)
        {
            StartCoroutine("moveDown");
        }
        else if (target.x < 0 && target.z > 0)
        {
            StartCoroutine("moveLeft");
        }
        else if (target.x < 0 && target.z < 0)
        {
            StartCoroutine("moveRight");
        }

       
        if (Vector3.Dot(currentPoint.transform.position, transform.position) < 0)
        {
            NextPoint();
        }
    }

    IEnumerator moveUp()
    {
        float elapsed = 0.0f;
        while (elapsed < movementTime)
        {
            entity.transform.RotateAround(up.transform.position, Vector3.right, elapsed);
            elapsed += Time.deltaTime;
            yield return null;
        }
        center.transform.position = entity.transform.position;
    }

    IEnumerator moveDown()
    {
        float elapsed = 0.0f;
        while (elapsed < movementTime)
        {
            entity.transform.RotateAround(down.transform.position, Vector3.left, elapsed);
            elapsed += Time.deltaTime;
            yield return null;
        }
        center.transform.position = entity.transform.position;
    }

    IEnumerator moveLeft()
    {
        float elapsed = 0.0f;
        while (elapsed < movementTime)
        {
            entity.transform.RotateAround(left.transform.position, Vector3.forward, elapsed);
            elapsed += Time.deltaTime;
            yield return null;
        }
        center.transform.position = entity.transform.position;
    }

    IEnumerator moveRight()
    {
        float elapsed = 0.0f;
        while (elapsed < movementTime)
        {
            entity.transform.RotateAround(right.transform.position, Vector3.back, elapsed);
            elapsed += Time.deltaTime;
            yield return null;
        }
        center.transform.position = entity.transform.position;
    }


    private void NextPoint()
    {
        if (currentPointNumber == nbControl - 1)
        {
            currentPoint = controlPoints[0];
        }
        else currentPoint = controlPoints[currentPointNumber + 1];
    }
}
