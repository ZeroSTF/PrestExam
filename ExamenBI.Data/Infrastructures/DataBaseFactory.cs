using ExamenBI.Data;

using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore.Data.Infrastructures
{
    public class DataBaseFactory : Disposable, IDataBaseFactory
    {
        private ExamenBIContext dataContext;
        public ExamenBIContext DataContext
        {
            get { return dataContext; }
        }
        public DataBaseFactory() { dataContext = new ExamenBIContext(); }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }
}