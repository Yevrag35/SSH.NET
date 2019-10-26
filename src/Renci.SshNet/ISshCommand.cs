using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Renci.SshNet
{
    public interface ISshCommand
    {
        #region PROPERTIES
        /// <summary>
        /// Gets the command text.
        /// </summary>
        string CommandText { get; }

        /// <summary>
        /// Gets or sets the command timeout.
        /// </summary>
        /// <value>
        /// The command timeout.
        /// </value>
        /// <example>
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\SshCommandTest.cs" region="Example SshCommand CreateCommand Execute CommandTimeout" language="C#" title="Specify command execution timeout" />
        /// </example>
        TimeSpan CommandTimeout { get; set; }

        /// <summary>
        /// Gets the command exit status.
        /// </summary>
        /// <example>
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\SshCommandTest.cs" region="Example SshCommand RunCommand ExitStatus" language="C#" title="Get command execution exit status" />
        /// </example>
        int ExitStatus { get; }

        /// <summary>
        /// Gets the output stream.
        /// </summary>
        /// <example>
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\SshCommandTest.cs" region="Example SshCommand CreateCommand Execute OutputStream" language="C#" title="Use OutputStream to get command execution output" />
        /// </example>
        Stream OutputStream { get; }

        /// <summary>
        /// Gets the extended output stream.
        /// </summary>
        /// <example>
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\SshCommandTest.cs" region="Example SshCommand CreateCommand Execute ExtendedOutputStream" language="C#" title="Use ExtendedOutputStream to get command debug execution output" />
        /// </example>
        Stream ExtendedOutputStream { get; }

        /// <summary>
        /// Gets the command execution result.
        /// </summary>
        /// <example>
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\SshCommandTest.cs" region="Example SshCommand RunCommand Result" language="C#" title="Running simple command" />
        /// </example>
        string Result { get; }

        /// <summary>
        /// Gets the command execution error.
        /// </summary>
        /// <example>
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\SshCommandTest.cs" region="Example SshCommand CreateCommand Error" language="C#" title="Display command execution error" />
        /// </example>
        string Error { get; }

        #endregion

        #region METHODS
        /// <summary>
        /// Begins an asynchronous command execution.
        /// </summary>
        /// <returns>
        /// An <see cref="System.IAsyncResult" /> that represents the asynchronous command execution, which could still be pending.
        /// </returns>
        /// <example>
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\SshCommandTest.cs" region="Example SshCommand CreateCommand BeginExecute IsCompleted EndExecute" language="C#" title="Asynchronous Command Execution" />
        /// </example>
        /// <exception cref="InvalidOperationException">Asynchronous operation is already in progress.</exception>
        /// <exception cref="SshException">Invalid operation.</exception>
        /// <exception cref="ArgumentException">CommandText property is empty.</exception>
        /// <exception cref="SshConnectionException">Client is not connected.</exception>
        /// <exception cref="SshOperationTimeoutException">Operation has timed out.</exception>
        /// <exception cref="InvalidOperationException">Asynchronous operation is already in progress.</exception>
        /// <exception cref="ArgumentException">CommandText property is empty.</exception>
        IAsyncResult BeginExecute();

        /// <summary>
        /// Begins an asynchronous command execution.
        /// </summary>
        /// <param name="callback">An optional asynchronous callback, to be called when the command execution is complete.</param>
        /// <returns>
        /// An <see cref="System.IAsyncResult" /> that represents the asynchronous command execution, which could still be pending.
        /// </returns>
        /// <exception cref="InvalidOperationException">Asynchronous operation is already in progress.</exception>
        /// <exception cref="SshException">Invalid operation.</exception>
        /// <exception cref="ArgumentException">CommandText property is empty.</exception>
        /// <exception cref="SshConnectionException">Client is not connected.</exception>
        /// <exception cref="SshOperationTimeoutException">Operation has timed out.</exception>
        /// <exception cref="InvalidOperationException">Asynchronous operation is already in progress.</exception>
        /// <exception cref="ArgumentException">CommandText property is empty.</exception>
        IAsyncResult BeginExecute(AsyncCallback callback);

        /// <summary>
        /// Begins an asynchronous command execution.
        /// </summary>
        /// <param name="callback">An optional asynchronous callback, to be called when the command execution is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous read request from other requests.</param>
        /// <returns>
        /// An <see cref="IAsyncResult" /> that represents the asynchronous command execution, which could still be pending.
        /// </returns>
        /// <exception cref="InvalidOperationException">Asynchronous operation is already in progress.</exception>
        /// <exception cref="SshException">Invalid operation.</exception>
        /// <exception cref="ArgumentException">CommandText property is empty.</exception>
        /// <exception cref="SshConnectionException">Client is not connected.</exception>
        /// <exception cref="SshOperationTimeoutException">Operation has timed out.</exception>
        /// <exception cref="InvalidOperationException">Asynchronous operation is already in progress.</exception>
        /// <exception cref="ArgumentException">CommandText property is empty.</exception>
        IAsyncResult BeginExecute(AsyncCallback callback, object state);

        /// <summary>
        /// Begins an asynchronous command execution.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="callback">An optional asynchronous callback, to be called when the command execution is complete.</param>
        /// <param name="state">A user-provided object that distinguishes this particular asynchronous read request from other requests.</param>
        /// <returns>
        /// An <see cref="System.IAsyncResult" /> that represents the asynchronous command execution, which could still be pending.
        /// </returns>
        /// <exception cref="Renci.SshNet.Common.SshConnectionException">Client is not connected.</exception>
        /// <exception cref="Renci.SshNet.Common.SshOperationTimeoutException">Operation has timed out.</exception>
        IAsyncResult BeginExecute(string commandText, AsyncCallback callback, object state);

        /// <summary>
        /// Cancels command execution in asynchronous scenarios. 
        /// </summary>
        void CancelAsync();

        /// <summary>
        /// Waits for the pending asynchronous command execution to complete.
        /// </summary>
        /// <param name="asyncResult">The reference to the pending asynchronous request to finish.</param>
        /// <returns>Command execution result.</returns>
        /// <example>
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\SshCommandTest.cs" region="Example SshCommand CreateCommand BeginExecute IsCompleted EndExecute" language="C#" title="Asynchronous Command Execution" />
        /// </example>
        /// <exception cref="ArgumentException">Either the IAsyncResult object did not come from the corresponding async method on this type, or EndExecute was called multiple times with the same IAsyncResult.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="asyncResult"/> is <c>null</c>.</exception>
        string EndExecute(IAsyncResult asyncResult);

        /// <summary>
        /// Executes command specified by <see cref="CommandText"/> property.
        /// </summary>
        /// <returns>Command execution result</returns>
        /// <example>
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\SshCommandTest.cs" region="Example SshCommand CreateCommand Execute" language="C#" title="Simple command execution" />
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\SshCommandTest.cs" region="Example SshCommand CreateCommand Error" language="C#" title="Display command execution error" />
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\SshCommandTest.cs" region="Example SshCommand CreateCommand Execute CommandTimeout" language="C#" title="Specify command execution timeout" />
        /// </example>
        /// <exception cref="Renci.SshNet.Common.SshConnectionException">Client is not connected.</exception>
        /// <exception cref="Renci.SshNet.Common.SshOperationTimeoutException">Operation has timed out.</exception>
        string Execute();

        /// <summary>
        /// Executes the specified command text.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <returns>Command execution result</returns>
        /// <exception cref="Renci.SshNet.Common.SshConnectionException">Client is not connected.</exception>
        /// <exception cref="Renci.SshNet.Common.SshOperationTimeoutException">Operation has timed out.</exception>
        string Execute(string commandText);

        #endregion
    }
}
