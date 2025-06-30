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
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();        
            CreateMap<CommentUser, CommentUserDto>().ReverseMap();
            CreateMap<Exam, ExamDto>().ReverseMap();
            CreateMap<UserAnswer, UserAnswerDto>().ReverseMap();
            CreateMap<Agency, AgencyDto>().ReverseMap();
            CreateMap<ExamBoard, ExamBoardDto>().ReverseMap();
            CreateMap<UserNotebook, UserNotebookDto>().ReverseMap();
            CreateMap<EducationLevel, EducationLevelDto>().ReverseMap();

        }
    }
}
