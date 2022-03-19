using UnityEngine;
public class Wall : Interactable
{
    private bool isCollected;

    private const string player = "Player";

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag(player))
        {
            other.GetComponent<PlayerMoney>().MoneyCount += 50;
        }
    }
}
