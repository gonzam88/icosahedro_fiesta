using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CamJoystickControl : MonoBehaviour
{
    public float rotationSpeed = 1.0f;
    public Camera camera;
    public float zoom;
    public float zoomSpeed;
    public float minZoom;
    public float maxZoom;
    public float inverseZoomMultiplier;
    public float translateSpeed;
    void Start()
    {
        zoom = camera.fieldOfView;
        camera.transform.LookAt(transform);
    }

    void Update(){
        
        // Zoom
        zoom += Input.GetAxis("RightTrigger") * zoomSpeed * -1;
        zoom += Input.GetAxis("LeftTrigger") * zoomSpeed;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom);
        camera.fieldOfView = zoom;
        inverseZoomMultiplier = Mathf.Clamp((zoom + minZoom) / (maxZoom + minZoom), .1f, 1f);
        
        // Rotacion
        transform.Rotate(Vector3.up, Input.GetAxis("Horizontal") * rotationSpeed * inverseZoomMultiplier);
        transform.Rotate(Vector3.left, Input.GetAxis("Vertical") * rotationSpeed * inverseZoomMultiplier);

        // Transalacion
        Vector3 horizontalTranslate = Vector3.right * (translateSpeed * Input.GetAxis("RightStickHorizontal") * inverseZoomMultiplier *-1);
        transform.Translate(horizontalTranslate);
        Vector3 verticalTranslate = Vector3.forward * (translateSpeed * Input.GetAxis("RightStickVertical") * inverseZoomMultiplier * -1);
        transform.Translate(verticalTranslate);
        
        
    }
}
