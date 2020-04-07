using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IDataAccessHelper
    {
        List<T> SelectList<T>(string command);
    }
}
