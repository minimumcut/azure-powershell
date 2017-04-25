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

namespace Microsoft.Azure.Commands.LogicApp.Cmdlets
{
    using System.Management.Automation;
    using Microsoft.Azure.Commands.LogicApp.Utilities;

    /// <summary>
    /// Gets the integration account received X12 interchange control number by agreement name and control number value.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmIntegrationAccountReceivedX12Icn")]
    [OutputType(typeof(IntegrationAccountControlNumber))]
    public class GetAzureIntegrationAccountReceivedX12IcnCommand : LogicAppBaseCmdlet
    {
        #region Input Parameters

        /// <summary>
        /// Gets or sets the resource group name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        /// <summary>
        /// Gets or sets the integration account name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The integration account name.")]
        [Alias("ResourceName")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the agreement name.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The integration account agreement name.")]
        [ValidateNotNullOrEmpty]
        public string AgreementName { get; set; }

        /// <summary>
        /// Gets or sets the control number value.
        /// </summary>
        [Parameter(Mandatory = true, HelpMessage = "The integration account control number value.")]
        [ValidateNotNullOrEmpty]
        public string ControlNumberValue { get; set; }

        #endregion Input Parameters

        /// <summary>
        /// Executes the get integration account X12 control number command.
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();

            this.WriteObject(
                sendToPipeline: this.IntegrationAccountClient.GetIntegrationAccountReceivedControlNumber(
                    resourceGroupName: this.ResourceGroupName,
                    integrationAccountName: this.Name,
                    integrationAccountAgreementName: this.AgreementName,
                    agreementType: Management.Logic.Models.AgreementType.X12,
                    controlNumber: this.ControlNumberValue));
        }
    }
}