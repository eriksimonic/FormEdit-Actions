using System;
using System.Web;
using FormEditor;
using FormEditor.Events;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace FormEditor.Actions
{
    public class FormEditorActionsStartup : ApplicationEventHandler
    {

        private const string WORKFLOW = "actions";

        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            FormModel.BeforeAddToIndex += FormModelOnBeforeAddToIndex;
            FormModel.AfterAddToIndex += FormModelOnAfterAddToIndex;
        }

        private void FormModelOnBeforeAddToIndex(FormModel sender, FormEditorCancelEventArgs e)
        {
            if (e.Content.HasProperty(WORKFLOW) && null != e.Content.GetPropertyValue<string>(WORKFLOW))
            {
                ExecuteAction(sender, e.Content, e, e.Content.GetPropertyValue<string>(WORKFLOW));
            }
        }
        private void FormModelOnAfterAddToIndex(FormModel sender, FormEditorEventArgs e)
        {
            if (e.Content.HasProperty(WORKFLOW) && null != e.Content.GetPropertyValue<string>(WORKFLOW))
            {
                ExecuteAction(sender, e.Content, e, e.Content.GetPropertyValue<string>(WORKFLOW));
            }
        }
        private IFormEditorAction CreateWorkflowInstance(string asm)
        {
            var type = Type.GetType(asm);
            return (IFormEditorAction)Activator.CreateInstance(type);
            //IFormEditorAction actions = (IFormEditorAction)Activator.CreateInstance(asm[0], asm[1]);
        }

        private void ExecuteAction(FormModel sender, IPublishedContent requestedContent, FormEditorCancelEventArgs formEditorCancelEventArgs, string workflow)
        {
              CreateWorkflowInstance(workflow).ExecuteBefore(sender, requestedContent, formEditorCancelEventArgs);
        }
        private void ExecuteAction(FormModel sender, IPublishedContent requestedContent, FormEditorEventArgs e, string workflow)
        {
            CreateWorkflowInstance(workflow).ExecuteAfter(sender, requestedContent , e);
        }
    }




    
}