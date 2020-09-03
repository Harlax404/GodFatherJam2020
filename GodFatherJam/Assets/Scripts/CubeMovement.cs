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

    public BoxCollider cubeCollider;
    public SphereCollider cubeVisionCollider;
    public int step = 9;

    public float rotationSpeed = 0.01f;
    public float cubeSpeed = 1.0f;
    public float alarmDuration;
    public bool isAlarmModeEnabled = true;
    public float collisionForce = 5;

    private GameManager gm;

    [SerializeField]
    private List<GameObject> controlPoints = new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.Instance;
      

       // StartCoroutine("Pathing");
        
    }

    void OnCollisionEnter(Collision c)
    {    

        if (c.gameObject.tag == "Player")
        {
            Debug.Log("OncollisionEnter");
            gm.alarmMode = true;
            Vector3 dir = c.contacts[0].point - transform.position;

            dir = -dir.normalized;

            GetComponent<Rigidbody>().AddForce(dir * collisionForce);

            StartCoroutine("alarmMode");
        }
    }
    void FixedUpdate()
    {

    }

    IEnumerator moveUp()
    {
        //Rotating
        for (int i = 0; i < (90 / step); i++)
        {
            entity.transform.RotateAround(up.transform.position, Vector3.right, step);
            yield return new WaitForSeconds(rotationSpeed);
        }
        

        center.transform.position = entity.transform.position;


        

    }

    IEnumerator moveDown()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            entity.transform.RotateAround(down.transform.position, Vector3.left, step);
            yield return new WaitForSeconds(rotationSpeed);
        }
        center.transform.position = entity.transform.position;

        
    }

    IEnumerator moveLeft()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            entity.transform.RotateAround(left.transform.position, Vector3.forward, step);
            yield return new WaitForSeconds(rotationSpeed);
        }
        center.transform.position = entity.transform.position;

        
    }

    IEnumerator moveRight()
    {
        for (int i = 0; i < (90 / step); i++)
        {
            entity.transform.RotateAround(right.transform.position, Vector3.back, step);
            yield return new WaitForSeconds(rotationSpeed);
        }
        center.transform.position = entity.transform.position;

        
    }

    IEnumerator Pathing()
    {
        // for each control point in the list
        for(int i2 = 0; i2 <= (controlPoints.Count - 1); i2++)
        {
            Vector3 offset = controlPoints[i2].transform.position - transform.position;

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

                yield return new WaitForSeconds(cubeSpeed);

                offset = controlPoints[i2].transform.position - transform.position;
            }


            //Debug.Log("goes out");
        }
        StartCoroutine("Pathing");
       
    }

    IEnumerator alarmMode()
    {
        if(isAlarmModeEnabled)
        { 
            Debug.Log("in alarm");
            // Everything that is alarm-related goes here
            
            GameObject[] cubeArray = GameObject.FindGameObjectsWithTag("Enemy");
            Color actualColor = cubeArray[0].GetComponent<Renderer>().material.color;

            foreach (GameObject cube in cubeArray)
            {
                cube.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
                cube.GetComponent<CubeMovement>().cubeSpeed /= 3.0f;
            }



            yield return new WaitForSeconds(alarmDuration);

            foreach (GameObject cube in cubeArray)
            {
                cube.GetComponent<Renderer>().material.color = actualColor;
                cube.GetComponent<CubeMovement>().cubeSpeed *= 3.0f;
            }

            gm.alarmMode = false;
        }
       
    }
    
}
