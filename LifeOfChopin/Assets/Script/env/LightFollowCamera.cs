using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFollowCamera : MonoBehaviour
{
    public Camera camera;

    void Update()
    {
        transform.localPosition = camera.transform.localPosition;
        transform.localRotation = camera.transform.localRotation;
    }
}
