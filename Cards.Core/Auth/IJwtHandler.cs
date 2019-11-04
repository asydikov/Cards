using System;

namespace Cards.Core.Auth
{
    public interface IJwtHandler
    {
        JsonWebToken Create(Guid userId);
    }
}