using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
	/// <summary>
	/// 本地数据源
	/// </summary>
    public class LocalDataSource : IDataSource
    {
		/// <summary>
		/// 获取数据
		/// </summary>
		/// <returns></returns>
        public Dictionary<int, string> GetData()
        {
			Dictionary<int, string> dict = new Dictionary<int, string>();
			dict.Add(1, "");
			dict.Add(2, "ABC");
			dict.Add(3, "DEF");
			dict.Add(4, "GHI");
			dict.Add(5, "JKL");
			dict.Add(6, "MNO");
			dict.Add(7, "PQRS");
			dict.Add(8, "TUV");
			dict.Add(9, "WXYZ");
			dict.Add(0, "");
			return dict;
		}
    }
}
