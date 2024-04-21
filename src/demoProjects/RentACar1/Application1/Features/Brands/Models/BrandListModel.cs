using Application1.Features.Brands.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Features.Brands.Models
{
    public class BrandListModel:BasePageableModel  //BasePageableModel = Gelen datalar ilgili sayfa kaç adet data var gibi ;:
        //neden dto değilde model yaptık Dto veri tabanından gelen datanın görünümü Join atma gibi 
        //model de sayfa bilgisi ve dtoları döndüreceğiz :;
    {
        
        public IList<BrandListDto> Items { get; set; }
    }
}
