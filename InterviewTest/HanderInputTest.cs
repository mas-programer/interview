using Interview;
using NUnit.Framework;
using System.Collections.Generic;

namespace InterviewTest
{
	public class HanderInputTest
	{
		private DigitLetterMapping _digitLetterMapping;

		[SetUp]
		public void Setup()
		{
			_digitLetterMapping = new DigitLetterMapping();
		}

		[Test]
		public void TestInputDataIsEmpty()
		{
			var result = _digitLetterMapping.HandlerInput(new int[] { });
			Assert.IsNull(result);
		}

		[Test]
		public void TestInputDataLt0()
		{
			System.IO.InvalidDataException exception = null;

			try
			{
				_digitLetterMapping.HandlerInput(new int[] { -1 });
			}
			catch (System.IO.InvalidDataException ex)
			{
				exception = ex;
			}

			Assert.AreNotEqual(null, exception);

			Assert.AreEqual(typeof(System.IO.InvalidDataException), exception.GetType());
		}

		[Test]
		public void TestInputDataGt9()
		{
			System.IO.InvalidDataException exception = null;

			try
			{
				_digitLetterMapping.HandlerInput(new int[] { 1,10 });
			}
			catch (System.IO.InvalidDataException ex)
			{
				exception = ex;
			}

			Assert.AreNotEqual(null, exception);

			Assert.AreEqual(typeof(System.IO.InvalidDataException), exception.GetType());
		}


		[Test]
		public void TestInputDataEq0()
		{
			Assert.IsEmpty(_digitLetterMapping.HandlerInput(new int[] { 0 }));
		}

		[Test]
		public void TestInputDataEq1()
		{
			Assert.IsEmpty(_digitLetterMapping.HandlerInput(new int[] { 1 }));
		}

		[Test]
		public void TestInputDataLike_2_3()
		{
			var result = _digitLetterMapping.HandlerInput(new int[] { 2, 3 });
			Assert.IsNotNull(result);
			Assert.IsNotEmpty(result);

			Assert.AreEqual(string.Join(" ", result.ToArray()), "AD AE AF BD BE BF CD CE CF");
		}

		[Test]
		public void TestInputDataLike_2_3_5()
		{
			var result = _digitLetterMapping.HandlerInput(new int[] { 2, 3,5 });
			Assert.IsNotNull(result);
			Assert.IsNotEmpty(result);

			Assert.AreEqual(string.Join(" ", result.ToArray()), "ADJ ADK ADL AEJ AEK AEL AFJ AFK AFL BDJ BDK BDL BEJ BEK BEL BFJ BFK BFL CDJ CDK CDL CEJ CEK CEL CFJ CFK CFL");
		}

		[Test]
		public void TestInputDataLike_9_2_3_5()
		{
			var result = _digitLetterMapping.HandlerInput(new int[] {9, 2, 3, 5 });
			Assert.IsNotNull(result);
			Assert.IsNotEmpty(result);

			Assert.AreEqual(string.Join(" ", result.ToArray()), "WADJ WADK WADL WAEJ WAEK WAEL WAFJ WAFK WAFL WBDJ WBDK WBDL WBEJ WBEK WBEL WBFJ WBFK WBFL WCDJ WCDK WCDL WCEJ WCEK WCEL WCFJ WCFK WCFL XADJ XADK XADL XAEJ XAEK XAEL XAFJ XAFK XAFL XBDJ XBDK XBDL XBEJ XBEK XBEL XBFJ XBFK XBFL XCDJ XCDK XCDL XCEJ XCEK XCEL XCFJ XCFK XCFL YADJ YADK YADL YAEJ YAEK YAEL YAFJ YAFK YAFL YBDJ YBDK YBDL YBEJ YBEK YBEL YBFJ YBFK YBFL YCDJ YCDK YCDL YCEJ YCEK YCEL YCFJ YCFK YCFL ZADJ ZADK ZADL ZAEJ ZAEK ZAEL ZAFJ ZAFK ZAFL ZBDJ ZBDK ZBDL ZBEJ ZBEK ZBEL ZBFJ ZBFK ZBFL ZCDJ ZCDK ZCDL ZCEJ ZCEK ZCEL ZCFJ ZCFK ZCFL");
		}

		[Test]
		public void TestInputDataLike_2_2()
		{
			var result = _digitLetterMapping.HandlerInput(new int[] { 2,2});
			Assert.IsNotNull(result);
			Assert.IsNotEmpty(result);

			Assert.AreEqual(string.Join(" ", result.ToArray()), "AA AB AC BA BB BC CA CB CC");
		}
	}
}