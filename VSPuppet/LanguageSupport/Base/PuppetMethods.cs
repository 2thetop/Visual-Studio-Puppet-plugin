/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.

***************************************************************************/

namespace Puppet
{
    using System.Collections.Generic;

    public class PuppetMethods : Microsoft.VisualStudio.Package.Methods
    {
        IList<Method> methods;
        public PuppetMethods(IList<Method> methods)
        {
            this.methods = methods;
        }

        public override int GetCount()
        {
            return methods.Count;
        }

        public override string GetName(int index)
        {
            return methods[index].Name;
        }

        public override string GetDescription(int index)
        {
            return methods[index].Description;
        }

        public override string GetType(int index)
        {
            return methods[index].Type;
        }

        public override int GetParameterCount(int index)
        {
            return (methods[index].Parameters == null) ? 0 : methods[index].Parameters.Count;
        }

        public override void GetParameterInfo(int index, int paramIndex, out string name, out string display, out string description)
        {
            Parameter parameter = methods[index].Parameters[paramIndex];
            name = parameter.Name;
            display = parameter.Display;
            description = parameter.Description;
        }
    }
}