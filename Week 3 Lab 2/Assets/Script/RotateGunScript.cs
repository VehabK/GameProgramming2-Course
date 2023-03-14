using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGunScript : MonoBehaviour
{
    public float minRotation = 10f;
    public float maxRotation = 30f;

    private float gunRotation = 0f;

void Update()
{
    float mouseYInput = Input.GetAxis("Mouse Y");

    gunRotation += mouseYInput;
    gunRotation = Mathf.Clamp(gunRotation, minRotation, maxRotation);

    transform.localEulerAngles = new Vector3(gunRotation, 0f, 0f);
       
    }
}
