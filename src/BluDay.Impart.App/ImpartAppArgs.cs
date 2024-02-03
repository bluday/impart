namespace BluDay.Impart.App;

[CommandLineArgs]
public sealed class ImpartAppArgs
{
    [CommandLineArg("-v", "--verbose", Required = true)]
    public int Verbose { get; init; }
}