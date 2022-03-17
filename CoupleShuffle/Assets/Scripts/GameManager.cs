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
            var _money = leftPlayer.moneyList[leftPlayer.moneyList.Count - 1];

            var desiredPosition = new Vector3(leftPlayer.target.position.x, (rightPlayer.MoneyCount - 1) * 0.1f, leftPlayer.target.position.z);

            _money.SetDestination(desiredPosition);

            _money.SetPosition(new Vector3(_money.transform.position.x, _money.transform.position.y * 0.1f, _money.transform.position.z));

            rightPlayer.MoneyCount++;
            leftPlayer.MoneyCount--;

            rightPlayer.moneyList.Add(_money);

            leftPlayer.moneyList.Remove(_money);
        }
        
    }
    public void RaiseLeft()
    {
        if(rightPlayer.MoneyCount > 0)
        {
            var _money = rightPlayer.moneyList[rightPlayer.moneyList.Count - 1];

            var desiredPosition = new Vector3(rightPlayer.target.position.x, (leftPlayer.MoneyCount - 1) * 0.1f, rightPlayer.target.position.z);

            _money.SetDestination(desiredPosition);
            
            _money.SetPosition(new Vector3(_money.transform.position.x, _money.transform.position.y * 0.1f, _money.transform.position.z));

            leftPlayer.MoneyCount++;
            rightPlayer.MoneyCount--;
            
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
