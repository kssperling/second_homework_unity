using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        var bank = GetComponent<ResourceBank>();
        bank.ChangeResource(GameResource.Humans, 10);
        bank.ChangeResource(GameResource.Food, 5);
        bank.ChangeResource(GameResource.Wood, 5);
    }
}