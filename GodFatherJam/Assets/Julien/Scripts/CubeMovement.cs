using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public Vector3 offset;

    public GameObject entity;

    public GameObject center;

    public GameObject up;
    public GameObject down;
    public GameObject right;
    public GameObject left;

    public int step = 9;

    public float speed = 0.01f;

    private bool input = true;
          
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(input)
        {
            if(Input.GetKey(KeyCode.Z) && input)
            {
                StartCoroutine("moveUp");
                input = false;
            }

            if (Input.GetKey(KeyCode.S) && input)
            {
                StartCoroutine("moveDown");
                input = false;
            }

            if (Input.GetKey(KeyCode.D) && input)
            {
                StartCoroutine("moveRight");
                input = false;
            }

            if (Input.GetKey(KeyCode.Q) && input)
            {
                StartCoroutine("moveLeft");
                input = false;
            }
        }
    }

    IEnumerator moveUp()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            entity.transform.RotateAround(up.transform.position, Vector3.right, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = entity.transform.position;
        input = true;
    }

    IEnumerator moveDown()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            entity.transform.RotateAround(down.transform.position, Vector3.left, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = entity.transform.position;
        input = true;
    }

    IEnumerator moveLeft()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            entity.transform.RotateAround(left.transform.position, Vector3.forward, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = entity.transform.position;
        input = true;
    }

    IEnumerator moveRight()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            entity.transform.RotateAround(right.transform.position, Vector3.back, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = entity.transform.position;
        input = true;
    }
}
