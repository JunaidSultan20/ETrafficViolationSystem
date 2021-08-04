using System;
using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Mappings.InsertTuples
{
    public class RoleInsertDtoTuple : Tuple<RoleInsertDto, int>
    {
        public RoleInsertDtoTuple(RoleInsertDto roleInsertDto, int userId) : base(roleInsertDto, userId)
        { }

        public RoleInsertDto RoleInsertDto => Item1;

        public int UserId => Item2;
    }
}