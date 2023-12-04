
/// <summary>
/// The interface of the animation. 
/// 
/// The methods return the animation instance so that the animation commands can be chained.
/// </summary>
public interface IAnimation
{
    void UpdateAnimation();

    IAnimation PlayAnimation();

    IAnimation PlayReversed();

    IAnimation Pause();
}
