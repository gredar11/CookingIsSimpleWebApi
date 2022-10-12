namespace Shared.RequestFeatures
{
    public class PagedList<T> : List<T>
    {
        public PageMetaData MetaData { get; set; }
        public PagedList(List<T> items, int countOfAllElements, int pageNumber, int pageSize) 
        { 
            MetaData = new PageMetaData { TotalCount = countOfAllElements, PageSize = pageSize, CurrentPage = pageNumber, TotalPages = (int)Math.Ceiling(countOfAllElements / (double)pageSize) }; 
            AddRange(items); 
        }
        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count(); 
            var items = source.Skip((pageNumber - 1) * pageSize)
                              .Take(pageSize).ToList(); 
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
