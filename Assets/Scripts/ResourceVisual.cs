using TMPro;
using UnityEngine;

public class ResourceVisual : MonoBehaviour
{
    [SerializeField] private GameResource _resource;
    [SerializeField] private TMP_Text _text;
    
    private ResourceBank _bank;

    private void Start()
    {
        _bank = FindObjectOfType<ResourceBank>();
        if (_bank == null)
        {
            Debug.LogError("ResourceBank not found in scene!");
            return;
        }
    
        var resource = _bank.GetResource(_resource);
        if (resource == null)
        {
            Debug.LogError($"Resource {_resource} not found in bank!");
            return;
        }
    
        resource.OnValueChanged += UpdateText;
        UpdateText(resource.Value); // Инициализируем начальное значение
    }

    private void UpdateText(int value)
    {
        _text.text = $"{_resource}: {value}";
    }
}