public class Decrease : ButtonChange
{
public override void OnClick()
    {
        if(_health != null)
        {
            _health.Decrease(_amount);
        }
    }
}
