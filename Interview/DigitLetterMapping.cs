using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Interview
{
	public class DigitLetterMapping
	{
		/// <summary>
		/// 接收输入数组
		/// </summary>
		/// <param name="array"></param>
		/// <returns></returns>
		public List<string> HandlerInput(int[] array)
		{
			if (array.Length <= 0)
			{
				return null;
			}

			Dictionary<int, string> initData = InitMappingData();

			List<string> combineResult = new List<string>();
			List<string> combineTemp = new List<string>();

			for (int i = 0; i < array.Length; ++i)
			{
				if(array[i] < 0 || array[i] > 9)
				{
					throw new InvalidDataException("input data is inValid.");
				}

				CombineArray(combineResult, combineTemp, initData.GetValueOrDefault(array[i]));
			}

			combineResult.Sort();
			return combineResult;
		}

		/// <summary>
		/// 进行组合
		/// </summary>
		/// <param name="combineResult">组合结果</param>
		/// <param name="combineTemp">组合过程中的中间变量</param>
		/// <param name="waittingCombine">新输入的数字对应的字符串</param>
		private void CombineArray(List<string> combineResult, List<string> combineTemp, string waittingCombine)
		{
			var waittingCombineArray = waittingCombine.ToArray();
			if (combineTemp.Count == 0)
			{
				foreach (char c in waittingCombineArray)
				{
					combineTemp.Add(c.ToString());

				}
				combineResult.AddRange(combineTemp);
			}
			else
			{
				combineResult.Clear();
				foreach (char c in waittingCombineArray)
				{
					combineResult.AddRange(combineTemp.Select(s => s += c.ToString()).ToList());
				}

				combineTemp.Clear();
				combineTemp.AddRange(combineResult);
			}
		}

		/// <summary>
		/// init the data
		/// </summary>
		/// <returns>the dictionary that store digits and letter mapping relations </returns>
		private Dictionary<int, string> InitMappingData()
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
