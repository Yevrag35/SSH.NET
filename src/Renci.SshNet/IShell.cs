using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Renci.SshNet
{
    /// <summary>
    /// An interface exposing properties, events, and methods of an instance of the SSH shell object.
    /// </summary>
    public interface IShell : IDisposable
    {
        #region PROPERTIES
        /// <summary>
        /// Gets a value indicating whether this shell is started.
        /// </summary>
        /// <value>
        /// <c>true</c> if started is started; otherwise, <c>false</c>.
        /// </value>
        bool IsStarted { get; }

        #endregion

        #region EVENTS
        /// <summary>
        /// Occurs when shell is starting.
        /// </summary>
        event EventHandler<EventArgs> Starting;

        /// <summary>
        /// Occurs when shell is started.
        /// </summary>
        event EventHandler<EventArgs> Started;

        /// <summary>
        /// Occurs when shell is stopping.
        /// </summary>
        event EventHandler<EventArgs> Stopping;

        /// <summary>
        /// Occurs when shell is stopped.
        /// </summary>
        event EventHandler<EventArgs> Stopped;

        /// <summary>
        /// Occurs when an error occurred.
        /// </summary>
        event EventHandler<ExceptionEventArgs> ErrorOccurred;

        #endregion

        #region METHODS
        /// <summary>
        /// Starts this shell.
        /// </summary>
        /// <exception cref="SshException">Shell is started.</exception>
        void Start();

        /// <summary>
        /// Stops this shell.
        /// </summary>
        /// <exception cref="SshException">Shell is not started.</exception>
        void Stop();

        #endregion
    }
}
