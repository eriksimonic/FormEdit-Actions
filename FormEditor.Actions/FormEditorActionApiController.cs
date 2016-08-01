using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Web.Editors;
using Umbraco.Web.WebApi;

namespace FormEditor.Actions.Controllers
{
    [IsBackOffice]
    public class FormEditorActionApiController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<FormActionInfo> GetRegisteredActions()
        {
            var response = AppDomain.CurrentDomain.GetAssemblies()
                            .SelectMany(s => s.GetTypesWithInterface<IFormEditorAction>())
                            .Select(FormActionInfo.CreateFromType)
                            .ToList();

            return response;
        }
    }
}