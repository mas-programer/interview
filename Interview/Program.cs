using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Reflection.PortableExecutable;

namespace Interview
{
	class Program
	{
		static void Main(string[] args)
		{
			IDataSource dataSource = new LocalDataSource();

			MappingHandlerWrapper mappingHandlerWrapper = new MappingHandlerWrapper(dataSource);

			while (true)
			{
				try
				{
					string inputData = Console.ReadLine();
					if (inputData.Equals("exit", StringComparison.OrdinalIgnoreCase))
					{
						break;
					}

					var strArray = inputData.Split(' ');
					if (inputData.Length <= 0 || strArray.Length <= 0)
					{
						continue;
					}

					int[] intArray = ToIntArray(strArray);

					mappingHandlerWrapper.DoMapping(intArray);

					Console.WriteLine();
				}
				catch (ArgumentNullException ex)
				{
					Console.WriteLine(ex.Message);
				}
				catch (ArgumentOutOfRangeException ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}

		/// <summary>
		/// 字符串数组转换整形数组
		/// </summary>
		/// <param name="strArray">字符串数组</param>
		/// <returns></returns>
		static int[] ToIntArray(string[] strArray)
		{
			int[] c = new int[strArray.Length];
			for (int i = 0; i < strArray.Length; i++)
			{
				c[i] = Convert.ToInt32(strArray[i].ToString());
			}
			return c;
		}
	}
}
