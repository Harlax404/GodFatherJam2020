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

    public bool inAlert = false;
    public float durationToLookAtPlayer = 5f;
    public float timeToLookAtPlayer = 0.5f;
    public Transform player;

    public bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        from = transform.rotation;
        current = transform.rotation;
        to = transform.rotation;
        to = Quaternion.Euler(Vector3.up * angle) * to;
    }

    // Update is called once per frame
    void Update()
    {
        if (!inAlert)
        {
            timer += Time.deltaTime * speed;
            transform.rotation = Quaternion.Lerp(from, to, Mathf.PingPong(timer, 1));
        }
        if (test)
        {
            test = false;
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
            Vector3 direction = player.position - transform.position;
            rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(current, rotation, elapsed / timeToLookAtPlayer);
            elapsed += Time.deltaTime;
            yield return null;
        }

        float elapsed2 = 0f;
        while (elapsed2 < timeToLookAtPlayer)
        {
            Debug.Log("blabla " + elapsed2 + " " + (elapsed2/ timeToLookAtPlayer));
            transform.rotation = Quaternion.Lerp(rotation, current, elapsed2 / timeToLookAtPlayer);
            elapsed2 += Time.deltaTime;
            yield return null;
        }

        inAlert = false;
    }

    void StartAlerMode()
    {
        StartCoroutine("LookAtPlayer");
    }
}
