using UnityEngine;

public abstract class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;

    protected Rigidbody rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        Movement();
    }

    protected abstract void Movement();
}