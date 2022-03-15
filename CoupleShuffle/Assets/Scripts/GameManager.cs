using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerMoney leftPlayer;

    [SerializeField] private PlayerMoney rightPlayer;
    
    public void RaiseRight()
    {
        rightPlayer.Money++;
        leftPlayer.Money--;
    }
    public void RaiseLeft()
    {
        leftPlayer.Money++;
        rightPlayer.Money--;
    }

}
