// 该文件由GT.CLI工具生成，请不要删除模板占位符。
// Account;
// Role;
// Catalog;
// CodeSnippet;
// Library;
// {AlreadyMapedEntity}
using AutoMapper;
using Core.Entity;
using Core.Services.Models;

namespace Core.Services.AutoMapper
{
    /// <summary>
    /// GT.CLI 生成的AutoMapper配置
    /// </summary>
    public class GenerateProfile : Profile
    {
        public GenerateProfile()
        {
            CreateMap<AccountAddDto, Account>();
            CreateMap<AccountUpdateDto, Account>();
            CreateMap<Account, AccountDto>();
            CreateMap<Account, AccountDetailDto>();
            CreateMap<RoleAddDto, Role>();
            CreateMap<RoleUpdateDto, Role>();
            CreateMap<Role, RoleDto>();
            CreateMap<Role, RoleDetailDto>();
            CreateMap<CatalogAddDto, Catalog>();
            CreateMap<CatalogUpdateDto, Catalog>();
            CreateMap<Catalog, CatalogDto>();
            CreateMap<Catalog, CatalogDetailDto>();
                        CreateMap<CodeSnippetAddDto, CodeSnippet>();
            CreateMap<CodeSnippetUpdateDto, CodeSnippet>();
            CreateMap<CodeSnippet, CodeSnippetDto>();
            CreateMap<CodeSnippet, CodeSnippetDetailDto>();        
            CreateMap<LibraryAddDto, Library>();
            CreateMap<LibraryUpdateDto, Library>();
            CreateMap<Library, LibraryDto>();
            CreateMap<Library, LibraryDetailDto>();        
// {AppendMappers}
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
