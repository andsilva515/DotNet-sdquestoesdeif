using AutoMapper;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.App.Services;
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

            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

            CreateMap<Subscription, SubscriptionDto>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));
            CreateMap<Package, PackageDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()));
            CreateMap<PackageCreateDto, Package>().ReverseMap();

            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<QuestionCreateDto, Question>().ReverseMap();
            CreateMap<QuestionUpdateDto, Question>().ReverseMap();

            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<SubjectCreateDto, Subject>().ReverseMap();
            CreateMap<SubjectUpdateDto, Subject>();

            CreateMap<Agency, AgencyDto>().ReverseMap();
            CreateMap<AgencyCreateDto, Agency>().ReverseMap();
            CreateMap<AgencyUpdateDto, Agency>();

            CreateMap<ExamBoard, ExamBoardDto>().ReverseMap();
            CreateMap<ExamBoardCreateDto, ExamBoard>().ReverseMap();
            CreateMap<ExamBoardUpdateDto, ExamBoard>().ReverseMap();

            CreateMap<Position, PositionDto>().ReverseMap();
            CreateMap<PositionCreateDto, Position>().ReverseMap();
            CreateMap<PositionUpdateDto, Position>().ReverseMap();

            CreateMap<Topic, TopicDto>().ReverseMap();
            CreateMap<TopicCreateDto, Topic>().ReverseMap();
            CreateMap<TopicUpdateDto, Topic>().ReverseMap();

            CreateMap<EducationLevel, EducationLevelDto>().ReverseMap(); 
            CreateMap<EducationLevelCreateDto, EducationLevel>();
            CreateMap<EducationLevelUpdateDto, EducationLevel>();

            CreateMap<QuestionSet, QuestionSetDto>()
            .ForMember(dest => dest.QuestionIds, opt => opt.Ignore());
            CreateMap<QuestionSetCreateDto, QuestionSet>().ReverseMap();
            CreateMap<QuestionSetUpdateDto, QuestionSet>().ReverseMap();

            CreateMap<UserAnswer, UserAnswerDto>().ReverseMap(); 
            CreateMap<UserAnswerCreateDto, UserAnswer>().ReverseMap();
        
            CreateMap<CommentUser, CommentUserDto>().ReverseMap();           
            CreateMap<CommentUserCreateDto, CommentUser>().ReverseMap();
            CreateMap<CommentUserUpdateDto, CommentUser>().ReverseMap();

            CreateMap<Alternative, AlternativeDto>().ReverseMap();
            CreateMap<AlternativeCreateDto, Alternative>();
            CreateMap<AlternativeUpdateDto, Alternative>();

            CreateMap<CommentTeacher, CommentTeacherDto>().ReverseMap();
            CreateMap<CommentTeacherCreateDto, CommentTeacher>().ReverseMap();

            CreateMap<State, StateDto>().ReverseMap();
            CreateMap<StateCreateDto, State>().ReverseMap();
            CreateMap<StateUpdateDto, State>().ReverseMap();

            CreateMap<Year, YearDto>().ReverseMap();
            CreateMap<YearCreateDto, Year>().ReverseMap();
            CreateMap<YearUpdateDto, Year>().ReverseMap();

            // Mapeamento de Exam para ExamDto
            // QuestionId é mapeado manualmente no serviço
            CreateMap<Exam, ExamDto>()
                .ForMember(dest => dest.QuestionId, opt => opt.Ignore());

            // Mapeamento de DTOs de criação/atualização para a entidade Exam
            // Propriedades como Id, CreatedAt, CreatedById e a coleção ExamQuestions são tratadas manualmente no serviço
            CreateMap<ExamCreateDto, Exam>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.ExamQuestions, opt => opt.Ignore());

            CreateMap<ExamUpdateDto, Exam>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.ExamQuestions, opt => opt.Ignore());
       
        }

    }

}