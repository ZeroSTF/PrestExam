using ExamenBI.Data;

using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore.Data.Infrastructures
{
    public interface IDataBaseFactory :IDisposable
    {
        ExamenBIContext DataContext { get; }
    }
}
