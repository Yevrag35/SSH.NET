using System.Text;

namespace Renci.SshNet.Sftp
{
    public interface ISftpResponseFactory
    {
        SftpMessage Create(uint protocolVersion, byte messageType, Encoding encoding);
    }
}
