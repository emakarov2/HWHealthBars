public class Increase : ButtonChange
{
    public override void OnClick()
    {
        if (_health != null)
        {
            _health.Increase(_amount);
        }
    }
}
