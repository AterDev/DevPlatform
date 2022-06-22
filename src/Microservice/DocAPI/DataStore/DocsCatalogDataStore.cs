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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="language">����</param>
    /// <returns></returns>
    public async Task<List<DocsCatalogTreeItemDto>> GetTreeAsync(string language)
    {
        // ��ѯ����Ŀ¼
        var catalogs = await _db.Where(s => s.Language == language)
            .Select(s => new DocsCatalogTreeItemDto()
            {
                Id = s.Id,
                Name = s.Name,
                ParentId = s.Parent == null ? null : s.Parent.Id,
                Sort = s.Sort
            })
            .ToListAsync();

        // ��ѯ�����ĵ���ΪĿ¼�ṹ
        var docs = await _context.Docs.Where(s => s.Language == language)
            .Select(s => new DocsCatalogTreeItemDto
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
    public override async Task<DocsCatalog?> UpdateAsync(Guid id, DocsCatalogUpdateDto dto)
    {
        var current = await _db.FindAsync(id);
        current.Merge(dto);
        if (dto.ParentId != null)
        {
            var parent = await _db.FindAsync(dto.ParentId);
            if (parent != null)
            {
                current!.Parent = parent;
            }
        }

        await _context.SaveChangesAsync();
        return current;
    }
    public override Task<bool> DeleteAsync(Guid id) => base.DeleteAsync(id);

    public override Task<DocsCatalog?> FindAsync(Guid id)
    {
        return _db.Include(d => d.Parent).SingleOrDefaultAsync(d => d.Id == id);
    }
}
