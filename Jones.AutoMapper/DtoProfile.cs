using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Jones.AutoMapper
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            var assembliesToScan = AppDomain.CurrentDomain.GetAssemblies();
            var models = assembliesToScan.SelectMany(p => p.DefinedTypes).Where(p => p.IsClass && typeof (IModel).GetTypeInfo().IsAssignableFrom(p)).ToArray();
            var dtoAry = assembliesToScan.SelectMany(p => p.DefinedTypes).Where(p => p.IsClass && typeof (IDto).GetTypeInfo().IsAssignableFrom(p)).ToArray();
            foreach (var dto in dtoAry)
            {
                var modelName = dto.Name.Replace("Dto", "");
                var modelType = models.FirstOrDefault(p => p.Name.Equals(modelName));
                if (modelType != null)
                {
                    CreateMap(modelType, dto);
                }
            }
        }
    }
}