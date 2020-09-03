using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset = new Vector3(0, 4, -5);

    [SerializeField]
    private float dampingSpeed = 5.0f;

    private void Start()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = targetPosition;
    }

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, dampingSpeed * Time.deltaTime);

        Debug.DrawLine(transform.position ,targetPosition, Color.red);
    }
}
