using System;

namespace uFormEditor.App_Code
{
    public class FormWorkflowInfo
    {
        public FormWorkflowInfo()
        {
        }
        public static FormWorkflowInfo CreateFromType(Type type)
        {
            var wrkf = Activator.CreateInstance(type) as IFormEditorWorkflow;
            return new FormWorkflowInfo
            {
                Description = wrkf.Description,
                Name = wrkf.Name,
                Type = type.FullName
            };
        }

        public string Description { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
    }
}