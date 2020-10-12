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
			Console.WriteLine("Hello World!");


			int[] array = new int[]{ 1,1,2,3 };

			DigitLetterMapping digitLetterMapping = new DigitLetterMapping();

			var result = digitLetterMapping.HandlerInput(array);

			foreach(string str in result)
			{
				Console.Write(str + " ");
			}
		}
	}
}
