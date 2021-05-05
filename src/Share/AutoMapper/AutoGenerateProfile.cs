// 该文件由GT.CLI工具生成，请不要删除模板占位符。
// Account;
// Role;
// Catalog;
// CodeSnippet;
// Library;
// Article;
// Comment;
// ArticleCatalog;
// {AlreadyMapedEntity}
using AutoMapper;
using Core.Entity;
using Share.Models;
using Share.Models.Common;
using System;

namespace Share.AutoMapper
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
            CreateMap<Account, AccountItemDto>();
            CreateMap<Account, AccountDetailDto>();
            CreateMap<Account, SignInDto>();
            CreateMap<RoleAddDto, Role>();
            CreateMap<RoleUpdateDto, Role>();
            CreateMap<Role, RoleDto>();
            CreateMap<Role, RoleItemDto>();
            CreateMap<Role, RoleDetailDto>();
            CreateMap<CatalogAddDto, Catalog>();
            CreateMap<CatalogUpdateDto, Catalog>();
            CreateMap<Catalog, CatalogDto>();
            CreateMap<Catalog, CatalogItemDto>();
            CreateMap<Catalog, CatalogDetailDto>();
            CreateMap<CodeSnippetAddDto, CodeSnippet>();
            CreateMap<CodeSnippetUpdateDto, CodeSnippet>();
            CreateMap<CodeSnippet, CodeSnippetDto>();
            CreateMap<CodeSnippet, CodeSnippetItemDto>();
            CreateMap<CodeSnippet, CodeSnippetDetailDto>();
            CreateMap<LibraryAddDto, Library>();
            CreateMap<LibraryUpdateDto, Library>();
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
            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<Comment, CommentDto>();
            CreateMap<Comment, CommentItemDto>();
            CreateMap<Comment, CommentDetailDto>();
            CreateMap<ArticleCatalogAddDto, ArticleCatalog>();
            CreateMap<ArticleCatalogUpdateDto, ArticleCatalog>();
            CreateMap<ArticleCatalog, ArticleCatalogDto>();
            CreateMap<ArticleCatalog, ArticleCatalogItemDto>();
            CreateMap<ArticleCatalog, ArticleCatalogDetailDto>();
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
}
