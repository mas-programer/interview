using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interview
{
    /// <summary>
    /// 组合映射
    /// </summary>
    public class CombineMappingHandler : IMappingHandler
    {
        private IDataSource _dataSource;
        public CombineMappingHandler(IDataSource dataSource)
        {
            _dataSource = dataSource;
        }

        public bool IsValidInput(params int[] input)
        {
            if(input == null || input.Length <= 0)
            {
                throw new ArgumentNullException("input","the input data can not be null.");
            }

            if(input.Any(p => p < 0 || p > 9))
            {
                throw new ArgumentOutOfRangeException("input", "the input data must between 0 and 9.");
            }

            return true;
        }

        public List<string> Mapping(params int[] input)
        {
            Dictionary<int, string> initData = _dataSource.GetData();
            List<string> combineTemp = new List<string>();
            List<string> combineResult = new List<string>();

            input.Where(i=> i != 0 && i != 1 ).ToList().ForEach(i => Combine(combineResult, combineTemp,initData.GetValueOrDefault(i)) );

            return combineResult;
        }

        public void OutputHandler(List<string> mappingResult)
        {
            mappingResult.Sort();

            mappingResult.ForEach(r => Console.Write(r + " "));

            mappingResult.Clear();
        }

        /// <summary>
        /// 组合操作
        /// </summary>
        /// <param name="combineResult"></param>
        /// <param name="combineTemp"></param>
        /// <param name="waittingCombine"></param>
        private void Combine(List<string> combineResult, List<string> combineTemp, string waittingCombine)
        {
            var waittingCombineList = waittingCombine.ToArray().ToList();
            if (combineTemp.Count == 0)
            {
                waittingCombineList.ForEach(c => combineTemp.Add(c.ToString()));

                combineResult.AddRange(combineTemp);
            }
            else
            {
                combineResult.Clear();

                waittingCombineList.ForEach(c => combineResult.AddRange(combineTemp.Select(s => s += c.ToString()).ToList()));

                combineTemp.Clear();
                combineTemp.AddRange(combineResult);
            }
        }
    }
}
