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
    public interface IAuthorService
    {
        Task<AuthorDTO> Add(AuthorDTO authorDTO);
        Task<AuthorDTO> DeleteById(int authorId);
        Task<AuthorDTO> Update(AuthorDTO authorDTO);
    }

    public class AuthorService : IAuthorService
    {
        private readonly IAuthorStore _authorStore;
        private readonly IMapper _mapper;


        public AuthorService(IAuthorStore authorStore,
                             IMapper mapper)
        {
            _authorStore = authorStore;
            _mapper = mapper;
        }

        public async Task<AuthorDTO> Add(AuthorDTO authorDTO)
        {
            if (authorDTO == null)
                throw new ArgumentNullException(nameof(authorDTO));

            return _mapper.Map<AuthorDTO>(await _authorStore.Add(_mapper.Map<Author>(authorDTO)));
        }

        public async Task<AuthorDTO> Update(AuthorDTO authorDTO)
        {
            if (authorDTO == null)
                throw new ArgumentNullException(nameof(authorDTO));

            return _mapper.Map<AuthorDTO>(await _authorStore.Update(_mapper.Map<Author>(authorDTO)));
        }

        public async Task<AuthorDTO> DeleteById(int authorId)
        {
            var authorToDelete = await _authorStore.GetById(authorId, false);

            if (authorToDelete == null)
                throw new ArgumentNullException(nameof(authorToDelete));

            return _mapper.Map<AuthorDTO>(await _authorStore.Delete(authorToDelete));
        }

    }
}
