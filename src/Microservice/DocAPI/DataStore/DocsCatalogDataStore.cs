using DocAPI.Models.DocsCatalogDtos;
namespace DocAPI.DataStore;
public class DocsCatalogDataStore : DataStoreBase<DocsContext, DocsCatalog, DocsCatalogUpdateDto, DocsCatalogFilter, DocsCatalogItemDto>
{
    public DocsCatalogDataStore(DocsContext context, IUserContext userContext, ILogger<DocsCatalogDataStore> logger) : base(context, userContext, logger)
    {
    }
    public override Task<List<DocsCatalogItemDto>> FindAsync(DocsCatalogFilter filter)
    {
        return base.FindAsync(filter);
    }

    public override Task<PageResult<DocsCatalogItemDto>> FindWithPageAsync(DocsCatalogFilter filter)
    {
        return base.FindWithPageAsync(filter);
    }

    public async Task<List<DocsCatalogTreeItemDto>> GetTreeAsync()
    {
        // ��ѯ����Ŀ¼
        var catalogs = await  _db.Select(s=>new DocsCatalogTreeItemDto()
        {
            Id = s.Id,
            Name = s.Name,
            ParentId = s.Parent==null?null: s.Parent.Id,
            Sort = s.Sort
        }).ToListAsync();

        // ��ѯ�����ĵ���ΪĿ¼�ṹ
        var docs = await _context.Docs.Select(s=>new DocsCatalogTreeItemDto
        {
            Name = s.Name,
            Id = s.Id,
            ParentId = s.DocsCatalog.Id,
            IsDoc = true
        }).ToListAsync();

        // �ϲ�
        catalogs.AddRange(docs);

        // �������ͽṹ 
        var childsHash = catalogs.ToLookup(cat => cat.ParentId);
        foreach (var cat in catalogs)
        {
            cat.Children = childsHash[cat.Id].ToList();
        }
        catalogs = catalogs.Where(c => c.ParentId == null).ToList();
        return catalogs;
    }
    public override Task<DocsCatalog> AddAsync(DocsCatalog data) => base.AddAsync(data);
    public override Task<DocsCatalog?> UpdateAsync(Guid id, DocsCatalogUpdateDto dto) => base.UpdateAsync(id, dto);
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);
}
