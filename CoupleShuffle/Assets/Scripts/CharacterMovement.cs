using UnityEngine;

public abstract class CharacterMovement : MonoBehaviour
{
    [SerializeField] protected float moveSpeed;

    protected Rigidbody rb;

    public float MoveSpeed {get => moveSpeed; set => moveSpeed = value;}

    private void Awake() 
    {
        //rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        Movement();
    }

    protected abstract void Movement();
}