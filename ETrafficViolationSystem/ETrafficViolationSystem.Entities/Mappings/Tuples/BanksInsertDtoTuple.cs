using System;
using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Mappings.Tuples
{
    public class BanksInsertDtoTuple : Tuple<BanksInsertDto, int>
    {
        public BanksInsertDtoTuple(BanksInsertDto banksInsertDto, int userId) : base(banksInsertDto, userId)
        { }

        public BanksInsertDto BanksInsertDto => Item1;

        public int UserId => Item2;
    }
}