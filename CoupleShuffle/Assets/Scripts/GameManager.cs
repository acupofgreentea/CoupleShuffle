using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMoney leftPlayer;

    [SerializeField] private PlayerMoney rightPlayer;

    public bool canRaiseRight;
    public bool canRaiseLeft;

    private float timer;

    private float startTimer = 0.1f;

    private void Update() 
    {
        if(timer <= 0)
        {
            if(canRaiseRight)
                RaiseRight();

            if(canRaiseLeft)
                RaiseLeft();

            timer = startTimer;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    public void RaiseRight()
    {
        if(leftPlayer.Money > 0)
        {   
            rightPlayer.Money++;
            leftPlayer.Money--;   
        }
        
    }
    public void RaiseLeft()
    {
        if(rightPlayer.Money > 0)
        {
            leftPlayer.Money++;
            rightPlayer.Money--;
        }
    }

    public void CanRaiseRight(bool raise)
    {
        canRaiseRight = raise;
    }

    public void CanRaiseLeft(bool raise)
    {
        canRaiseLeft = raise;
    }

}
