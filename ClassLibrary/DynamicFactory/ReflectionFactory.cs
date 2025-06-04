using System;
using System.Reflection;

namespace ShapeLib.DynamicFactory
{
    public class ReflectionFactory<T>
    {
        private readonly Assembly _assembly;
        private readonly string _namespace;

        public ReflectionFactory()
        {
            _assembly = Assembly.GetExecutingAssembly();
            _namespace = typeof(T).Namespace;
        }

        public T Create(string typeName, params object[] args)
        {
            var fullTypeName = $"{_namespace}.{typeName}";
            var type = _assembly.GetType(fullTypeName);
            if (type == null || !typeof(T).IsAssignableFrom(type))
            {
                throw new ArgumentException($"Type {typeName} is not a valid");
            }

            return (T)Activator.CreateInstance(type, args)!;
        }
    }
}