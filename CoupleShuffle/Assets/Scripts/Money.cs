using UnityEngine;

public class Money : MonoBehaviour
{
    private float speed;

    [SerializeField] private Transform endPos = null;

    private void Update() 
    {
        if(endPos == null) return;

        var dist = Vector3.Distance(transform.position, endPos.position);

        if(dist >= 0.5f)
        {
            MoveMoney();
        }
    }

    public void SetPosition(Transform endPos)
    {
        this.endPos = endPos;
    }

    private void MoveMoney()
    {
        speed += Time.deltaTime;

        speed = speed % 1f;

        transform.position = MathParabola.Parabola(transform.position, endPos.position, 2f, speed);
    }
}
