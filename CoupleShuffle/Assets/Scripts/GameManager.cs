using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMoney leftPlayer;

    [SerializeField] private PlayerMoney rightPlayer;

    private bool canRaiseRight;
    private bool canRaiseLeft;

    private PlayerMovement playerMovement;
    
    private float movementOffset;

    private float timer;

    private float startTimer = 0.1f;

    private void Awake() 
    {
        playerMovement = FindObjectOfType<PlayerMovement>();

        movementOffset = playerMovement.MoveSpeed;
    }

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
            
            _money.transform.parent = rightPlayer.moneyHolder.transform;

            var desiredPosition = new Vector3(rightPlayer.moneyHolder.position.x, (rightPlayer.MoneyCount - 1) * 0.1f, rightPlayer.moneyHolder.position.z + movementOffset);

            _money.SetRotateion(new Vector3(0, 0, -180));
            
            _money.SetDestination(desiredPosition);

            _money.SetPosition(_money.transform.position);

            _money.CanMove = true;


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
            
            _money.transform.parent = leftPlayer.moneyHolder.transform;

            var desiredPosition = new Vector3(leftPlayer.moneyHolder.position.x, (leftPlayer.MoneyCount - 1) * 0.1f, leftPlayer.moneyHolder.position.z + movementOffset);

            _money.SetRotateion(new Vector3(0, 0, 180));
            
            _money.SetDestination(desiredPosition);
            
            _money.SetPosition(_money.transform.position);
            
            _money.CanMove = true;


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
