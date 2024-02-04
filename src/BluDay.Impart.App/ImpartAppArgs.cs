namespace BluDay.Impart.App;

public sealed class ImpartAppArgs
{
    [CommandLineArgument(["-t", "--theme"], actionType: ArgumentActionType.ParseValue)]
    public AppTheme AppTheme { get; init; }

    [CommandLineArgument(["-d", "--demo"])]
    public bool DemoMode { get; init; }

    [CommandLineArgument(["--skip_intro"])]
    public bool SkipIntro { get; init; }

    [CommandLineArgument(["-v", "--verbose"], constant: 1)]
    public int Verbosity { get; init; }
}