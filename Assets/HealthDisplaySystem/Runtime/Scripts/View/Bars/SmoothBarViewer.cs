using UnityEngine;
using UnityEngine.UI;

public class SmoothBarViewer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _sliderSpeed = 1f;
        
    private float _targetHealth;

    private void OnEnable()
    {
        if (_health != null)
        {
            _health.DamageTaken += OnHealthChanged;
            _health.Healed += OnHealthChanged;
        }
    }

    private void Start()
    {
        if (_health != null && _slider != null)
        {
            _slider.minValue = 0f;
            _slider.maxValue = _health.Max;
            _targetHealth = _health.CurrentHealth;
            _slider.value = _targetHealth;
        }
    }

    private void Update()
    {
        float nearZero = 0.001f;

        if (Mathf.Abs(_slider.value - _targetHealth) > nearZero)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetHealth, _sliderSpeed * Time.deltaTime * _health.Max);
        }
    }

    private void OnDisable()
    {
        if (_health != null)
        {
            _health.DamageTaken -= OnHealthChanged;
            _health.Healed -= OnHealthChanged;
        }
    }

    private void OnHealthChanged()
    {
        _targetHealth = _health.CurrentHealth;
    }
}