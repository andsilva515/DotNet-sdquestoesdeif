using AutoMapper;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.App.Interfaces;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Services
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TopicService(ITopicRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TopicDto> GetByIdAsync(Guid id)
        {
            var topic = await _repository.GetByIdAsync(id);
            if (topic == null)
                throw new Exception("Órgão não encontrado.");

            return _mapper.Map<TopicDto>(topic);
        }

        public async Task<IEnumerable<TopicDto>> GetAllAsync()
        {
            var topics = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TopicDto>>(topics);
        }

        public async Task<Guid> CreateAsync(TopicCreateDto dto)
        {
            var topic = new Topic
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
                IsActive = true
            };

            await _repository.AddAsync(topic);
            await _unitOfWork.CommitAsync();

            return topic.Id;
        }

        public async Task UpdateAsync(Guid id, TopicUpdateDto dto)
        {
            var topic = await _repository.GetByIdAsync(id);
            if (topic == null)
                throw new Exception("Órgão não encontrado.");

            topic.Name = dto.Name;
            topic.Description = dto.Description;
            topic.IsActive = dto.IsActive;

            _repository.Update(topic);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var topic = await _repository.GetByIdAsync(id);
            if (topic == null)
                throw new Exception("Órgão não encontrado.");

            _repository.Delete(topic);
            await _unitOfWork.CommitAsync();
        }
    }
}
