using System;

namespace Reftruckegypt.Servicecenter.Data.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
    }
}
