namespace Otc.SessionContext.Abstractions
{
    public interface ISessionSerializer<TSessionData> where TSessionData : ISessionData
    {
        string Serialize(TSessionData sessionData);
    }
}
