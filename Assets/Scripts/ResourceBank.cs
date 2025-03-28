using System.Collections.Generic;
using UnityEngine;

public enum GameResource
{
    Humans,
    Food,
    Wood,
    Stone,
    Gold,
    HumansProdLvl,
    FoodProdLvl,
    WoodProdLvl,
    StoneProdLvl,
    GoldProdLvl
}

public class ResourceBank : MonoBehaviour
{
    private Dictionary<GameResource, ObservableInt> _resources = new();

    public void ChangeResource(GameResource r, int v)
    {
        if (!_resources.ContainsKey(r))
        {
            _resources[r] = new ObservableInt(0);
        }
        _resources[r].Value += v;
    }

    public ObservableInt GetResource(GameResource r)
    {
        if (!_resources.ContainsKey(r))
        {
            _resources[r] = new ObservableInt(0);
        }
        return _resources[r];
    }
    
    
}
