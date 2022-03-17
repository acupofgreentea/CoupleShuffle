using UnityEngine;

public class Money : MonoBehaviour
{
    private float speed;

    private Vector3 endPos;

    private Vector3 startPos;

    private void Awake() 
    {
        endPos = transform.position;
    }

    private void Update() 
    {
        var dist = Vector3.Distance(transform.position, endPos);

        if(dist >= 0.05f)
        {
            MoveMoney();
        }
        else
        {
            transform.position = endPos;
            speed = 0;
        }
    }

    public void SetDestination(Vector3 endPos)
    {
        this.endPos = endPos;
    }

    public void SetPosition(Vector3 startPos)
    {
        this.startPos = startPos;
    }

    private void MoveMoney()
    {
        speed += Time.deltaTime;

        speed = speed % 1f;

        transform.position = MathParabola.Parabola(startPos, endPos, 1f, speed / 1f);
    }
}
