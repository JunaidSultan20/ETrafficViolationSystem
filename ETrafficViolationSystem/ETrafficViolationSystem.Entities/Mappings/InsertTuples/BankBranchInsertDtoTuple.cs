using System;
using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Mappings.InsertTuples
{
    public class BankBranchInsertDtoTuple : Tuple<BankBranchInsertDto, int>
    {
        public BankBranchInsertDtoTuple(BankBranchInsertDto bankBranchInsertDto, int userId) : base(bankBranchInsertDto,
            userId)
        { }

        public BankBranchInsertDto BankBranchDto => Item1;

        public int UserId => Item2;
    }
}