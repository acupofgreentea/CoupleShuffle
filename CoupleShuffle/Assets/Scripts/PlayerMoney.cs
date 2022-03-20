using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    [SerializeField] private int moneyCount;

    [SerializeField] private Money moneyPrefab;

   [SerializeField] private TextMeshProUGUI moneyText;
    
    public Transform moneyHolder;

    public List<Money> moneyList = new List<Money>();
    
    public int MoneyCount {get => moneyCount; set => moneyCount = value;}
    
    private float yPos = 0f;
    
    private void Awake() 
    {
        for (int i = 0; i < MoneyCount; i++)
        {
            SpawnMoney();
        }
    }

    private void Update() 
    {
        moneyText.text = MoneyCount.ToString();
    }

    private void SpawnMoney()
    {
        var moneyPos = new Vector3(moneyHolder.position.x, moneyHolder.position.y + yPos, moneyHolder.position.z);

        var _money = Instantiate(moneyPrefab, moneyPos, Quaternion.identity);

        moneyList.Add(_money);

        _money.transform.parent = this.moneyHolder;

        yPos += 0.1f;
    }

    private void DestroyMoney()
    {
        yPos -= 0.1f;

        var topMoney = moneyList[moneyList.Count - 1];

        var _money = topMoney.gameObject;

        moneyList.Remove(topMoney);

        Destroy(_money);
    }

    public void IncreaseMoney(int value)
    {
        MoneyCount += value;

        for (int i = 0; i < value; i++)
        {
            SpawnMoney();
        }
    }

    public void DescreaseMoney(int value)
    {
        if(MoneyCount - value >= 0)
            MoneyCount -= value;
        else
        {
            value = MoneyCount;
            MoneyCount = 0;
        }
           
            

        for (int i = 0; i < value; i++)
        {
            DestroyMoney();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Wall"))
        {
            
        }
    }
}
