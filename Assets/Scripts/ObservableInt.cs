using System;

[Serializable]
public class ObservableInt
{
    public event Action<int> OnValueChanged;
    
    private int _value;
    
    public int Value
    {
        get => _value;
        set
        {
            if (_value != value)
            {
                _value = value;
                OnValueChanged?.Invoke(_value);
            }
        }
    }
    
    public ObservableInt(int initialValue)
    {
        _value = initialValue;
    }
}