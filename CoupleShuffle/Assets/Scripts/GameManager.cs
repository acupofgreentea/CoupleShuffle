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

            var _money = leftPlayer.moneyList[leftPlayer.moneyList.Count - 1];

            _money.SetPosition(leftPlayer.target.position);

            rightPlayer.moneyList.Add(_money);

            leftPlayer.moneyList.Remove(_money);
        }
        
    }
    public void RaiseLeft()
    {
        if(rightPlayer.MoneyCount > 0)
        {
            leftPlayer.MoneyCount++;
            rightPlayer.MoneyCount--;
            
            var _money = rightPlayer.moneyList[rightPlayer.moneyList.Count - 1];

            _money.SetPosition(rightPlayer.target.position);
            
            leftPlayer.moneyList.Add(_money);

            rightPlayer.moneyList.Remove(_money);
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
