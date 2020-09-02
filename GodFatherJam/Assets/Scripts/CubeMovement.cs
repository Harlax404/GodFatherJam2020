using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
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

    [SerializeField]
    private List<GameObject> controlPoints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Pathing");
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if (!Physics.Linecast(transform.position, controlPoints[0].transform.position))
        {
            //StartCoroutine("moveRight");
            transform.position = Vector3.MoveTowards(transform.position, controlPoints[0].transform.position, Time.deltaTime * speed2);
            Debug.Log("Go 0");
            if(transform.position == controlPoints[0].transform.position)
            {

                Debug.Log("Stop");
            }
        }*/

        
    
    }

    IEnumerator moveUp()
    {
        //Rotating
        for (int i = 0; i < (90 / step); i++)
        {
            entity.transform.RotateAround(up.transform.position, Vector3.right, step);
            yield return new WaitForSeconds(speed);
        }
        

        center.transform.position = entity.transform.position;


        

    }

    IEnumerator moveDown()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            entity.transform.RotateAround(down.transform.position, Vector3.left, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = entity.transform.position;

        
    }

    IEnumerator moveLeft()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            entity.transform.RotateAround(left.transform.position, Vector3.forward, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = entity.transform.position;

        
    }

    IEnumerator moveRight()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            entity.transform.RotateAround(right.transform.position, Vector3.back, step);
            yield return new WaitForSeconds(speed);
        }
        center.transform.position = entity.transform.position;

        
    }

    IEnumerator Pathing()
    {
        // for each control point in the list
        for(int i2 = 0; i2 <= (controlPoints.Count - 1); i2++)
        {
            Debug.Log(i2);


            Vector3 offset = controlPoints[i2].transform.position - transform.position;

            //new Vector3(controlPoints[i2].transform.position.x - transform.position.x, controlPoints[i2].transform.position.y - transform.position.y, controlPoints[i2].transform.position.z - transform.position.z);



            // While the cube isn't at the control point's position
            //while (controlPoints[i2].transform.position != transform.position || ((offset.x < 0.01 && offset.x > -0.01) && (offset.y < 0.01 && offset.y > -0.01) && (offset.z < 0.01 && offset.z > -0.01)))
            Debug.Log(offset.sqrMagnitude);
            Debug.Log(offset.magnitude);

            while (offset.sqrMagnitude >= 0.5)
            {
                
                //Debug.Log("goes in");
                if (controlPoints[i2].tag == "Up")
                {
                    //Debug.Log("goes up");
                    StartCoroutine("moveUp");
                }

                if (controlPoints[i2].tag == "Down")
                {
                    //Debug.Log("goes down");
                    StartCoroutine("moveDown");
                   
                }

                if (controlPoints[i2].tag == "Left")
                {
                    //Debug.Log("goes left");
                    StartCoroutine("moveLeft");
                }

                if (controlPoints[i2].tag == "Right")
                {
                    //Debug.Log("goes right");
                    StartCoroutine("moveRight");
                }

                yield return new WaitForSeconds(0.5f);

                offset = controlPoints[i2].transform.position - transform.position;
                Debug.Log(offset.sqrMagnitude);
                Debug.Log(offset.magnitude);
            }


            //Debug.Log("goes out");
        }
        StartCoroutine("Pathing");
       
    }
}
