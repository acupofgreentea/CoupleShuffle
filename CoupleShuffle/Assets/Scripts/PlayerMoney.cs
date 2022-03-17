using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int moneyCount;

    [SerializeField] private Money moneyPrefab;

    [SerializeField] private TextMeshProUGUI moneyText;
    
    [SerializeField] public Transform moneyHolder;

    public Transform target;

    public List<Money> moneyList = new List<Money>();
    
    public int MoneyCount {get => moneyCount; set => moneyCount = value;}
    
    private float yPos = 0f;
    
    private void Start() 
    {
        for (int i = 0; i < MoneyCount; i++)
        {
            var moneyPos = new Vector3(moneyHolder.position.x, moneyHolder.localPosition.y + yPos, moneyHolder.position.z);

            var _money = Instantiate(moneyPrefab, moneyPos, Quaternion.identity);

            moneyList.Add(_money);

            yPos += 0.1f;
        }
    }

    private void Update() 
    {
        moneyText.text = MoneyCount.ToString();
    }

}
