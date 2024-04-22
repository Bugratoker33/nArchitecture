using Application1.Features.Models.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Features.Models.Models
{
    public class ModelListModel:BasePageableModel
    {
        public IList<ModelListDto> Items { get; set; }

    }
}
