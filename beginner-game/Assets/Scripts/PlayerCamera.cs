using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {

    private const float CAM_MAX_ANGLE = 50f;
    private float rotationX;
    private float rotationY;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void LateUpdate () {
        rotationX -= Input.GetAxis("Mouse Y");
        rotationY += Input.GetAxis("Mouse X");

        rotationX = Mathf.Clamp(rotationX, -CAM_MAX_ANGLE, CAM_MAX_ANGLE);

        Vector3 rotation = new Vector3(rotationX, rotationY, 0);

        transform.rotation = Quaternion.Euler(rotation);
    }
}
