using Dreamteck.Forever;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;

    public float smoothSpeed = 10f;
    public Transform target;

    private Vector3? Delta = null;

    private void FloatingOriginOnonOriginOffset(Vector3 delta)
    {
        transform.position -= delta;
    }

    private void LateUpdate()
    {
        UpdateFollowTransform(1f);
    }

    private void OnDisable()
    {
        FloatingOrigin.onOriginOffset -= FloatingOriginOnonOriginOffset;
    }

    private void OnEnable()
    {
        FloatingOrigin.onOriginOffset += FloatingOriginOnonOriginOffset;
    }

    private void OnValidate()
    {
        UpdateFollowTransform(1f);
    }

    private void UpdateFollowTransform(float t)
    {
        if (target == null)
        {
            return;
        }

        var desiredPostion = target.TransformPoint(offset); //finds where we want to snap camera too, every frame
        var smoothPostion = Vector3.Lerp(transform.position, desiredPostion, t); //defines how close the camera gets, based on Desired and Smooth, not sure how though
        transform.position = smoothPostion;

        transform.LookAt(target);
    }
}