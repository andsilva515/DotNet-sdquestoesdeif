using AutoMapper;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {   

            CreateMap<User, UserDto>()
               .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()))
               .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<QuestionCreateDto, Question>();
            CreateMap<QuestionUpdateDto, Question>();

            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<SubjectCreateDto, Subject>();
            CreateMap<SubjectUpdateDto, Subject>();

            CreateMap<Agency, AgencyDto>().ReverseMap();
            CreateMap<AgencyCreateDto, Agency>().ReverseMap();
            CreateMap<AgencyUpdateDto, Agency>().ReverseMap();


            CreateMap<ExamBoard, ExamBoardDto>().ReverseMap(); // Banca
            CreateMap<EducationLevel, EducationLevelDto>().ReverseMap(); // Escolaridade

            // Position
            // Topic  

            CreateMap<Alternative, AlternativeDto>().ReverseMap(); // Alternativa

            CreateMap<Exam, ExamDto>().ReverseMap(); // Simulado
            CreateMap<QuestionSet, QuestionSetDto>().ReverseMap(); // Caderno
            CreateMap<UserAnswer, UserAnswerDto>().ReverseMap(); // Resposta do Usuário               
            CreateMap<CommentUser, CommentUserDto>().ReverseMap(); // Comentário do Usuário (para o forum)

        }

    }

}