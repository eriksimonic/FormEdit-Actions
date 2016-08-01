using System;

namespace FormEditor.Actions
{
    public class FormActionInfo
    {
        public FormActionInfo()
        {
        }
        public static FormActionInfo CreateFromType(Type type)
        {
            var wrkf = Activator.CreateInstance(type) as IFormEditorAction;
            return new FormActionInfo
            {
                Description = wrkf.Description,
                Name = wrkf.Name,
                Type = type.AssemblyQualifiedName
            };
        }

        public string Description { get; private set; }
        public string Name { get; private set; }
        public string Type { get; private set; }
    }
}