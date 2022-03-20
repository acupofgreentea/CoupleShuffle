using UnityEngine;

public class Money : MonoBehaviour
{
    private float speed;

    private Vector3 endPos;

    private Vector3 startPos;

    public bool CanMove{get; set;}

    private Vector3 rot;

    private void Awake() 
    {
        endPos = transform.position;
    }

    private void FixedUpdate() 
    {
        if(CanMove && speed <= 1)
        {
            MoveMoney();
        }
        else if(speed >= 1)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, endPos.y, 0); // fixing transferred money position
            transform.eulerAngles = rot; // fixing transferred money position
            CanMove = false;
            speed = 0;
        }
    }

    public void SetDestination(Vector3 endPos)
    {
        this.endPos = endPos;
    }

    public void SetRotation(Vector3 rot)
    {
        this.rot = rot;
    }

    public void SetPosition(Vector3 startPos)
    {
        this.startPos = startPos;
    }

    private void MoveMoney()
    {
        transform.Rotate(rot * Time.deltaTime, Space.Self);

        speed += Time.deltaTime;

        transform.position = MathParabola.Parabola(startPos, endPos, 1f, speed);
    }
}
