using AutoMapper;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Models;

namespace ETrafficViolationSystem.Entities.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BankBranch, BankBranchDto>().ReverseMap();
            CreateMap<Banks, BanksDto>().ReverseMap();
            CreateMap<CarMake, CarMakeDto>().ReverseMap();
            CreateMap<CarModel, CarModelDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<Designation, DesignationDto>().ReverseMap();
            CreateMap<DriverDetails, DriverDetailsDto>().ReverseMap();
            CreateMap<Infractions, InfractionsDto>().ReverseMap();
            CreateMap<LicenseRecords, LicenseRecordsDto>().ReverseMap();
            CreateMap<LicenseSubTypes, LicenseSubTypesDto>().ReverseMap();
            CreateMap<LicenseTypes, LicenseTypesDto>().ReverseMap();
            CreateMap<Officers, OfficersDto>().ReverseMap();
            CreateMap<PaymentMode, PaymentModeDto>().ReverseMap();
            CreateMap<Payments, PaymentsDto>().ReverseMap();
            CreateMap<States, StatesDto>().ReverseMap();
            CreateMap<TaxDetails, TaxDetailsDto>().ReverseMap();
            CreateMap<VehicleBodyType, VehicleBodyTypeDto>().ReverseMap();
            CreateMap<VehicleClass, VehicleClassDto>().ReverseMap();
            CreateMap<VehicleColors, VehicleColorsDto>().ReverseMap();
            CreateMap<VehicleColorType, VehicleColorTypeDto>().ReverseMap();
            CreateMap<VehicleDetails, VehicleDetailsDto>().ReverseMap();
            CreateMap<Vehicles, VehiclesDto>().ReverseMap();
            CreateMap<ViolationRecordDetails, ViolationRecordDetailsDto>().ReverseMap();
            CreateMap<ViolationRecords, ViolationRecordsDto>().ReverseMap();
        }
    }
}