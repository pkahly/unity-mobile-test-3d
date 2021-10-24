using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public Transform target;
    public float translateSpeed;
    public float rotationSpeed;

    void FixedUpdate()
    {
        HandleTranslation();
        HandleRotation();
    }

    void HandleTranslation()
    {
        var targetPos = target.TransformPoint(offset);
        transform.position = Vector3.Slerp(transform.position, targetPos, translateSpeed * Time.deltaTime);
    }

    void HandleRotation()
    {
        var direction = target.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
