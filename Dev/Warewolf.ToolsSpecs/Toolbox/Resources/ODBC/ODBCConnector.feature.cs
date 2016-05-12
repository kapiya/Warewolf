﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Warewolf.ToolsSpecs.Toolbox.Resources.ODBC
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class ODBCConnectorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ODBCConnector.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ODBCConnector", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
                    "wo numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "ODBCConnector")))
            {
                Warewolf.ToolsSpecs.Toolbox.Resources.ODBC.ODBCConnectorFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Creating ODBC Server Connector")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ODBCConnector")]
        public virtual void CreatingODBCServerConnector()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Creating ODBC Server Connector", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line 7
 testRunner.Given("I drag a ODBC Server database connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.And("Source is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
 testRunner.And("Action is Disable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 10
 testRunner.And("Inputs is Disable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
 testRunner.And("Outputs is Disable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
 testRunner.When("I Selected \"GreenPoint\" as Source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then("Action is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.When("I selected \"Command\" as thee action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 15
 testRunner.Then("Inputs is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table1.AddRow(new string[] {
                        "EID",
                        "",
                        "false"});
#line 16
 testRunner.And("Inputs appears as", ((string)(null)), table1, "And ");
#line 19
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.When("I click Validate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 21
 testRunner.Then("the Test Connector and Calculate Outputs window is open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 22
 testRunner.When("I click Test", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Column1"});
            table2.AddRow(new string[] {
                        "1"});
#line 23
 testRunner.Then("Test Connector and Calculate Outputs outputs appear as", ((string)(null)), table2, "Then ");
#line 26
 testRunner.When("I clicked OKay", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table3.AddRow(new string[] {
                        "Column1",
                        "[[Command().Column1]]"});
#line 27
 testRunner.Then("Outputs appears as", ((string)(null)), table3, "Then ");
#line 30
 testRunner.And("Recordset Name equal \"Command\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Opening Saved workflow with ODBC Server tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ODBCConnector")]
        public virtual void OpeningSavedWorkflowWithODBCServerTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Opening Saved workflow with ODBC Server tool", ((string[])(null)));
#line 32
this.ScenarioSetup(scenarioInfo);
#line 33
 testRunner.Given("I open workflow with ODBC connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
 testRunner.And("Source is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("Source is \"localODBCTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.And("Action is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("Inputs is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table4.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 39
 testRunner.Then("Inputs appears as", ((string)(null)), table4, "Then ");
#line 42
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table5.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table5.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 43
 testRunner.Then("Outputs appears as", ((string)(null)), table5, "Then ");
#line 47
 testRunner.And("Recordset Name equal \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Change ODBC Source on Existing tool")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ODBCConnector")]
        public virtual void ChangeODBCSourceOnExistingTool()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change ODBC Source on Existing tool", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given("I open workflow with ODBC connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.And("Source is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("Source is \"localODBCTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("Action is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.And("Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("Inputs is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table6.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 56
 testRunner.Then("Inputs appears as", ((string)(null)), table6, "Then ");
#line 59
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table7.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table7.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 60
 testRunner.Then("Outputs appears as", ((string)(null)), table7, "Then ");
#line 64
 testRunner.And("Recordset Name equal \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.When("Source is changed to \"GreenPoint\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 66
 testRunner.And("Action is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("Inputs is Disable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("Outputs is Disable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Editing ODBC Service and Test Execution is unsuccesful")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ODBCConnector")]
        public virtual void EditingODBCServiceAndTestExecutionIsUnsuccesful()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Editing ODBC Service and Test Execution is unsuccesful", ((string[])(null)));
#line 72
 this.ScenarioSetup(scenarioInfo);
#line 73
   testRunner.Given("I open \"InsertDummyUser\" service", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 74
   testRunner.And("\"InsertDummyUser\" tab is opened", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
   testRunner.Then("\"1 Data Source\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 76
   testRunner.And("Data Source is focused", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
   testRunner.When("\"DemoDB\" is selected as the data source", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 78
   testRunner.Then("\"2 Select Action\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 79
   testRunner.And("\"dbo.InsertDummyUser\" is selected as the action", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
   testRunner.Then("\"3 Test Connector and Calculate Outputs\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 81
   testRunner.And("Inspect Data Connector hyper link is \"Visible\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "fname",
                        "lname",
                        "username",
                        "password",
                        "lastAccessDate"});
            table8.AddRow(new string[] {
                        "Change",
                        "Test",
                        "wolf",
                        "Dev",
                        "10/1/1990"});
#line 82
   testRunner.And("inputs are", ((string)(null)), table8, "And ");
#line 85
   testRunner.And("\"Validate\" is \"Enabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 86
   testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 87
   testRunner.When("testing the action fails", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 88
   testRunner.Then("\"4 Defaults and Mapping\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "Inputs",
                        "Default Value",
                        "Required Field",
                        "Empty is Null"});
#line 89
   testRunner.And("input mappings are", ((string)(null)), table9, "And ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Output",
                        "Output Alias",
                        "Recordset Name"});
#line 91
 testRunner.And("output mappings are", ((string)(null)), table10, "And ");
#line 93
 testRunner.And("\"Save\" is \"Disabled\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Changing ODBC Actions")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ODBCConnector")]
        public virtual void ChangingODBCActions()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Changing ODBC Actions", ((string[])(null)));
#line 96
this.ScenarioSetup(scenarioInfo);
#line 97
 testRunner.Given("I open workflow with ODBC connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 98
 testRunner.And("Source is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("Source is \"localODBCTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 100
 testRunner.And("Action is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 101
 testRunner.And("Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 102
 testRunner.And("Inputs is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table11.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 103
 testRunner.Then("Inputs appears as", ((string)(null)), table11, "Then ");
#line 106
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table12.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table12.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 107
 testRunner.Then("Outputs appears as", ((string)(null)), table12, "Then ");
#line 111
 testRunner.And("Recordset Name equal \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 112
 testRunner.When("Action is changed to \"dbo.ImportOrder\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
 testRunner.And("Inputs is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table13.AddRow(new string[] {
                        "ProductId",
                        "",
                        "false"});
#line 114
 testRunner.And("Inputs appears as", ((string)(null)), table13, "And ");
#line 117
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Change ODBC Recordset Name")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ODBCConnector")]
        public virtual void ChangeODBCRecordsetName()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change ODBC Recordset Name", ((string[])(null)));
#line 120
this.ScenarioSetup(scenarioInfo);
#line 121
 testRunner.Given("I open workflow with ODBC connector", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 122
 testRunner.And("Source is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 123
 testRunner.And("Source is \"localODBCTest\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 124
 testRunner.And("Action is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 125
 testRunner.And("Action is \"dbo.Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 126
 testRunner.And("Inputs is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Input",
                        "Value",
                        "Empty is Null"});
            table14.AddRow(new string[] {
                        "Prefix",
                        "[[Prefix]]",
                        "false"});
#line 127
 testRunner.Then("Inputs appears as", ((string)(null)), table14, "Then ");
#line 130
 testRunner.And("Validate is Enable", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table15.AddRow(new string[] {
                        "CountryID",
                        "[[dbo_Pr_CitiesGetCountries().CountryID]]"});
            table15.AddRow(new string[] {
                        "Description",
                        "[[dbo_Pr_CitiesGetCountries().Description]]"});
#line 131
 testRunner.Then("Outputs appears as", ((string)(null)), table15, "Then ");
#line 135
 testRunner.And("Recordset Name equal \"dbo_Pr_CitiesGetCountries\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 136
 testRunner.When("Recordset Name is changed from to \"Pr_Cities\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mapped From",
                        "Mapped To"});
            table16.AddRow(new string[] {
                        "CountryID",
                        "[[Pr_Cities().CountryID]]"});
            table16.AddRow(new string[] {
                        "Description",
                        "[[Pr_Cities().Description]]"});
#line 137
 testRunner.Then("Outputs appears as", ((string)(null)), table16, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
