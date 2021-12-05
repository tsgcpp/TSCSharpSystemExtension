using System;
using System.Collections.Generic;

namespace Tests.SampleType
{
    public class EquatableFoo : IFoo, IEquatable<EquatableFoo>
    {
        public bool Equals(EquatableFoo other)
        {
            return this == other;
        }
    }
}
