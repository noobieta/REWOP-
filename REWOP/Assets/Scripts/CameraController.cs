using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    #region Commented
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed;

    // public float Zoom = 2.48f;
    // public float currentZoom;
    //private float pitch = 2f;
    // Use this for initialization
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
        transform.LookAt(target);

    }
    #endregion
    //public VirtualMouse mouse;
    //public float mouseSensitivity = 10;
    //public Transform target;
    //public float dstFromTarget = 2;
    //public Vector2 pitchMinMax = new Vector2(-40, 85);

    //public float rotationSmoothTime = .12f;
    //Vector3 rotationSmoothVelocity;
    //Vector3 currentRotation;
    //float yaw;
    //float pitch;

    //private void LateUpdate()
    //{
    //    yaw += mouse.Horizontal() * mouseSensitivity;
    //    pitch -= mouse.Vertical() * mouseSensitivity;
    //    pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

    //    currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);
    //    transform.eulerAngles = currentRotation;
    //    transform.position = target.position - target.forward * dstFromTarget;

    //}


    private void Start()
    {
        target = PlayerManager.instance.player.transform;
    }
}
