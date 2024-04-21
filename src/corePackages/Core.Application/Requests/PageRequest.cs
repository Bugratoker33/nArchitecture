namespace Core.Application.Requests;

public class PageRequest
{
    public int Page { get; set; } //kaçıncı sayfayı istiyorsun 
    public int PageSize { get; set; } //ve bir sayfada kaç data olsun istiyorsun 
}