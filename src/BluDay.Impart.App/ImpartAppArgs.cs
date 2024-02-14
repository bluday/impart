namespace BluDay.Impart.App;

public sealed class ImpartAppArgs
{
    [CommandLineArg(["-d", "--demo"])]
    public bool DemoMode { get; init; }

    [CommandLineArg(["--skip_intro"])]
    public bool SkipIntro { get; init; }

    [CommandLineArg(["-v", "--verbose"], constant: 1)]
    public int Verbosity { get; init; }

    [CommandLineArg(["-t", "--theme"], actionType: ArgActionType.ParseValue)]
    public string? AppTheme { get; init; }
}