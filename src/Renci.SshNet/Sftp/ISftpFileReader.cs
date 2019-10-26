using System;

namespace Renci.SshNet.Sftp
{
    public interface ISftpFileReader : IDisposable
    {
        byte[] Read();
    }
}
