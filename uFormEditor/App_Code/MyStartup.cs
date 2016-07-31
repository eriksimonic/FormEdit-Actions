using System;
using System.Web;
using FormEditor;
using FormEditor.Events;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace uFormEditor.App_Code
{
    public class MyStartup : ApplicationEventHandler
    {
        protected override void ApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            FormModel.BeforeAddToIndex += FormModelOnBeforeAddToIndex;
            FormModel.AfterAddToIndex += FormModelOnAfterAddToIndex;
        }

        private void FormModelOnBeforeAddToIndex(FormModel sender, FormEditorCancelEventArgs formEditorCancelEventArgs)
        {

           // sender.

            var requestedContent = GetRequestedContent();
            if (requestedContent == null)
            {
                return;
            }

            if (requestedContent.HasProperty("workflow") && requestedContent.GetPropertyValue<string>("workflow") != null)
            {
                ExecuteAction(sender, requestedContent, formEditorCancelEventArgs);
            }
        }


        private void FormModelOnAfterAddToIndex(FormModel sender, FormEditorEventArgs formEditorEventArgs)
        {
            var requestedContent = GetRequestedContent();
            if (requestedContent == null)
            {
                return;
            }

            if (requestedContent.HasProperty("workflow") && requestedContent.GetPropertyValue<string>("workflow") != null)
            {
                ExecuteAction(sender, requestedContent, formEditorEventArgs);
            }
        }


        private void ExecuteAction(FormModel sender, IPublishedContent requestedContent, FormEditorCancelEventArgs formEditorCancelEventArgs)
        {
            FormEditorWorkflow workflow = (FormEditorWorkflow)Activator.CreateInstance(Type.GetType(requestedContent.GetPropertyValue<string>("workflow")));
            workflow.ExecuteBefore(sender, requestedContent, formEditorCancelEventArgs);
        }
        private void ExecuteAction(FormModel sender, IPublishedContent requestedContent, FormEditorEventArgs formEditorEventArgs)
        {
            FormEditorWorkflow workflow = (FormEditorWorkflow)Activator.CreateInstance(Type.GetType(requestedContent.GetPropertyValue<string>("workflow")));
            workflow.ExecuteAfter(sender, requestedContent, formEditorEventArgs);
        }

        private IPublishedContent GetRequestedContent()
        {
            if (UmbracoContext.Current.IsFrontEndUmbracoRequest)
            {
                return UmbracoContext.Current.PublishedContentRequest.PublishedContent;
            }
            var id = HttpContext.Current.Request.Form["_id"];
            int contentId;
            if (id != null && int.TryParse(id, out contentId))
            {
                return UmbracoContext.Current.ContentCache.GetById(contentId);
            }
            return null;
        }
    }

    public class FormEditorWorkflow : IFormEditorWorkflow
    {
        public string Description
        {
            get
            {
                return "My Workflow";
            }
        }

        public string Name
        {
            get
            {
                return "workflow01";
            }
        }

        public void ExecuteAfter(FormModel sender, IPublishedContent requestedContent, FormEditorEventArgs formEditorEventArgs)
        {
            
        }

        public void ExecuteBefore(FormModel sender, IPublishedContent requestedContent, FormEditorCancelEventArgs formEditorCancelEventArgs)
        {
            
        }
    }


    public interface IFormEditorWorkflow
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