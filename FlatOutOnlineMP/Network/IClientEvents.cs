namespace FlatOutOnlineMP.Network
{
    internal interface IClientEvents
    {
        void OnLogin();

        void OnStreamState(bool state);

        void OnStreamData(byte[] data);

        void OnDisconnect();
    }
}
