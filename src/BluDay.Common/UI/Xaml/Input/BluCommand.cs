using System;

namespace BluDay.Common.UI.Xaml.Input
{
    public sealed class BluCommand : BluCommand<object>
    {
        public BluCommand(Action<object> execute) : base(execute, null) { }

        public BluCommand(Action<object> execute, Predicate<object> canExecute)
            : base(execute, canExecute) { }
    }
}