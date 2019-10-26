using Renci.SshNet.Common;

namespace Renci.SshNet.Sftp.Responses
{
    public abstract class ExtendedReplyInfo
    {
        public abstract void LoadData(SshDataStream stream);
    }
}
