using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float CameraSensitivity {
    get { return cameraSensitivity; }
    set { cameraSensitivity = value; }
	}
    
	float cameraSensitivity = 2f;
    float cameraYRotationLimit = 88f;

Vector2 cameraRotation = Vector2.zero;
const string cameraXAxis = "Mouse X"; 
const string cameraYAxis = "Mouse Y";

void Update(){
	cameraRotation.x += Input.GetAxis(cameraXAxis) * cameraSensitivity;
	cameraRotation.y += Input.GetAxis(cameraYAxis) * cameraSensitivity;
	cameraRotation.y = Mathf.Clamp(cameraRotation.y, -cameraYRotationLimit, cameraYRotationLimit);
	var xQuaternion = Quaternion.AngleAxis(cameraRotation.x, Vector3.up);
	var yQuaternion = Quaternion.AngleAxis(cameraRotation.y, Vector3.left);

	transform.localRotation = xQuaternion * yQuaternion;
	}
}
