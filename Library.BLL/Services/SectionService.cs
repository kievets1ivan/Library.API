using AutoMapper;
using Library.BLL.DTOs;
using Library.DAL.Entities;
using Library.DAL.QueryBuilders;
using Library.DAL.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    public interface ISectionService
    {
        Task<SectionDTO> Add(SectionDTO sectionDTO);
        Task<SectionDTO> DeleteById(int sectionId);
        Task<SectionDTO> GetById(int sectionId);
        Task<SectionDTO> Update(SectionDTO sectionDTO);
        IEnumerable<SectionDTO> GetSections(bool? isTopSection);
    }

    public class SectionService : ISectionService
    {
        private readonly ISectionStore _sectionStore;
        private readonly IMapper _mapper;
        private readonly ISectionQueryBuilder _sectionQueryBuilder;


        public SectionService(ISectionStore sectionStore,
                              IMapper mapper,
                              ISectionQueryBuilder sectionQueryBuilder)
        {
            _sectionStore = sectionStore;
            _mapper = mapper;
            _sectionQueryBuilder = sectionQueryBuilder;
        }

        public IEnumerable<SectionDTO> GetSections(bool? isTopSection) => _mapper.Map<IEnumerable<SectionDTO>>(_sectionQueryBuilder.InitSections()
                                                                                                                                  .SetTopSection(isTopSection)
                                                                                                                                  .Build()
                                                                                                                                  .ToList());

        public async Task<SectionDTO> GetById(int sectionId)
        {
            return _mapper.Map<SectionDTO>(await _sectionStore.GetById(sectionId));
        }

        public async Task<SectionDTO> Add(SectionDTO sectionDTO)
        {
            if (sectionDTO == null)
                throw new ArgumentNullException(nameof(sectionDTO));

            return _mapper.Map<SectionDTO>(await _sectionStore.Add(_mapper.Map<Section>(sectionDTO)));
        }

        public async Task<SectionDTO> Update(SectionDTO sectionDTO)
        {
            if (sectionDTO == null)
                throw new ArgumentNullException(nameof(sectionDTO));

            return _mapper.Map<SectionDTO>(await _sectionStore.Update(_mapper.Map<Section>(sectionDTO)));
        }

        public async Task<SectionDTO> DeleteById(int sectionId)
        {
            var sectionToDelete = await _sectionStore.GetById(sectionId, false);

            if (sectionToDelete == null)
                throw new ArgumentNullException(nameof(sectionToDelete));

            return _mapper.Map<SectionDTO>(await _sectionStore.Delete(sectionToDelete));
        }
    }
}
