using UnityEngine;

public class Wall : Interactable
{
    [SerializeField] private int value;

    [SerializeField] private WallMathOperation operation;
    private bool isCollected;

    private const string player = "Player";

    private void OnTriggerEnter(Collider other) 
    {
        if(!other.CompareTag(player)) return;

        var playerMoney = other.GetComponent<PlayerMoney>();

        if(operation == WallMathOperation.Increment)
        {
            playerMoney.IncreaseMoney(value);
        }
        else if(operation == WallMathOperation.Decrement)
        {
            playerMoney.DescreaseMoney(value);
        }
        else if(operation == WallMathOperation.Multiplication)
        {
            playerMoney.IncreaseMoney((value - 1) * playerMoney.MoneyCount);
        }
        else if(operation == WallMathOperation.Division)
        {
            var tempMoney = playerMoney.MoneyCount;

            tempMoney /= value;
            
            var playerMon = playerMoney.MoneyCount;

            value = playerMon -= tempMoney;

            playerMoney.DescreaseMoney(value);
        }
    }

    
}
