using System;
using System.Reflection;
using ShapeLib.Shapes;

namespace ShapeLib.DynamicFactory
{
    public class ReflectionShapeFactory
    {
        private readonly Assembly _assembly;
        private readonly string _namespace;

        public ReflectionShapeFactory()
        {
            _assembly = Assembly.GetExecutingAssembly();
            _namespace = typeof(Shape).Namespace;
        }

        public Shape Create(string typeName, params object[] args)
        {
            var fullTypeName = $"{_namespace}.{typeName}";
            var type = _assembly.GetType(fullTypeName);
            if (type == null || !typeof(Shape).IsAssignableFrom(type))
            {
                throw new ArgumentException($"Type {typeName} is not a valid Shape");
            }

            return (Shape) Activator.CreateInstance(type, args)!;
        }
    }
}
