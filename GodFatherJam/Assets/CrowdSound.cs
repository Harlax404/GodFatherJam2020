using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSound : MonoBehaviour
{
    private Transform player;
    private float maxDistance = 5;
    private float distance;
    private AudioSource sound;
    public float maxVolume = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, player.position);
        if (distance > maxDistance)
        {
            sound.volume = 0;
        }
        else sound.volume = ((maxDistance - distance)/maxDistance) * maxVolume;
    }
}
