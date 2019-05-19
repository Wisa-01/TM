using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFoloo : MonoBehaviour
{
    public Transform playerseth;
    public float cameraDistance = 30.0f;

    private void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(playerseth.position.x, playerseth.position.y, transform.position.z);
    }
}
