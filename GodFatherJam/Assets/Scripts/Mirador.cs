using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirador : MonoBehaviour
{
    private Quaternion from;
    private Quaternion to;
    private Quaternion current;

    public float angle = 60f;
    public float speed = 0.5f;

    private float timer = 0f;

    private bool inAlert = false;
    private bool alreadyAlert = false;

    public float durationToLookAtPlayer = 5f;
    public float timeToLookAtPlayer = 0.5f;
    //public Transform player;
    private Transform character;

    private GameManager gm; // pour récup arlarmMode

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").transform;
        gm = GameManager.Instance;
        from = transform.rotation;
        current = transform.rotation;
        to = transform.rotation;
        to = Quaternion.Euler(Vector3.up * angle) * to;
    }

    // Update is called once per frame
    void Update()
    {
        inAlert = gm.alarmMode;
        if (!inAlert)
        {
            timer += Time.deltaTime * speed;
            transform.rotation = Quaternion.Lerp(from, to, Mathf.PingPong(timer, 1));
        }
        else if (!alreadyAlert)
        {
            alreadyAlert = true;
            StartAlerMode(); 
        }
    }

    IEnumerator LookAtPlayer()
    {
        inAlert = true;
        current = transform.rotation;
        Quaternion rotation = Quaternion.identity;

        float elapsed = 0f;
        while (elapsed < timeToLookAtPlayer + durationToLookAtPlayer)
        {
            Vector3 direction = character.position - transform.position;
            //Debug.Log(character.position);
            rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(current, rotation, elapsed / timeToLookAtPlayer);
            elapsed += Time.deltaTime;
            yield return null;
        }

        float elapsed2 = 0f;
        while (elapsed2 < timeToLookAtPlayer)
        {
            transform.rotation = Quaternion.Lerp(rotation, current, elapsed2 / timeToLookAtPlayer);
            elapsed2 += Time.deltaTime;
            yield return null;
        }
        inAlert = false;
        alreadyAlert = false;
    }

    void StartAlerMode()
    {
        StartCoroutine("LookAtPlayer");
    }
}
