namespace Core.Persistence.Dynamic;

public class Dynamic
{
    public IEnumerable<Sort>? Sort { get; set; } //ben datayı şuna göre azalan artana göre sırala 
    public Filter? Filter { get; set; }

    public Dynamic()
    {
    }

    public Dynamic(IEnumerable<Sort>? sort, Filter? filter)
    {
        Sort = sort;
        Filter = filter;
    }
}