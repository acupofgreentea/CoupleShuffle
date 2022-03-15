using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private Transform[] moneyHolders;

    private float speed;
    
    private int index = 0;

    private bool canMove;

    Vector3 startPos;

    Vector3 endPos;

    private void Awake() 
    {
        startPos = moneyHolders[0].position;

        endPos = moneyHolders[1].position;
    }

    private void Update() 
    {
    //     if(!canMove) return;
        
    //     MoveMoney();    
        if(Input.GetKey(KeyCode.Space))
        {
            transform.position = moneyHolders[1].position;
        }
    }

    // public void MoveMoney()
    // {
    //     if(canMove)
    //     {
    //         speed += Time.deltaTime;

    //         speed = speed % 1f;

    //         transform.position = MathParabola.Parabola(startPos, endPos, 2f, speed);

    //         var dist = Vector3.Distance(transform.position, endPos);

    //         if(dist <= 0.5f)
    //             canMove = false;
            

    //         // var tempPos = startPos;

    //         // var temPos2 = endPos;

    //         // startPos = temPos2;

    //         // endPos = tempPos;
    //     }
    // }


    // public void DoCanMove(bool move)
    // {
    //     canMove = move;
    // }
}
