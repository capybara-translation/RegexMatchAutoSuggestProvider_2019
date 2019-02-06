using System;

namespace Capybara.EditorPlugin.RegexMASProvider.View
{
    [AttributeUsage(AttributeTargets.Class)]
    class ConcreteClassAttribute : Attribute {
    Type _concreteType;
    public ConcreteClassAttribute(Type concreteType) {
        _concreteType = concreteType;
    }

    public Type ConcreteType { get { return _concreteType; } }
}
}