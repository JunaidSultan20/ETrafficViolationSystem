using System;
using ETrafficViolationSystem.Entities.Dto;

namespace ETrafficViolationSystem.Entities.Mappings.InsertTuples
{
    public class InfractionInsertDtoTuple : Tuple<InfractionsInsertDto, int>
    {
        public InfractionInsertDtoTuple(InfractionsInsertDto infractionsInsertDto, int userId) : base(infractionsInsertDto, userId)
        { }

        public InfractionsInsertDto InfractionsInsertDto => Item1;

        public int UserId => Item2;
    }
}