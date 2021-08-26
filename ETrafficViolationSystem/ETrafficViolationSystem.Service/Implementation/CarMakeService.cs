using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ETrafficViolationSystem.Data.UnitOfWork.Interface;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;
using ETrafficViolationSystem.Entities.Response;
using ETrafficViolationSystem.Service.Interface;

namespace ETrafficViolationSystem.Service.Implementation
{
    public class CarMakeService : ICarMakeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarMakeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<CarMakeDto>>> GetCarMakeList()
        {
            IEnumerable<CarMake> result = await _unitOfWork.Repository<CarMake>().Get(x => x.IsActive);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<CarMakeDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<CarMakeDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<CarMakeDto>>(result), result.Count());
        }

        public async Task<BaseResponse<IEnumerable<CarMakeDto>>> GetByOriginCountry(int id)
        {
            IEnumerable<CarMake> result = await _unitOfWork.Repository<CarMake>().Get(x => x.OriginCountryId == id);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<CarMakeDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<CarMakeDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<CarMakeDto>>(result), result.Count());
        }
    }
}