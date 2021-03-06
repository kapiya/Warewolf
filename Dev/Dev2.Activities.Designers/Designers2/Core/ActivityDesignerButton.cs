/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Dev2.Common.Interfaces.Infrastructure.Providers.Validation;
using Dev2.Runtime.Configuration.ViewModels.Base;

namespace Dev2.Activities.Designers2.Core
{
    public class ActivityDesignerButton : Button
    {
        public ActivityDesignerButton()
        {
            IsValid = true;
            Command = new DelegateCommand(CommandAction);
        }

        public bool IsValid { get; private set; }

        public bool IsValidatedBefore
        {
            get { return (bool)GetValue(IsValidatedBeforeProperty); }
            set { SetValue(IsValidatedBeforeProperty, value); }
        }

        public static readonly DependencyProperty IsValidatedBeforeProperty =
            DependencyProperty.Register("IsValidatedBefore", typeof(bool), typeof(ActivityDesignerButton), new PropertyMetadata(false));

        public bool IsClosedAfter
        {
            get { return (bool)GetValue(IsClosedAfterProperty); }
            set { SetValue(IsClosedAfterProperty, value); }
        }

        public static readonly DependencyProperty IsClosedAfterProperty =
            DependencyProperty.Register("IsClosedAfter", typeof(bool), typeof(ActivityDesignerButton), new PropertyMetadata(false));

        public ICommand CustomCommand
        {
            get { return (ICommand)GetValue(CustomCommandProperty); }
            set { SetValue(CustomCommandProperty, value); }
        }

        public static readonly DependencyProperty CustomCommandProperty =
            DependencyProperty.Register("CustomCommand", typeof(ICommand), typeof(ActivityDesignerButton), new PropertyMetadata(default(ICommand)));

        public ICommand PostCommand
        {
            get { return (ICommand)GetValue(PostCommandProperty); }
            set { SetValue(PostCommandProperty, value); }
        }

        public static readonly DependencyProperty PostCommandProperty =
            DependencyProperty.Register("PostCommand", typeof(ICommand), typeof(ActivityDesignerButton), new PropertyMetadata(default(ICommand)));

        void CommandAction(object o)
        {
            var canValidate = IsValidatedBefore;
            if (DataContext is ActivityDesignerViewModel activityDesignerViewModel)
            {
                canValidate &= !activityDesignerViewModel.IsMerge;
            }

            if (canValidate)
            {
                DoValidate();
            }

            if (IsValid)
            {
                CustomCommand?.Execute(null);

                if (IsClosedAfter)
                {
                    DoClose();
                }
            }

            PostCommand?.Execute(null);
        }

        void DoValidate()
        {
            if (DataContext is IValidator validator)
            {
                validator.Validate();
                IsValid = validator.IsValid;
            }
        }

        void DoClose()
        {
            if (DataContext is IClosable closable)
            {
                closable.IsClosed = true;
            }
        }
    }
}
