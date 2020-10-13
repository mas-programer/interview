using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    /// <summary>
    /// 映射处理器
    /// </summary>
    public interface IMappingHandler
    {
        /// <summary>
        /// 输入数据校验
        /// </summary>
        /// <param name="array"></param>
        /// <returns>输入无误返回true</returns>
        bool IsValidInput(params int[] array);

        /// <summary>
        /// 映射处理
        /// </summary>
        /// <param name="input"></param>
        /// <returns>返回组合后的列表</returns>
        List<string> Mapping(params int[] input);

        /// <summary>
        /// 输出数据处理
        /// </summary>
        /// <param name="mappingResult">组合好的列表</param>
        void OutputHandler(List<string> mappingResult);
    }
}
