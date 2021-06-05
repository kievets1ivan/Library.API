using AutoMapper;
using Library.BLL.DTOs;
using Library.BLL.Models;
using Library.DAL.Entities;
using Library.DAL.Services;
using Library.DAL.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    public interface IUdkService
    {
        Task<UdkDTO> Add(UdkDTO udkDTO);
        PaginationResponse<UdkDTO> GetAll(PagingParameters pagingParameters);
        PaginationResponse<UdkDTO> GetByUserId(Guid userId, PagingParameters pagingParameters);
        Task<UdkDTO> GetById(int udkId);
        Task<UdkDTO> Update(UdkDTO udkDTO);
    }

    public class UdkService : IUdkService
    {
        private readonly IUdkStore _udkStore;
        private readonly IMapper _mapper;
        private readonly IPagingService<Udk> _pagingService;


        public UdkService(IUdkStore udkStore,
                           IMapper mapper,
                           IPagingService<Udk> pagingService)
        {
            _udkStore = udkStore;
            _mapper = mapper;
            _pagingService = pagingService;
        }

        public async Task<UdkDTO> Add(UdkDTO udkDTO)
        {
            if (udkDTO == null)
                throw new ArgumentNullException(nameof(udkDTO));

            return _mapper.Map<UdkDTO>(await _udkStore.Add(_mapper.Map<Udk>(udkDTO)));
        }

        public PaginationResponse<UdkDTO> GetByUserId(Guid userId, PagingParameters pagingParameters)
        {
            var udks = _udkStore.GetByUserId(userId);

            var pagedList = _pagingService.ToPagedList(udks, pagingParameters.PageNumber, pagingParameters.PageSize);

            return new PaginationResponse<UdkDTO>
            {
                PageNumber = pagedList.PageNumber,
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalCount,
                TotalPages = pagedList.TotalPages,
                Items = _mapper.Map<IEnumerable<UdkDTO>>(pagedList.ToArray())
            };
        }

        public PaginationResponse<UdkDTO> GetAll(PagingParameters pagingParameters)
        {
            var udks = _udkStore.GetAll();

            var pagedList = _pagingService.ToPagedList(udks, pagingParameters.PageNumber, pagingParameters.PageSize);

            return new PaginationResponse<UdkDTO>
            {
                PageNumber = pagedList.PageNumber,
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalCount,
                TotalPages = pagedList.TotalPages,
                Items = _mapper.Map<IEnumerable<UdkDTO>>(pagedList.ToArray())
            };
        }

        public async Task<UdkDTO> GetById(int udkId)
        {
            var udk = await _udkStore.GetById(udkId);

            if (udk == null)
                throw new ArgumentNullException(nameof(udk));

            return _mapper.Map<UdkDTO>(udk);
        }

        public async Task<UdkDTO> Update(UdkDTO udkDTO)
        {
            if (udkDTO == null)
                throw new ArgumentNullException(nameof(udkDTO));

            return _mapper.Map<UdkDTO>(await _udkStore.Update(_mapper.Map<Udk>(udkDTO)));
        }
    }
}
