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
    public class CarModelService : ICarModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CarModelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<IEnumerable<CarModelDto>>> GetModelsList()
        {
            IEnumerable<CarModel> result = await _unitOfWork.Repository<CarModel>().Get(x => x.IsActive);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<CarModelDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<CarModelDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<CarModelDto>>(result), result.Count());
        }

        public async Task<BaseResponse<IEnumerable<CarModelDto>>> GetByTitle(string title)
        {
            IEnumerable<CarModel> result = await _unitOfWork.Repository<CarModel>().Get(x => x.ModelTitle == title);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<CarModelDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<CarModelDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<CarModelDto>>(result), result.Count());
        }

        public async Task<BaseResponse<IEnumerable<CarModelDto>>> GetByYear(int year)
        {
            IEnumerable<CarModel> result = await _unitOfWork.Repository<CarModel>().Get(x => x.ProductionYear == year);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<CarModelDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<CarModelDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<CarModelDto>>(result),
                result.Count());
        }

        public async Task<BaseResponse<IEnumerable<CarModelDto>>> GetByMakeId(short id)
        {
            IEnumerable<CarModel> result = await _unitOfWork.Repository<CarModel>().Get(x => x.MakeId == id);
            if (result == null && !result.Any())
                return new BaseResponse<IEnumerable<CarModelDto>>(HttpStatusCode.NotFound, null);
            return new BaseResponse<IEnumerable<CarModelDto>>(HttpStatusCode.OK, null,
                _mapper.Map<IEnumerable<CarModelDto>>(result), result.Count());
        }

        public async Task<BaseResponse<CarModelDto>> GetById(string id)
        {
            CarModel result = await _unitOfWork.Repository<CarModel>().FindAsync(x => x.ModelId == id);
            if (result == null)
                return new BaseResponse<CarModelDto>(HttpStatusCode.NotFound, null);
            return new BaseResponse<CarModelDto>(HttpStatusCode.OK, null, _mapper.Map<CarModelDto>(result));
        }
    }
}