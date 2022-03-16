using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int moneyCount;

    [SerializeField] private Money moneyPrefab;

    [SerializeField] private Transform moneyHolder;

    [SerializeField] public Transform target;

    [SerializeField] private TextMeshProUGUI moneyText;
    
    public List<Money> moneyList = new List<Money>();

    private float yPos;
    
    public int MoneyCount {get => moneyCount; set => moneyCount = value;}

    public Money LastMoney {get; set;}

    private Money _money;
    
    private void Start() 
    {
        for (int i = 0; i < MoneyCount; i++)
        {
            var moneyPos = new Vector3(moneyHolder.position.x, moneyHolder.position.y + yPos, moneyHolder.position.z);

            _money = Instantiate(moneyPrefab, moneyPos, Quaternion.identity);

            moneyList.Add(_money);

            yPos += 0.1f;
        }
    }

    private void Update() 
    {
        moneyText.text = MoneyCount.ToString();
    }

}
