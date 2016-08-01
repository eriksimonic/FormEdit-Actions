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
                ExecuteAction(sender, e.Content, e);
            }
        }
        private void FormModelOnAfterAddToIndex(FormModel sender, FormEditorEventArgs e)
        {
            if (e.Content.HasProperty(WORKFLOW) && null != e.Content.GetPropertyValue<string>(WORKFLOW))
            {
                ExecuteAction(sender, e.Content, e);
            }
        }
        private void ExecuteAction(FormModel sender, IPublishedContent requestedContent, FormEditorCancelEventArgs formEditorCancelEventArgs)
        {

            IFormEditorAction actions = (IFormEditorAction)Activator.CreateInstance(Type.GetType(requestedContent.GetPropertyValue<string>(WORKFLOW)));
            actions.ExecuteBefore(sender, requestedContent, formEditorCancelEventArgs);
        }
        private void ExecuteAction(FormModel sender, IPublishedContent requestedContent, FormEditorEventArgs e)
        {
            IFormEditorAction actions = (IFormEditorAction)Activator.CreateInstance(Type.GetType(requestedContent.GetPropertyValue<string>(WORKFLOW)));
            actions.ExecuteAfter(sender, requestedContent , e);
        }
    }




    
}