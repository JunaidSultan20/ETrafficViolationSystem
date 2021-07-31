using System;
using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Mappings.Tuples
{
    public class RoleInsertDtoTuple : Tuple<RoleInsertDto, int>
    {
        public RoleInsertDtoTuple(RoleInsertDto roleInsertDto, int userId) : base(roleInsertDto, userId)
        { }

        public RoleInsertDto RoleInsertDto => Item1;

        public int UserId => Item2;
    }
}