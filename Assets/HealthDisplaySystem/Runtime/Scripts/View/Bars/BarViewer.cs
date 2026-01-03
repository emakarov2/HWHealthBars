using UnityEngine;
using UnityEngine.UI;

public class BarViewer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;

    private void OnEnable()
    {
        if (_health != null)
        {
            _health.DamageTaken += UpdateBar;
            _health.Healed += UpdateBar;
        }
    }

    private void Start()
    {
        if (_slider != null && _health != null )
        {
            _slider.minValue = 0f;
            _slider.maxValue = _health.Max;
            _slider.value = _health.CurrentHealth;
        }
    }

    private void OnDisable()
    {
        if (_health != null) 
        {
            _health.DamageTaken -= UpdateBar;
            _health.Healed -= UpdateBar;
        }
    }

    private void UpdateBar()
    {
        _slider.value = _health.CurrentHealth;
    }
}
