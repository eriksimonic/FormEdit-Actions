using FormEditor;
using FormEditor.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;

namespace FormEditor.Actions
{
    public interface IFormEditorAction
    {
        string Name
        {
            get;
        }
        string Description
        {
            get;
        }

        void ExecuteAfter(FormModel sender, IPublishedContent requestedContent, FormEditorEventArgs formEditorEventArgs);
        void ExecuteBefore(FormModel sender, IPublishedContent requestedContent, FormEditorCancelEventArgs formEditorCancelEventArgs);
    }
}
