using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FormEditor;
using FormEditor.Events;
using Umbraco.Core.Models;

namespace uFormEditor.App_Code
{
    public class SaveToCrmWorkflow : IFormEditorWorkflow
    {
        public string Description
        {
            get
            {
                return "Save to CRM workflow";
            }
        }

        public string Name
        {
            get
            {
                return "Save to CRM"; 
            }
        }

        public void ExecuteAfter(FormModel sender, IPublishedContent requestedContent, FormEditorEventArgs formEditorEventArgs)
        {

            var xx = 1;

        }

        public void ExecuteBefore(FormModel sender, IPublishedContent requestedContent, FormEditorCancelEventArgs formEditorCancelEventArgs)
        {
            var xx = 2;
        }
    }
}