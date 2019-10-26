using Renci.SshNet.Common;
using System;

namespace Renci.SshNet.Sftp
{
    public class SftpRealPathAsyncResult : AsyncResult<string>
    {
        public SftpRealPathAsyncResult(AsyncCallback asyncCallback, object state) : base(asyncCallback, state)
        {
        }
    }
}
