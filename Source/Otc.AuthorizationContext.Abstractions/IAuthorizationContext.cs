namespace Otc.AuthorizationContext.Abstractions
{
    /// <summary>
    /// Provide a way to get the authorization data.
    /// </summary>
    /// <typeparam name="TAuthorizationData">Type of authorization data model.</typeparam>
    public interface IAuthorizationContext<TAuthorizationData> where TAuthorizationData : IAuthorizationData
    {
        TAuthorizationData AuthorizationData { get; }
    }
}
