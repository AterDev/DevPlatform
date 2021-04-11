using AutoMapper;
using Core.Services.AutoMapper;

namespace Services.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            // 定义你的模型转换
            // 如果使用cli工具，则取消以下注释
            AutoGenerateProfile.Init();
        }
    }
}
