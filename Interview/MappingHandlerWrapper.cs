using System;
using System.Collections.Generic;
using System.Text;

namespace Interview
{
    /// <summary>
    /// 映射包装类
    /// </summary>
    public class MappingHandlerWrapper
    {
        IMappingHandler mappingHandler;

        public MappingHandlerWrapper(IDataSource dataSource)
        {
            mappingHandler = new CombineMappingHandler(dataSource);
        }

        public void DoMapping(params int[] input)
        {
            if (mappingHandler.IsValidInput(input))
            {
                var mappingResult = mappingHandler.Mapping(input);

                mappingHandler.OutputHandler(mappingResult);
            }
        }
    }
}
