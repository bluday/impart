namespace BluDay.Impart.App;

public sealed class ImpartAppArgs
{
    [CommandLineArg("-v", "--verbose", Required = true)]
    public int Verbose { get; init; }
}