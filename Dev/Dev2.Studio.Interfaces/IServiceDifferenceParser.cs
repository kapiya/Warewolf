﻿/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2019 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common;
using System.Activities.Presentation;
using System.Collections.Generic;

namespace Dev2.Studio.Interfaces
{
    public interface IServiceDifferenceParser
    {
        (List<ConflictTreeNode> currentTree, List<ConflictTreeNode> diffTree) GetDifferences(IContextualResourceModel current, IContextualResourceModel difference);
        (List<ConflictTreeNode> currentTree, List<ConflictTreeNode> diffTree) GetDifferences(IContextualResourceModel current, IContextualResourceModel difference, bool loadDiffFromLocalServer);

        List<ConflictTreeNode> BuildWorkflow(System.Text.StringBuilder xaml);
    }
}