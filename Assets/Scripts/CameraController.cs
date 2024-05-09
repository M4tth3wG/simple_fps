using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float roationSpeed = 5.0f;
    public float minVert = -20.0f;
    public float maxVert = 20.0f;

    private float rotationX = 0;

    void Update()
    {
        float mY = Input.GetAxis("Mouse Y");
        rotationX -= mY * roationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
        transform.localEulerAngles = new Vector3 (rotationX, transform.localEulerAngles.y, 0);
    }
}
