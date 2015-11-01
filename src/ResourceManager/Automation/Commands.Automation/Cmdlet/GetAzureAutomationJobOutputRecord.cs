﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Security.Permissions;
using Microsoft.Azure.Commands.Automation.Common;
using Microsoft.Azure.Commands.Automation.Model;

namespace Microsoft.Azure.Commands.Automation.Cmdlet
{
    /// <summary>
    /// Gets azure automation variables for a given account.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmAutomationJobOutputRecord")]
    [OutputType(typeof(JobStream))]
    public class GetAzureAutomationJobOutputRecord : AzureAutomationBaseCmdlet
    {
        /// <summary>
        /// Gets or sets the job id
        /// </summary>
        [Alias("JobId")]
        [Parameter(Mandatory = true, Position = 2, ValueFromPipelineByPropertyName = true, HelpMessage = "The job name or Id")]
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the job stream id
        /// </summary>
        [Parameter(Mandatory = true, Position = 3, ValueFromPipelineByPropertyName = true, HelpMessage = "The stream id")]
        [ValidateNotNullOrEmpty]
        public string JobStreamId { get; set; }
        
        /// <summary>
        /// Execute this cmdlet.
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void AutomationProcessRecord()
        {
            var nextLink = string.Empty;

            var ret = this.AutomationClient.GetJobStreamRecord(this.ResourceGroupName, this.AutomationAccountName, this.Id, this.JobStreamId);
        }
    }
}
