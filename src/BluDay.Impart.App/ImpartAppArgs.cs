namespace BluDay.Impart.App;

public sealed class ImpartAppArgs
{
    [CommandLineArgument(["-t", "--theme"], actionType: ArgumentActionType.ParseValue)]
    public AppTheme? AppTheme { get; init; }

    [CommandLineArgument(["-d", "--demo"])]
    public bool? DemoMode { get; init; }

    [
        CommandLineArgument(
            identifiers: ["-v", "-vv", "-vvv", "-vvvv", "--verbose"],
            actionType:  ArgumentActionType.AddConstant,
            constant:    1
        )
    ]
    public int Verbosity { get; init; }
}