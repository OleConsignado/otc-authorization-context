namespace Otc.AuthorizationContext.Abstractions
{
    /// <summary>
    /// Provide the authorization data serializer (token generation).
    /// </summary>
    /// <typeparam name="TAuthorizationData">Type of authorization data model.</typeparam>
    public interface IAuthorizationDataSerializer<TAuthorizationData> where TAuthorizationData : IAuthorizationData
    {
        /// <summary>
        /// Serialize / Generate token.
        /// </summary>
        /// <param name="authorizationData">Data to serialize.</param>
        /// <returns>String with generated token.</returns>
        string Serialize(TAuthorizationData authorizationData);
    }
}
