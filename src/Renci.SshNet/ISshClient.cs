using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renci.SshNet
{
    public interface ISshClient
    {
        #region PROPERTIES
        /// <summary>
        /// Gets the list of forwarded ports.
        /// </summary>
        IReadOnlyCollection<ForwardedPort> ForwardedPorts { get; }

        #endregion

        #region METHODS
        /// <summary>
        /// Adds the forwarded port.
        /// </summary>
        /// <param name="port">The port.</param>
        /// <example>
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\ForwardedPortRemoteTest.cs" region="Example SshClient AddForwardedPort Start Stop ForwardedPortRemote" language="C#" title="Remote port forwarding" />
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\ForwardedPortLocalTest.cs" region="Example SshClient AddForwardedPort Start Stop ForwardedPortLocal" language="C#" title="Local port forwarding" />
        /// </example>
        /// <exception cref="InvalidOperationException">Forwarded port is already added to a different client.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="port"/> is <c>null</c>.</exception>
        /// <exception cref="SshConnectionException">Client is not connected.</exception>
        void AddForwardedPort(ForwardedPort port);

        /// <summary>
        /// Stops and removes the forwarded port from the list.
        /// </summary>
        /// <param name="port">Forwarded port.</param>
        /// <exception cref="ArgumentNullException"><paramref name="port"/> is <c>null</c>.</exception>
        void RemoveForwardedPort(ForwardedPort port);

        /// <summary>
        /// Creates the command to be executed.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <returns><see cref="ISshCommand"/> object.</returns>
        /// <exception cref="SshConnectionException">Client is not connected.</exception>
        ISshCommand CreateCommand(string commandText);

        /// <summary>
        /// Creates the command to be executed with specified encoding.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <param name="encoding">The encoding to use for results.</param>
        /// <returns><see cref="SshCommand"/> object which uses specified encoding.</returns>
        /// <remarks>This method will change current default encoding.</remarks>
        /// <exception cref="SshConnectionException">Client is not connected.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="commandText"/> or <paramref name="encoding"/> is <c>null</c>.</exception>
        ISshCommand CreateCommand(string commandText, Encoding encoding);

        /// <summary>
        /// Creates and executes the command.
        /// </summary>
        /// <param name="commandText">The command text.</param>
        /// <returns>Returns an instance of <see cref="SshCommand"/> with execution results.</returns>
        /// <remarks>This method internally uses asynchronous calls.</remarks>
        /// <example>
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\SshCommandTest.cs" region="Example SshCommand RunCommand Result" language="C#" title="Running simple command" />
        ///     <code source="..\..\src\Renci.SshNet.Tests\Classes\SshCommandTest.NET40.cs" region="Example SshCommand RunCommand Parallel" language="C#" title="Run many commands in parallel" />
        /// </example>
        /// <exception cref="ArgumentException">CommandText property is empty.</exception>
        /// <exception cref="T:Renci.SshNet.Common.SshException">Invalid Operation - An existing channel was used to execute this command.</exception>
        /// <exception cref="InvalidOperationException">Asynchronous operation is already in progress.</exception>
        /// <exception cref="SshConnectionException">Client is not connected.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="commandText"/> is <c>null</c>.</exception>
        ISshCommand RunCommand(string commandText);

        /// <summary>
        /// Creates the shell.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <param name="extendedOutput">The extended output.</param>
        /// <param name="terminalName">Name of the terminal.</param>
        /// <param name="columns">The columns.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="terminalModes">The terminal mode.</param>
        /// <param name="bufferSize">Size of the internal read buffer.</param>
        /// <returns>
        /// Returns a representation of a <see cref="Shell" /> object.
        /// </returns>
        /// <exception cref="SshConnectionException">Client is not connected.</exception>
        IShell CreateShell(Stream input, Stream output, Stream extendedOutput, string terminalName, uint columns, uint rows, uint width, uint height, IDictionary<TerminalModes, uint> terminalModes, int bufferSize);

        /// <summary>
        /// Creates the shell.
        /// </summary>
        /// <param name="encoding">The encoding.</param>
        /// <param name="input">The input.</param>
        /// <param name="output">The output.</param>
        /// <param name="extendedOutput">The extended output.</param>
        /// <returns>
        /// Returns a representation of a <see cref="Shell" /> object.
        /// </returns>
        /// <exception cref="SshConnectionException">Client is not connected.</exception>
        IShell CreateShell(Encoding encoding, string input, Stream output, Stream extendedOutput);

        /// <summary>
        /// Creates the shell stream.
        /// </summary>
        /// <param name="terminalName">The <c>TERM</c> environment variable.</param>
        /// <param name="columns">The terminal width in columns.</param>
        /// <param name="rows">The terminal width in rows.</param>
        /// <param name="width">The terminal height in pixels.</param>
        /// <param name="height">The terminal height in pixels.</param>
        /// <param name="bufferSize">The size of the buffer.</param>
        /// <param name="terminalModeValues">The terminal mode values.</param>
        /// <returns>
        /// The created <see cref="ShellStream"/> instance.
        /// </returns>
        /// <exception cref="SshConnectionException">Client is not connected.</exception>
        /// <remarks>
        /// <para>
        /// The <c>TERM</c> environment variable contains an identifier for the text window's capabilities.
        /// You can get a detailed list of these cababilities by using the ‘infocmp’ command.
        /// </para>
        /// <para>
        /// The column/row dimensions override the pixel dimensions(when non-zero). Pixel dimensions refer
        /// to the drawable area of the window.
        /// </para>
        /// </remarks>
        IShellStream CreateShellStream(string terminalName, uint columns, uint rows, uint width, uint height, int bufferSize, IDictionary<TerminalModes, uint> terminalModeValues);

        #endregion
    }
}
