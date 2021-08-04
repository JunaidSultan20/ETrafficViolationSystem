using System;
using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Mappings.InsertTuples
{
    public class StateInsertMappingTuple : Tuple<StatesInsertDto, int>
    {
        public StateInsertMappingTuple(StatesInsertDto statesInsertDto, int userId) : base(statesInsertDto, userId)
        { }

        public StatesInsertDto StatesInsertDto => Item1;

        public int UserId => Item2;
    }
}