using Renci.SshNet.Common;
using System;

namespace Renci.SshNet.Sftp
{
    public class SftpCloseAsyncResult : AsyncResult
    {
        public SftpCloseAsyncResult(AsyncCallback asyncCallback, object state) : base(asyncCallback, state)
        {
        }
    }
}
