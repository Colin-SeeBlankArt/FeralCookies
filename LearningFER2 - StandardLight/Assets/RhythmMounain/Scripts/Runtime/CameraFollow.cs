
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 10f;

    public Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPostion = target.position + offset; //finds where we want to snap camera too, every frame
        Vector3 smoothPostion = Vector3.Lerp(transform.position, desiredPostion, smoothSpeed * Time.deltaTime);  //defines how close the camera gets, based on Desired and Smooth, not sure how though
        transform.position = smoothPostion;

        transform.LookAt(target);
    }

}
