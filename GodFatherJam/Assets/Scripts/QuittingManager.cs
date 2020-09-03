using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuittingManager : MonoBehaviour
{
    [SerializeField]
    private float QuitTimer;
    
    void Update()
    {
        QuitTimer -= Time.deltaTime;

        if (QuitTimer <= 0 && Input.anyKeyDown)
            Application.Quit();
    }
}
