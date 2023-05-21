using System;

using System.Runtime.Serialization;

namespace FluentAssertions.Execution
{
    /// <summary>
    /// Represents the default exception in case no test framework is configured.
    /// </summary>
    [Serializable]
    public class AssertionFailedException : Exception
#pragma warning restore CA1032, RCS1194
    {
        public AssertionFailedException(string message)
            : base(message)
        {
        }

        protected AssertionFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}