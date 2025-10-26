using UnityEngine;

public class Mover : MonoBehaviour
{
    private bool isMoverEnabled = true;

    public float movementSpeed;
    public float rotationSpeed;
    private Vector2 moveVector;
    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    public void SetMoveVector(Vector2 vector)
    {
        moveVector = vector;
    }

    public Vector2 GetMoveVector()
    {
        return moveVector;
    }

    public void Move()
    {
        if (moveVector.sqrMagnitude != 0 && isMoverEnabled)
        {
            Vector3 moveDirection = moveVector.ToVector3().normalized;
            Vector3 movement = moveDirection * movementSpeed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + movement);
            
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            Quaternion smoothedRotation = Quaternion.RotateTowards(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(smoothedRotation);
        }
    }

    public void EnableMover(bool enable)
    {
        isMoverEnabled = enable;
    }

    public void AlignToGround(Transform visual)
    {
        if (Physics.Raycast(visual.position, Vector3.down, out RaycastHit hit, 10, LayerMask.GetMask("Ground")))
        {
            Vector3 newPosition = visual.position;
            newPosition.y = hit.point.y;
            visual.position = newPosition;
        }
    }
}