namespace BluDay.Impart.App;

public sealed class ImpartAppArgs : IArgs
{
    [
        Arg(
            ["-d", "--demo-mode"],
            Description = "To run the app in a demo mode."
        )
    ]
    public bool DemoMode { get; }

    [
        Arg(
            ["-b", "--performance-mode"],
            Description = "Not a real arg yet haha."
        )
    ]
    public bool PerformanceMode { get; }

    [
        Arg(
            ["--skip-intro"],
            Description = "Skip first-time launch introduction."
        )
    ]
    public bool SkipIntro { get; }

    [
        Arg(
            ["-v", "--verbose"],
            ValueType   = typeof(uint),
            Constant    = (uint)1,
            Description = "Verbosity level for logs from 1 to 4."
        )
    ]
    public uint Verbosity { get; }

    [
        Arg(
            ["-t", "--theme"],
            ValueType   = typeof(string),
            ActionType  = ArgActionType.ParseValue,
            Description = "Application theme to use."
        )
    ]
    public string? AppTheme { get; }
}