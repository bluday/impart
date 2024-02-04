namespace BluDay.Impart.App;

public sealed class ImpartAppArgs
{
    [CommandLineArg(["-t", "--theme"], actionType: ArgActionType.ParseValue)]
    public AppTheme AppTheme { get; init; }

    [CommandLineArg(["-d", "--demo"])]
    public bool DemoMode { get; init; }

    [CommandLineArg(["--skip_intro"])]
    public bool SkipIntro { get; init; }

    [CommandLineArg(["-v", "--verbose"], constant: 1)]
    public int Verbosity { get; init; }
}