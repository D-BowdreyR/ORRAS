using System;
namespace ORRA.Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
    }
}