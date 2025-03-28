using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProductionBuilding : MonoBehaviour
{
    [SerializeField] private GameResource _resource;
    [SerializeField] private Button _button;
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private float _baseProductionTime = 3f;
    
    private ResourceBank _bank;
    private GameResource _prodLvlResource;

    private void Start()
    {
        _bank = FindObjectOfType<ResourceBank>();
        _button.onClick.AddListener(StartProduction);
        _progressSlider.gameObject.SetActive(false);
        
        _prodLvlResource = GetProductionLevelResource();
    }

    private GameResource GetProductionLevelResource()
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

    private float GetProductionTime()
    {
        float prodLvl = _bank.GetResource(_prodLvlResource).Value;
        return _baseProductionTime * (1 - prodLvl / 100f);
    }

    private void StartProduction()
    {
        StartCoroutine(ProductionCoroutine());
    }

    private IEnumerator ProductionCoroutine()
    {
        _button.interactable = false;
        _progressSlider.gameObject.SetActive(true);
        
        float productionTime = GetProductionTime();
        float timer = 0;
        
        while (timer < productionTime)
        {
            timer += Time.deltaTime;
            _progressSlider.value = timer / productionTime;
            yield return null;
        }
        
        _bank.ChangeResource(_resource, 1);
        _progressSlider.gameObject.SetActive(false);
        _button.interactable = true;
    }
}