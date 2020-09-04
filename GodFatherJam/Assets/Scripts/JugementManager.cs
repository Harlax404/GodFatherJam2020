using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugementManager : MonoBehaviour
{
    [SerializeField]
    private float borneMinJudgement;
    [SerializeField]
    private float borneMaxJudgement;
    private GameObject postProcessGo;

    public Transform playerPos;
    public Transform cubePos;
    private float distance;

    private float lerp = 0.0f;
    private Transform playerTransform;
    private Vector3 playerPosition;
    private float maxDistance;
    private float minDistance = 1.9f;

    private GameManager gm;

    private float petitLerp = 0.1f;
    private float intensityBackUp;
    private bool postAlarm = false;

    void Start()
    {
        gm = GameManager.Instance;
        postProcessGo = GameObject.Find("BaptistePostProcess");

        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        // Transform du player
        playerTransform = playerPos.GetChild(0).transform;

        minDistance = gameObject.GetComponentInParent<BoxCollider>().size.x;
        maxDistance = GetComponent<SphereCollider>().radius;


       
    }

    void Update()
    {

        playerPosition = playerTransform.position;

        distance = Vector3.Distance(cubePos.position, playerPosition);

        if (gm.alarmMode)
        {
            // Jugement à 1 en lerp
            /*postProcessGo.GetComponent<TestPostPro>().PPIntesity = Mathf.Lerp(intensityBackUp, 0.8f, petitLerp);
            //Debug.Log("Pp = "+ postProcessGo.GetComponent<TestPostPro>().PPIntesity);
            petitLerp += 0.01f;
            postAlarm = true;
            Debug.Log("in alarm");*/
        }
        else
        {
            /*if(postProcessGo.GetComponent<TestPostPro>().PPIntesity == 0.8f) petitLerp = 0.1f;

            if (postAlarm && !gm.alarmMode)
            {
                postProcessGo.GetComponent<TestPostPro>().PPIntesity = Mathf.Lerp(0.8f, intensityBackUp, petitLerp);
                petitLerp += 0.005f;

                if (postProcessGo.GetComponent<TestPostPro>().PPIntesity <= intensityBackUp + 0.01f) postAlarm = false;
            }

            if (distance > maxDistance)
            {
                //jugement à 0
                intensityBackUp = 0.0f;
                lerp = 0;
            }
            else if (distance <= 1)
            {
                lerp = 1;
            }
            else
            {
                lerp = 1 - ((distance - minDistance) / (maxDistance - minDistance));
            }*/
        }
        //Debug.Log(lerp);
        /*if(!gm.alarmMode && !postAlarm)
        {
            Debug.Log("rentre pas ici");
            intensityBackUp = postProcessGo.GetComponent<TestPostPro>().PPIntesity;
            postProcessGo.GetComponent<TestPostPro>().PPIntesity = Mathf.Lerp(borneMinJudgement, borneMaxJudgement, lerp);
        }
        
        postProcessGo.GetComponent<TestPostPro>().IshIsh();*/
    }
}
