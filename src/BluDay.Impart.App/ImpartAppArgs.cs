namespace BluDay.Impart.App;

public sealed class ImpartAppArgs
{
    [Arg(["-d", "--demo"])]
    public bool DemoMode { get; }

    [Arg(["--skip_intro"])]
    public bool SkipIntro { get; }

    [Arg(["-v", "--verbose"], constant: 1)]
    public int Verbosity { get; }

    [Arg(["-t", "--theme"], actionType: ArgActionType.ParseValue)]
    public string? AppTheme { get; }
}