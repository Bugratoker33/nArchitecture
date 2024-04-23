using Application1.Features.Brands.Dtos;
using Application1.Services.Repositories;
using AutoMapper;
using Domain1.Entities1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application1.Features.Brands.Commands.Delete
{
    public class DeleteBrandCommand:IRequest<DeleteBrandDto>
    {
        public int Id { get; set; }


        public class DeleteBrandCommandHandeler : IRequestHandler<DeleteBrandCommand, DeleteBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
           private readonly  IMapper _mapper;

            public DeleteBrandCommandHandeler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
            }

            public async Task<DeleteBrandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {

                Brand mappedBrand = _mapper.Map<Brand>(request);
                Brand deleteBrand= await _brandRepository.DeleteAsync(mappedBrand);
                DeleteBrandDto deletedBrandDtos= _mapper.Map<DeleteBrandDto>(deleteBrand);

                return deletedBrandDtos;

            }
        }
    }
}
