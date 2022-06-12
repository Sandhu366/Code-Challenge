using ApplicationShared.Remarks.Commands;
using AutoMapper;
using Domain;
using System;

namespace Factories.Remarks
{
    public class RemarkFactory : IRemarkFactory
    {
        private readonly IMapper _mapper;

        public RemarkFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Remark UpdateRemark(Remark destination, EditRemarkCommand source)
        {
            if (source is null)
            {
                throw new NullReferenceException($"{nameof(EditRemarkCommand)} is null");
            }

            destination.Body = source.Body ?? destination.Body;
            destination.Id = source.Id;

            return destination;
        }
    }
}
