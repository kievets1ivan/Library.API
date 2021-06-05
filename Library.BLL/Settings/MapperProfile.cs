using AutoMapper;
using Library.BLL.DTOs;
using Library.BLL.Models;
using Library.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Settings
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Section, SectionDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Document, DocumentDTO>().ReverseMap();
            CreateMap<AuthorDocument, AuthorDocumentDTO>().ReverseMap();
            CreateMap<QuestionAnswer, QuestionAnswerDTO>().ReverseMap();
            CreateMap<Udk, UdkDTO>().ReverseMap();
            CreateMap<Publication, PublicationDTO>().ReverseMap();
            CreateMap<Period, PeriodDTO>().ReverseMap();
            CreateMap<PublicationPeriods, PublicationPeriodsDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ForMember(destination => destination.Login, opts => opts.MapFrom(source => source.Email));
        }
    }
}
