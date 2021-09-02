// 该文件由GT.CLI工具生成，请不要删除模板占位符。
// ThirdNews;
// {AlreadyMapedEntity}
using AutoMapper;

namespace Core.Services.AutoMapper
{
    /// <summary>
    /// GT.CLI 生成的AutoMapper配置
    /// </summary>
    public class GenerateProfile : Profile
    {
        public GenerateProfile()
        {

            CreateMap<ThirdNewsAddDto, ThirdNews>();
            CreateMap<ThirdNewsUpdateDto, ThirdNews>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => NotNull(srcMember)));
            CreateMap<ThirdNews, ThirdNewsDto>();
            CreateMap<ThirdNews, ThirdNewsItemDto>();
            CreateMap<ThirdNews, ThirdNewsDetailDto>();
            // {AppendMappers}

        }
        static bool NotNull(object src)
        {
            return src switch
            {
                null => false,
                int @int when @int == 0 => false,
                Guid guid when guid == Guid.Empty => false,
                _ => true
            };
        }
    }



    /// <summary>
    /// 请使用该静态类，配置到自己的mapperProfile中,如:AutoGenerateProfile.Init();
    /// </summary>
    public static class AutoGenerateProfile
    {
        public static void Init()
        {
            new GenerateProfile();
        }
    }
}
