namespace Renci.SshNet
{
    public interface IClientAuthentication
    {
        void Authenticate(IConnectionInfoInternal connectionInfo, ISession session);
    }
}
