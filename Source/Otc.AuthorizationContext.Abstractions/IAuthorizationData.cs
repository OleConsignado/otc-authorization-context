namespace Otc.AuthorizationContext.Abstractions
{
    /// <summary>
    /// Base interface for authorization data model class.
    /// </summary>
    public interface IAuthorizationData
    {
        string UserId { get; }
    }
}
