// --------------------------------------------------------------------------
//     Copyright (c) Microsoft Open Technologies, Inc.
//     All Rights Reserved. Licensed under the Apache 2.0 License.
// --------------------------------------------------------------------------
namespace Puppet
{
    using System.Collections.Generic;

    public struct Method
    {
        public string Name;
        public string Description;
        public string Type;
        public IList<Parameter> Parameters;
    }

    public struct Parameter
    {
        public string Name;
        public string Display;
        public string Description;
    }
}