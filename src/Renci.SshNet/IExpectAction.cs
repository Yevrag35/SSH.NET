using System;
using System.Text.RegularExpressions;

namespace Renci.SshNet
{
    public interface IExpectAction
    {
        #region PROPERTIES
        /// <summary>
        /// Gets the action to perform when expected expression is found.
        /// </summary>
        Action<string> Action { get; }

        /// <summary>
        /// Gets the expected regular expression.
        /// </summary>
        Regex Expect { get; }

        #endregion
    }
}
