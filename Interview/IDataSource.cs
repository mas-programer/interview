using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    /// <summary>
    /// 数据源
    /// </summary>
    public interface IDataSource
    {
        /// <summary>
        /// 获取数据源
        /// </summary>
        /// <returns></returns>
        Dictionary<int, string> GetData();
    }
}
