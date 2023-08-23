using BluDay.Common;
using BluDay.Common.Types;
using BluDay.Common.Extensions;
using System;
using System.Collections.Generic;

namespace BluDay.Common.ViewManagement
{
    public sealed class BluView : IEquatable<BluView>, IBluRelative<BluView>
    {
        private Type _viewModelType;

        private BluView _parent;

        private IReadOnlyList<BluView> _children;

        public string Name { get; }

        public Guid Id => ViewType.GUID;

        public Type ViewType { get; }
        
        public Type ViewModelType
        {
            get => _viewModelType;
            set
            {
                if (!(value is null))
                {
                    BluValidator.ValidateViewModelType(value);
                }

                _viewModelType = value;
            }
        }

        public BluViewInfo Info { get; }

        public BluView Parent
        {
            get => _parent;
            set
            {
                if (value == this)
                {
                    throw new InvalidOperationException("Should not self-suck.");
                }

                if (value.HasPredecessor(this))
                {
                    throw new InvalidOperationException("Don't do that.");
                }

                _parent = value;
            }
        }

        public IReadOnlyList<BluView> Children
        {
            get => _children;
            set
            {
                value = value ?? new BluView[] { };

                foreach (var child in value)
                {
                    if (child.HasSuccessor(this))
                    {
                        throw new InvalidOperationException("Don't you effing dare.");
                    }

                    child.Parent = this;
                }

                _children = value;
            }
        }

        public BluView(Type viewType)
        {
            BluValidator.ValidateViewType(viewType);

            ViewType = viewType;

            Name = GetSuggestedName(viewType);

            Info = new BluViewInfo(viewInfo: this);

            Children = null;
        }

        public bool Equals(BluView target)
        {
            return GetHashCode() == target?.GetHashCode();
        }

        public override bool Equals(object source)
        {
            return Equals(source as BluViewInfo);
        }

        public override int GetHashCode()
        {
            return ViewType.GetHashCode() ^ Name.GetHashCode();
        }

        public override string ToString()
        {
            return "{0} (Id: {1}, Types: <{2}, {3}>, Name: \"{4}\")".BluFormat(
                nameof(BluView),
                Id,
                ViewType.Name,
                ViewModelType?.Name ?? BluConstants.None,
                Name
            );
        }

        public static bool operator == (BluView source, BluView target)
        {
            return source?.Equals(target) is true;
        }

        public static bool operator != (BluView source, BluView target)
        {
            return !(source == target);
        }

        public static string GetDefaultName(BluView view)
        {
            BluValidator.NotNull(view, nameof(view));

            return $"{view.Id}_{GetSuggestedName(view.ViewType)}";
        }

        public static string GetSuggestedName(Type viewType)
        {
            BluValidator.NotNull(viewType, nameof(viewType));

            return viewType.Name.BluRemove(BluConstants.View);
        }

        public static Predicate<BluView> GetPredicateByPropertyValue(object value)
        {
            if (value is Guid)
            {
                return view => view.Id == value as Guid?;
            }

            if (value is string)
            {
                return view => view.Name == value as string;
            }

            return view => view.ViewType == value as Type;
        }
    }
}