using UnityEngine;

public class Money : MonoBehaviour
{
    private float speed;

    private Vector3 endPos;

    private void Awake() 
    {
        endPos = transform.position;
    }

    private void Update() 
    {
        if(endPos == null) return;

        var dist = Vector3.Distance(transform.position, endPos);

        if(dist >= 0.5f)
        {
            MoveMoney();
        }
        else
        {
            speed = 0;
        }
    }

    public void SetPosition(Vector3 endPos)
    {
        this.endPos = endPos;
    }

    private void MoveMoney()
    {
        speed += Time.deltaTime;

        speed = speed % 1f;

        transform.position = MathParabola.Parabola(transform.position, endPos, 1f, speed);
    }
}
