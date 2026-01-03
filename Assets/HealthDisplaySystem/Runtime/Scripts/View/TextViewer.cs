using UnityEngine;
using TMPro;

public class TextViewer : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        if (_health != null)
        {
            _health.DamageTaken += UpdateText;
            _health.Healed += UpdateText;
        }
    }

    private void Start()
    {
        UpdateText();
    }

    private void OnDisable()
    {
        if (_health != null)
        {
            _health.DamageTaken -= UpdateText;
            _health.Healed -= UpdateText;
        }
    }

    private void UpdateText()
    {
        if (_text != null)
        {
            _text.text = $"{_health.CurrentHealth}/{_health.Max}";
        }
    }
}
