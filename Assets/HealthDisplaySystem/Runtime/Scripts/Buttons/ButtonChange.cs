using UnityEngine;

public abstract class ButtonChange : MonoBehaviour
{
    [SerializeField] protected Health _health;
    [SerializeField] protected float _amount = 10f;

    protected virtual void Start()
    {
        if (_health == null)
        {
            enabled = false;
        }
    }

    public abstract void OnClick();
}
