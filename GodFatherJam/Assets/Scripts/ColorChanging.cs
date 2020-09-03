using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public Renderer rendCube;
    public Transform playerPos;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collision)
    {
      if(collision.gameObject.tag == "Player")
        {
            
            float distance = Vector3.Distance(transform.position,playerPos.position);
            rendCube.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time, 1));

            Debug.Log("OnTriggerStay");
        }



        // Color lerp
    }
}
