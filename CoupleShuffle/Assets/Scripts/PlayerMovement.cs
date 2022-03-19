using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    protected override void Movement()
    {
        Vector3 movement = Vector3.forward;

        //rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }
}