using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int money;
    public int Money {get => money; set => money = value;}

    [SerializeField] private TextMeshProUGUI moneyText;

    private void Update() 
    {
        moneyText.text = Money.ToString();
    }

}
