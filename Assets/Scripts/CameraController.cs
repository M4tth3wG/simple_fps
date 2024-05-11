using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotationSpeed;
    public float minVert;
    public float maxVert;

    private float rotationX = 0;

    private void Start()
    {
        rotationSpeed = GameController.instance.configuration.playerRotationSpeed;
        minVert = GameController.instance.configuration.playerMinVert;
        maxVert = GameController.instance.configuration.playerMaxVert;
    }

    void Update()
    {
        float mY = Input.GetAxis("Mouse Y");
        rotationX -= mY * rotationSpeed;
        rotationX = Mathf.Clamp(rotationX, minVert, maxVert);
        transform.localEulerAngles = new Vector3 (rotationX, transform.localEulerAngles.y, 0);
    }
}
