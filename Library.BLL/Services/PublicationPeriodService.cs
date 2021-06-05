using AutoMapper;
using Library.BLL.DTOs;
using Library.DAL.Entities;
using Library.DAL.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    public interface IPublicationPeriodService
    {
        IEnumerable<PublicationPeriodsDTO> GetAll();
        Task<PublicationPeriodsDTO> Add(PublicationPeriodsDTO publicationPeriodsDTO);
    }

    public class PublicationPeriodService : IPublicationPeriodService
    {
        private readonly IMapper _mapper;
        private readonly IPublicationPeriodsStore _publicationPeriodsStore;

        public PublicationPeriodService(IPublicationPeriodsStore publicationPeriodsStore,
                                        IMapper mapper)
        {
            _mapper = mapper;
            _publicationPeriodsStore = publicationPeriodsStore;
        }

        public IEnumerable<PublicationPeriodsDTO> GetAll()
        {
            return _mapper.Map<IEnumerable<PublicationPeriodsDTO>>(_publicationPeriodsStore.GetAll());
        }

        public async Task<PublicationPeriodsDTO> Add(PublicationPeriodsDTO publicationPeriodsDTO)
        {
            if (publicationPeriodsDTO == null)
                throw new ArgumentNullException(nameof(publicationPeriodsDTO));

            return _mapper.Map<PublicationPeriodsDTO>(await _publicationPeriodsStore.Add(_mapper.Map<PublicationPeriods>(publicationPeriodsDTO)));
        }
    }
}
