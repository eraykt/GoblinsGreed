using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothTime = 0.3f;

    private Vector3 offset;

    private float initialY;
    private Quaternion initialRotation;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("assign target");
            this.enabled = false;
            return;
        }

        initialY = transform.position.y;

        initialRotation = transform.rotation;

        Vector3 initialCamPos = transform.position;
        Vector3 initialTargetPos = target.position;

        offset = new Vector3(initialCamPos.x - initialTargetPos.x, 0, initialCamPos.z - initialTargetPos.z);
    }

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 targetPosition = new Vector3(
            target.position.x + offset.x,
            initialY,
            target.position.z + offset.z
        );

        transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            smoothTime          
        );

        transform.rotation = initialRotation;
    }
}