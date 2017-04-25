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
    using System.Globalization;
    using Microsoft.Azure.Commands.LogicApp.Utilities;
    using System.Management.Automation;

    /// <summary>
    /// Removes the integration account X12 received interchange control number.
    /// </summary>
    /// <remarks>As the underlying resource provider does not return the deleted entity, there is no output to this cmdlet and no PassThru parameter either.</remarks>
    [Cmdlet(VerbsCommon.Remove, "AzureRmIntegrationAccountReceivedX12Icn", SupportsShouldProcess = true)]
    public class RemoveAzureIntegrationAccountReceivedX12IcnCommand : LogicAppBaseCmdlet
    {
        #region Input Paramters

        [Parameter(
            Mandatory = true,
            HelpMessage = "The integration account resource group name.",
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, HelpMessage = "The integration account name.")]
        [ValidateNotNullOrEmpty]
        [Alias("IntegrationAccountName", "ResourceName")]
        public string Name { get; set; }

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
        /// Executes the command to remove integration account X12 control number
        /// </summary>
        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            this.ConfirmAction(
                processMessage: string.Format(CultureInfo.InvariantCulture, Properties.Resource.RemoveResourceMessage, "received control number", this.Name),
                target: Name,
                action : () => {
                    IntegrationAccountClient.RemoveIntegrationAccountReceivedControlNumber(
                        resourceGroupName: this.ResourceGroupName,
                        integrationAccountName: this.Name,
                        integrationAccountAgreementName: this.AgreementName,
                        agreementType: Management.Logic.Models.AgreementType.X12,
                        controlNumber: this.ControlNumberValue);
                });
        }
    }
}