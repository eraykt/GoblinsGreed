using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static readonly int Move = Animator.StringToHash("Move");
    
    private Mover mover;
    private Animator animator;
    
    
    [SerializeField]
    private Joystick joystick;

    private void Awake()
    {
        mover = GetComponent<Mover>();
        animator = GetComponent<Animator>();
        mover.AlignToGround(transform);
    }
    
    private void Update()
    {
        mover.SetMoveVector(joystick.Direction);
        animator.SetFloat(Move, joystick.Direction.magnitude);
    }

    private void FixedUpdate()
    {
        mover.Move();

    }
}
