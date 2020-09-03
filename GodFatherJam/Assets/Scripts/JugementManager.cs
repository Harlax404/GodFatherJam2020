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
            postProcessGo.GetComponent<TestPostPro>().PPIntesity = Mathf.Lerp(borneMaxJudgement, 1.0f, lerp);
        }
        else
        {
            if (distance > maxDistance)
            {
                //jugement à 0
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
        Debug.Log(lerp);
        
        postProcessGo.GetComponent<TestPostPro>().PPIntesity = Mathf.Lerp(borneMinJudgement, borneMaxJudgement, lerp);
        postProcessGo.GetComponent<TestPostPro>().IshIsh();
    }
}
