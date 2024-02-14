namespace BluDay.Impart.App;

public sealed class ImpartAppArgs
{
    [CommandLineArg(["-d", "--demo"])]
    public bool DemoMode { get; }

    [CommandLineArg(["--skip_intro"])]
    public bool SkipIntro { get; }

    [CommandLineArg(["-v", "--verbose"], constant: 1)]
    public int Verbosity { get; }

    [CommandLineArg(["-t", "--theme"], actionType: ArgActionType.ParseValue)]
    public string? AppTheme { get; }
}