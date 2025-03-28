using UnityEngine;
using UnityEngine.UI;

public class ProductionUpgrade : MonoBehaviour
{
    [SerializeField] private GameResource _resource;
    [SerializeField] private Button _button;
    [SerializeField] private int _cost = 10;
    
    private ResourceBank _bank;

    private void Start()
    {
        _bank = FindObjectOfType<ResourceBank>();
        _button.onClick.AddListener(UpgradeProduction);
    }

    private void UpgradeProduction()
    {
        var gold = _bank.GetResource(GameResource.Gold);
        if (gold.Value >= _cost)
        {
            gold.Value -= _cost;
            _bank.ChangeResource(GetProdLvlResource(), 1);
        }
    }

    private GameResource GetProdLvlResource()
    {
        return _resource switch
        {
            GameResource.Humans => GameResource.HumansProdLvl,
            GameResource.Food => GameResource.FoodProdLvl,
            GameResource.Wood => GameResource.WoodProdLvl,
            GameResource.Stone => GameResource.StoneProdLvl,
            GameResource.Gold => GameResource.GoldProdLvl,
            _ => GameResource.HumansProdLvl
        };
    }
}