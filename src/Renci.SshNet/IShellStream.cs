using Renci.SshNet.Abstractions;
using Renci.SshNet.Channels;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Renci.SshNet
{
    public interface IShellStream : IDisposable
    {
        #region PROPERTIES
        /// <summary>
        /// Gets a value that indicates whether data is available on the <see cref="ShellStream"/> to be read.
        /// </summary>
        /// <value>
        /// <c>true</c> if data is available to be read; otherwise, <c>false</c>.
        /// </value>
        bool DataAvailable { get; }

        /// <summary>
        /// Gets the number of bytes that will be written to the internal buffer.
        /// </summary>
        /// <value>
        /// The number of bytes that will be written to the internal buffer.
        /// </value>
        int BufferSize { get; }

        /// <summary>
        /// Gets a value indicating whether the current stream supports reading.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the stream supports reading; otherwise, <c>false</c>.
        /// </returns>
        bool CanRead { get; }

        /// <summary>
        /// Gets a value indicating whether the current stream supports seeking.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the stream supports seeking; otherwise, <c>false</c>.
        /// </returns>
        bool CanSeek { get; }

        /// <summary>
        /// Gets a value indicating whether the current stream supports writing.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the stream supports writing; otherwise, <c>false</c>.
        /// </returns>
        bool CanWrite { get; }

        /// <summary>
        /// Gets the length in bytes of the stream.
        /// </summary>
        /// <returns>A long value representing the length of the stream in bytes.</returns>
        /// <exception cref="NotSupportedException">A class derived from Stream does not support seeking.</exception>
        /// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
        long Length { get; }

        /// <summary>
        /// Gets or sets the position within the current stream.
        /// </summary>
        /// <returns>
        /// The current position within the stream.
        /// </returns>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
        /// <exception cref="T:System.NotSupportedException">The stream does not support seeking.</exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed.</exception>
        long Position { get; }

        #endregion

        #region EVENTS
        /// <summary>
        /// Occurs when data was received.
        /// </summary>
        event EventHandler<ShellDataEventArgs> DataReceived;

        /// <summary>
        /// Occurs when an error occurred.
        /// </summary>
        event EventHandler<ExceptionEventArgs> ErrorOccurred;

        #endregion

        #region METHODS
        /// <summary>
        /// Begins the expect.
        /// </summary>
        /// <param name="expectActions">The expect actions.</param>
        /// <returns>
        /// An <see cref="IAsyncResult" /> that references the asynchronous operation.
        /// </returns>
        IAsyncResult BeginExpect(params IExpectAction[] expectActions);

        /// <summary>
        /// Begins the expect.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="callback">The callback.</param>
        /// <param name="state">The state.</param>
        /// <param name="expectActions">The expect actions.</param>
        /// <returns>
        /// An <see cref="IAsyncResult" /> that references the asynchronous operation.
        /// </returns>
        IAsyncResult BeginExpect(TimeSpan timeout, AsyncCallback callback, object state, params IExpectAction[] expectActions);

        /// <summary>
        /// Ends the execute.
        /// </summary>
        /// <param name="asyncResult">The async result.</param>
        /// <exception cref="ArgumentException">Either the IAsyncResult object did not come from the corresponding async method on this type, or EndExecute was called multiple times with the same IAsyncResult.</exception>
        string EndExpect(IAsyncResult asyncResult);

        /// <summary>
        /// Expects the specified expression and performs action when one is found.
        /// </summary>
        /// <param name="expectActions">The expected expressions and actions to perform.</param>
        void Expect(params IExpectAction[] expectActions);

        /// <summary>
        /// Expects the specified expression and performs action when one is found.
        /// </summary>
        /// <param name="timeout">Time to wait for input.</param>
        /// <param name="expectActions">The expected expressions and actions to perform, if the specified time elapsed and expected condition have not met, that method will exit without executing any action.</param>
        void Expect(TimeSpan timeout, params IExpectAction[] expectActions);

        /// <summary>
        /// Expects the expression specified by text.
        /// </summary>
        /// <param name="text">The text to expect.</param>
        /// <param name="timeout">Time to wait for input.</param>
        /// <returns>
        /// The text available in the shell that ends with expected text, or <c>null</c> if the specified time has elapsed.
        /// </returns>
        string Expect(string text, TimeSpan timeout);

        /// <summary>
        /// Expects the expression specified by regular expression.
        /// </summary>
        /// <param name="regex">The regular expression to expect.</param>
        /// <param name="timeout">Time to wait for input.</param>
        /// <returns>
        /// The text available in the shell that contains all the text that ends with expected expression,
        /// or <c>null</c> if the specified time has elapsed.
        /// </returns>
        string Expect(Regex regex, TimeSpan timeout);

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data to be written to the underlying device.
        /// </summary>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
        /// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
        void Flush();

        /// <summary>
        /// Reads text available in the shell.
        /// </summary>
        /// <returns>
        /// The text available in the shell.
        /// </returns>
        string Read();

        /// <summary>
        /// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between <paramref name="offset"/> and (<paramref name="offset"/> + <paramref name="count"/> - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read from the current stream.</param>
        /// <returns>
        /// The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">The sum of <paramref name="offset"/> and <paramref name="count"/> is larger than the buffer length. </exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="buffer"/> is <c>null</c>.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="offset"/> or <paramref name="count"/> is negative.</exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>   
        /// <exception cref="T:System.NotSupportedException">The stream does not support reading.</exception>   
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed.</exception>
        int Read(byte[] buffer, int offset, int count);

        /// <summary>
        /// Reads the line from the shell. If line is not available it will block the execution and will wait for new line.
        /// </summary>
        /// <returns>
        /// The line read from the shell.
        /// </returns>
        string ReadLine();

        /// <summary>
        /// Reads a line from the shell. If line is not available it will block the execution and will wait for new line.
        /// </summary>
        /// <param name="timeout">Time to wait for input.</param>
        /// <returns>
        /// The line read from the shell, or <c>null</c> when no input is received for the specified timeout.
        /// </returns>
        string ReadLine(TimeSpan timeout);

        /// <summary>
        /// Writes the specified text to the shell.
        /// </summary>
        /// <param name="text">The text to be written to the shell.</param>
        /// <remarks>
        /// If <paramref name="text"/> is <c>null</c>, nothing is written.
        /// </remarks>
        void Write(string text);

        /// <summary>
        /// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
        /// </summary>
        /// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from <paramref name="buffer"/> to the current stream.</param>
        /// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin copying bytes to the current stream.</param>
        /// <param name="count">The number of bytes to be written to the current stream.</param>
        /// <exception cref="T:System.ArgumentException">The sum of <paramref name="offset"/> and <paramref name="count"/> is greater than the buffer length.</exception>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="buffer"/> is <c>null</c>.</exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException"><paramref name="offset"/> or <paramref name="count"/> is negative.</exception>
        /// <exception cref="T:System.IO.IOException">An I/O error occurs.</exception>
        /// <exception cref="T:System.NotSupportedException">The stream does not support writing.</exception>
        /// <exception cref="T:System.ObjectDisposedException">Methods were called after the stream was closed.</exception>
        void Write(byte[] buffer, int offset, int count);

        /// <summary>
        /// Writes the line to the shell.
        /// </summary>
        /// <param name="line">The line to be written to the shell.</param>
        /// <remarks>
        /// If <paramref name="line"/> is <c>null</c>, only the line terminator is written.
        /// </remarks>
        void WriteLine(string line);

        #endregion
    }
}
