internal class PlayTimeComponent : Component
{
    private int _playTime;

    public override void OnStart()
    {
        base.OnStart();

        UpdatePlayTime();
    }

    public int GetPlayTime()
    {
        UpdatePlayTime();
        return _playTime;
    }

    public string GetFormatedPlayTime()
    {
        string textTime = _playTime.ToString("D6");

        TimeSpan timeSpan = TimeSpan.ParseExact(textTime, "hhmmss", null);

        return timeSpan.ToString();
    }

    private void UpdatePlayTime()
    {
        _playTime = (int)DateTimeOffset.Now.ToUnixTimeSeconds() - _playTime;
    }
}
