﻿using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.Windows.Input;
using Warewolf.UI.Tests.WorkflowTab.WorkflowTabUIMapClasses;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
using System.Drawing;
using TechTalk.SpecFlow;
using Warewolf.UI.Tests.Explorer.ExplorerUIMapClasses;
using Warewolf.UI.Tests.WorkflowServiceTesting.WorkflowServiceTestingUIMapClasses;
using Warewolf.UI.Tests.DialogsUIMapClasses;

namespace Warewolf.UI.Tests.Scheduler.SchedulerUIMapClasses
{
    [Binding]
    public partial class SchedulerUIMap
    {
        WorkflowTabUIMap WorkflowTabUIMap
        {
            get
            {
                if (_WorkflowTabUIMap == null)
                {
                    _WorkflowTabUIMap = new WorkflowTabUIMap();
                }

                return _WorkflowTabUIMap;
            }
        }

        private WorkflowTabUIMap _WorkflowTabUIMap;

        WorkflowServiceTestingUIMap WorkflowServiceTestingUIMap
        {
            get
            {
                if (_WorkflowServiceTestingUIMap == null)
                {
                    _WorkflowServiceTestingUIMap = new WorkflowServiceTestingUIMap();
                }

                return _WorkflowServiceTestingUIMap;
            }
        }

        private WorkflowServiceTestingUIMap _WorkflowServiceTestingUIMap;

        ExplorerUIMap ExplorerUIMap
        {
            get
            {
                if (_ExplorerUIMap == null)
                {
                    _ExplorerUIMap = new ExplorerUIMap();
                }

                return _ExplorerUIMap;
            }
        }

        private ExplorerUIMap _ExplorerUIMap;

        DialogsUIMap DialogsUIMap
        {
            get
            {
                if (_DialogsUIMap == null)
                {
                    _DialogsUIMap = new DialogsUIMap();
                }

                return _DialogsUIMap;
            }
        }

        private DialogsUIMap _DialogsUIMap;

        UIMap UIMap
        {
            get
            {
                if (_UIMap == null)
                {
                    _UIMap = new UIMap();
                }

                return _UIMap;
            }
        }

        private UIMap _UIMap;

        [When("I create a new scheduled task using shortcut")]
        public void Create_Scheduler_Using_Shortcut()
        {
            Mouse.Click(MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SchedulerTab.ContentDockManager.SchedulerView.SchedulesList, new Point(151, 13));
            Keyboard.SendKeys(MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SchedulerTab.ContentDockManager.SchedulerView.SchedulesList, "N", ModifierKeys.Control);
        }

        [When(@"I Enter LocalSchedulerAdmin Credentials Into Scheduler Tab")]
        public void Enter_LocalSchedulerAdminCredentials_Into_SchedulerTab()
        {
            MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SchedulerTab.ContentDockManager.SchedulerView.UserNameTextBoxEdit.Text = @"LocalSchedulerAdmin";
            MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SchedulerTab.ContentDockManager.SchedulerView.PasswordTextbox.Text = "987Sched#@!";
        }

        [When(@"I Click Scheduler Create New Task Button")]
        public void Click_Scheduler_NewTaskButton()
        {
            Mouse.Click(MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SchedulerTab.ContentDockManager.SchedulerView.SchedulesList.ScheduleNewTaskListItem.SchedulerNewTaskButton, new Point(151, 13));
        }

        public void Click_SchedulerTab_CloseButton()
        {
            Mouse.Click(MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SchedulerTab.CloseButton);
        }

        [When(@"I Click Erase Schedule Button")]
        public void Click_Schedule_EraseSchedulerButton()
        {
            Mouse.Click(MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SchedulerTab.ContentDockManager.SchedulerView.SchedulesList.GenericResourceListItem.EraseScheduleButton, new Point(6, 16));
        }

        [When("I delete the UI Load Test scheduled task")]
        public void Delete_First_Scheduled_Task()
        {
            Mouse.Click(MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SchedulerTab.ContentDockManager.SchedulerView.SchedulesList.UILoadTestiListItem.EnabledCheckbox);
            Mouse.Click(MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SchedulerTab.ContentDockManager.SchedulerView.SchedulesList.UILoadTestiListItem.DeleteButton, new Point(6, 16));
            Mouse.Click(DialogsUIMap.MessageBoxWindow.YesButton);
        }

        [When(@"I Click Scheduler Enable Disable Checkbox Button")]
        public void Click_HelloWorldSchedule_EnableOrDisableCheckbox()
        {
            Mouse.Click(MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SchedulerTab.ContentDockManager.SchedulerView.SchedulesList.GenericResourceListItem.EnableOrDisableCheckBox);
        }

        [When(@"I Click Scheduler ResourcePicker Button")]
        public void Click_Scheduler_ResourcePickerButton()
        {
            Mouse.Click(MainStudioWindow.DockManager.SplitPaneMiddle.TabManSplitPane.TabMan.SchedulerTab.ContentDockManager.SchedulerView.ResourcePickerButton, new Point(14, 13));
        }
    }
}
