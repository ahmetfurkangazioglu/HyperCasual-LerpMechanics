using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    public Vector3 Offset;
  
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position + Offset, Time.deltaTime * 2);
    }
}
