using Core.Persistence.Repositories;
using Domain1.Entities1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Services.Repositories
{  //persistance bu interface referansını tutacak burası application iş sınıfı biz unit test yaparken data accesde işlem yapmamızlazım fake olarak yapıyoruz 
    public interface IBrandRepository: IAsyncRepository<Brand>, IRepository<Brand>
    {
        //branda özel repositori olursa buraya yapalım diye
    }
}
