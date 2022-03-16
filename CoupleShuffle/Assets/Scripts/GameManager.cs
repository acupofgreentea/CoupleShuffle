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
        if(leftPlayer.MoneyCount > 0)
        {   
            rightPlayer.MoneyCount++;
            leftPlayer.MoneyCount--;

            rightPlayer.moneyList.Add(leftPlayer.moneyList[leftPlayer.moneyList.Count - 1]);

            leftPlayer.moneyList.Remove(leftPlayer.moneyList[leftPlayer.moneyList.Count - 1]);
        }
        
    }
    public void RaiseLeft()
    {
        if(rightPlayer.MoneyCount > 0)
        {
            leftPlayer.MoneyCount++;
            rightPlayer.MoneyCount--;
            
            leftPlayer.moneyList.Add(rightPlayer.moneyList[rightPlayer.moneyList.Count - 1]);

            rightPlayer.moneyList.Remove(rightPlayer.moneyList[rightPlayer.moneyList.Count - 1]);
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
