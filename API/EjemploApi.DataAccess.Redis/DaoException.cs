using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploApi.DataAccess.Redis
{
    public class DaoException : Exception
    {
        public DaoException()
        {
        }

        public DaoException(string message) : base(message)
        {
        }

        public DaoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
