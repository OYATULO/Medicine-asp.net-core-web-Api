namespace Medicine.API.Extentions
{
    public static  class Paginations
    {
        public static IEnumerable<T> Pages<T>(this IEnumerable<T> pages,int startPage,int pageSize) => pages.Skip((startPage-1)* pageSize).Take(pageSize);
    }
}
