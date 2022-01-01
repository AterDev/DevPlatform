// 该文件由GT.CLI工具生成，请不要删除模板占位符。
// Account;
// Role;
// Catalog;
// CodeSnippet;
// Library;
// Article;
// Comment;
// ArticleCatalog;
// LibraryCatalog;
// TagLibrary;
// {AlreadyMapedEntity}
using Share.Models.AccountDtos;
using Share.Models.ArticleCatalogDtos;
using Share.Models.ArticleDtos;
using Share.Models.CatalogDtos;
using Share.Models.CodeSnippetDtos;
using Share.Models.CommentDtos;
using Share.Models.CommonDtos;
using Share.Models.LibraryCatalogDtos;
using Share.Models.LibraryDtos;
using Share.Models.RoleDtos;
using Share.Models.TagLibraryDtos;
using Share.Models.ThirdNewsDtos;

namespace Share.AutoMapper;

/// <summary>
/// GT.CLI 生成的AutoMapper配置
/// </summary>
public class GenerateProfile : Profile
{
    public GenerateProfile()
    {
        CreateMap<AccountAddDto, Account>();
        CreateMap<AccountUpdateDto, Account>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => NotNull(srcMember))); ;
        CreateMap<Account, AccountDto>();
        CreateMap<Account, AccountItemDto>();
        CreateMap<Account, AccountDetailDto>();
        CreateMap<Account, SignInDto>();
        CreateMap<RoleAddDto, Role>();
        CreateMap<RoleUpdateDto, Role>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => NotNull(srcMember))); ;
        CreateMap<Role, RoleDto>();
        CreateMap<Role, RoleItemDto>();
        CreateMap<Role, RoleDetailDto>();
        CreateMap<CatalogAddDto, LibraryCatalog>();
        CreateMap<CatalogUpdateDto, LibraryCatalog>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => NotNull(srcMember))); ; ;
        CreateMap<LibraryCatalog, CatalogDto>();
        CreateMap<LibraryCatalog, CatalogItemDto>();
        CreateMap<LibraryCatalog, CatalogDetailDto>();
        CreateMap<CodeSnippetAddDto, CodeSnippet>();
        CreateMap<CodeSnippetUpdateDto, CodeSnippet>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => NotNull(srcMember))); ; ;
        CreateMap<CodeSnippet, CodeSnippetDto>();
        CreateMap<CodeSnippet, CodeSnippetItemDto>();
        CreateMap<CodeSnippet, CodeSnippetDetailDto>();
        CreateMap<LibraryAddDto, Library>();
        CreateMap<LibraryUpdateDto, Library>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => NotNull(srcMember))); ; ;
        CreateMap<Library, LibraryDto>();
        CreateMap<Library, LibraryItemDto>();
        CreateMap<Library, LibraryDetailDto>();
        CreateMap<ArticleAddDto, Article>();
        CreateMap<ArticleUpdateDto, Article>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => NotNull(srcMember)));
        CreateMap<Article, ArticleDto>();
        CreateMap<Article, ArticleItemDto>();
        CreateMap<Article, ArticleDetailDto>();
        CreateMap<CommentAddDto, Comment>();
        CreateMap<CommentUpdateDto, Comment>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => NotNull(srcMember))); ; ;
        CreateMap<Comment, CommentDto>();
        CreateMap<Comment, CommentItemDto>();
        CreateMap<Comment, CommentDetailDto>();
        CreateMap<ArticleCatalogAddDto, ArticleCatalog>();
        CreateMap<ArticleCatalogUpdateDto, ArticleCatalog>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => NotNull(srcMember))); ; ;
        CreateMap<ArticleCatalog, ArticleCatalogDto>();
        CreateMap<ArticleCatalog, ArticleCatalogItemDto>();
        CreateMap<ArticleCatalog, ArticleCatalogDetailDto>();
        CreateMap<LibraryCatalogAddDto, LibraryCatalog>();
        CreateMap<LibraryCatalogUpdateDto, LibraryCatalog>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => NotNull(srcMember))); ; ;
        CreateMap<LibraryCatalog, LibraryCatalogDto>();
        CreateMap<LibraryCatalog, LibraryCatalogItemDto>();
        CreateMap<LibraryCatalog, LibraryCatalogDetailDto>();

        CreateMap<NewsTagsAddDto, NewsTags>();
        CreateMap<ThirdNews, ThirdNewsDto>();

        CreateMap<TagLibraryAddDto, TagLibrary>();
        CreateMap<TagLibraryAddDto, TagLibrary>();
        CreateMap<TagLibraryUpdateDto, TagLibrary>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => NotNull(srcMember))); ;
        CreateMap<TagLibrary, TagLibraryDto>();
        CreateMap<TagLibrary, TagLibraryItemDto>();
        CreateMap<TagLibrary, TagLibraryDetailDto>();
        // {AppendMappers}

        bool NotNull(object src)
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
