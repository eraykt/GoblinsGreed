using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Mover mover;
    
    [SerializeField]
    private Joystick joystick;

    private void Awake()
    {
        mover = GetComponent<Mover>();
        mover.AlignToGround(transform);
    }
    
    private void Update()
    {
        mover.SetMoveVector(joystick.Direction);
    }

    private void FixedUpdate()
    {
        mover.Move();

    }
}
