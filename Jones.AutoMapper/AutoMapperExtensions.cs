using AutoMapper;

namespace Jones.AutoMapper
{
    public static class AutoMapperExtensions
    {
        public static T ToDto<T>(this IModel model) where T : IDto
        {
            return Mapper.Map<T>(model);
        }
    }
}