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
            CreateMap<EducationLevelCreateDto, EducationLevel>().ReverseMap();
            CreateMap<EducationLevelUpdateDto, EducationLevel>().ReverseMap();

            CreateMap<Exam, ExamDto>()
               .ForMember(dest => dest.QuestionId, opt => opt.Ignore());
            CreateMap<ExamCreateDto, Exam>().ReverseMap();
            CreateMap<ExamUpdateDto, Exam>().ReverseMap();

            CreateMap<QuestionSet, QuestionSetDto>()
               .ForMember(dest => dest.QuestionIds, opt => opt.Ignore());
            CreateMap<QuestionSetCreateDto, QuestionSet>();
            CreateMap<QuestionSetUpdateDto, QuestionSet>();

            CreateMap<UserAnswer, UserAnswerDto>().ReverseMap(); 
            CreateMap<UserAnswerCreateDto, UserAnswer>().ReverseMap();

            CreateMap<UserAnswer, UserAnswerDto>().ReverseMap();
            CreateMap<UserAnswer, UserAnswerDto>().ReverseMap(); 
<<<<<<< HEAD
=======
            CreateMap<UserAnswer, UserAnswerDto>().ReverseMap(); // Resposta do Usuário
>>>>>>> a0d1987 (reorganiza projeto)
=======
>>>>>>> c04dafb (implementa entidade comentario profesor)

            CreateMap<CommentUser, CommentUserDto>().ReverseMap();           
            CreateMap<CommentUserCreateDto, CommentUser>().ReverseMap();
            CreateMap<CommentUserUpdateDto, CommentUser>().ReverseMap();

            CreateMap<Alternative, AlternativeDto>().ReverseMap();
<<<<<<< HEAD
            CreateMap<AlternativeCreateDto, Alternative>();
            CreateMap<AlternativeUpdateDto, Alternative>();
<<<<<<< HEAD
=======
            CreateMap<Alternative, AlternativeDto>().ReverseMap(); // Alternativa
>>>>>>> a0d1987 (reorganiza projeto)

=======
>>>>>>> c04dafb (implementa entidade comentario profesor)
=======
            CreateMap<AlternativeCreateDto, Alternative>().ReverseMap();
            CreateMap<AlternativeUpdateDto, Alternative>().ReverseMap();
>>>>>>> f092bb3 (implementa entidade comentario estados)

            CreateMap<CommentTeacher, CommentTeacherDto>().ReverseMap();
            CreateMap<CommentTeacherCreateDto, CommentTeacher>().ReverseMap();

            CreateMap<State, StateDto>().ReverseMap();
            CreateMap<StateCreateDto, State>().ReverseMap();
            CreateMap<StateUpdateDto, State>().ReverseMap();

            CreateMap<Year, YearDto>().ReverseMap();
            CreateMap<YearCreateDto, Year>().ReverseMap();
            CreateMap<YearUpdateDto, Year>().ReverseMap();
        }

    }

}