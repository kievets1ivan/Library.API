using AutoMapper;
using Library.BLL.DTOs;
using Library.BLL.Models;
using Library.DAL.Entities;
using Library.DAL.QueryBuilders;
using Library.DAL.Services;
using Library.DAL.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Services
{
    public interface IDocumentService
    {
        Task<DocumentDTO> Add(DocumentDTO documentDTO);
        Task<DocumentDTO> DeleteById(int documentId);
        Task<DocumentDTO> GetById(int documentId);
        Task<DocumentDTO> Update(DocumentDTO documentDTO);
        IEnumerable<DocumentDTO> GetDocumentsByFreshFlag(DocumentFilterParameters request);
        PaginationResponse<DocumentDTO> GetDocuments(PagingParameters pagingParameters);
    }

    public class DocumentService : IDocumentService
    {
        private readonly IDocumentStore _documentStore;
        private readonly IDbTransactionService _dbTransactionService;
        private readonly IMapper _mapper;
        private readonly IDocumentQueryBuilder _documentQueryBuilder;
        private readonly IPagingService<Document> _pagingService;


        public DocumentService(IDocumentStore documentStore,
                               IDbTransactionService dbTransactionService,
                               IMapper mapper,
                               IDocumentQueryBuilder documentQueryBuilder,
                               IPagingService<Document> pagingService)
        {
            _dbTransactionService = dbTransactionService;
            _documentStore = documentStore;
            _mapper = mapper;
            _documentQueryBuilder = documentQueryBuilder;
            _pagingService = pagingService;
        }

        public async Task<DocumentDTO> GetById(int documentId)
        {
            var document = await _documentStore.GetById(documentId);

            if (document == null)
                throw new ArgumentNullException(nameof(document));

            return _mapper.Map<DocumentDTO>(document);
        }
        public PaginationResponse<DocumentDTO> GetDocuments(PagingParameters pagingParameters)
        {
            var documents = SelectDocumentsByParams(pagingParameters);

            var pagedList = _pagingService.ToPagedList(documents, pagingParameters.PageNumber, pagingParameters.PageSize);

            return new PaginationResponse<DocumentDTO>
            {
                PageNumber = pagedList.PageNumber,
                PageSize = pagedList.PageSize,
                TotalCount = pagedList.TotalCount,
                TotalPages = pagedList.TotalPages,
                Items = _mapper.Map<IEnumerable<DocumentDTO>>(pagedList.ToArray())
            };
        }

        public IQueryable<Document> SelectDocumentsByParams(PagingParameters parameters) => _documentQueryBuilder.InitDocs()
                                                                                                                     .SetSection(parameters.SectionId)
                                                                                                                     .SetSearchTerm(parameters.SearchTerm)
                                                                                                                     .Build();

        public IEnumerable<DocumentDTO> GetDocumentsByFreshFlag(DocumentFilterParameters request)
        {
            List<Document> query = _documentQueryBuilder.InitDocs()
                                                        .SetFreshFlag(request.IsFresh)
                                                        .OrderByCreatedOn()
                                                        .SetTakeAmount(request.TakeAmount)
                                                        .Build()
                                                        .ToList();

            return _mapper.Map<IEnumerable<DocumentDTO>>(query);
        }

        public async Task<DocumentDTO> Add(DocumentDTO documentDTO)
        {
            if (documentDTO == null)
                throw new ArgumentNullException(nameof(documentDTO));

            return _mapper.Map<DocumentDTO>(await _documentStore.Add(_mapper.Map<Document>(documentDTO)));
        }

        public async Task<DocumentDTO> Update(DocumentDTO documentDTO)
        {
            if (documentDTO == null)
                throw new ArgumentNullException(nameof(documentDTO));

            return _mapper.Map<DocumentDTO>(await _documentStore.Update(_mapper.Map<Document>(documentDTO)));
        }

        public async Task<DocumentDTO> DeleteById(int documentId)
        {
            var documentToDelete = await _documentStore.GetById(documentId, false);

            if (documentToDelete == null)
                throw new ArgumentNullException(nameof(documentToDelete));

            return _mapper.Map<DocumentDTO>(await _documentStore.Delete(documentToDelete));
        }
    }
}
