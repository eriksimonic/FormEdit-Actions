using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web.Editors;
using Umbraco.Web.WebApi;

namespace uFormEditor.App_Code.Controllers
{
    [IsBackOffice]
    public class FormEditorWorkflowApiController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<FormWorkflowInfo> GetRegisteredWorkflows()
        {
            var response = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(s => s.GetTypesWithInterface<IFormEditorWorkflow>())
                            .Select(FormWorkflowInfo.CreateFromType)
                            .ToList();

            return response;
        }
    }
}