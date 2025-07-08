using SoQuestoesIF.App.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.App.Interfaces
{
    public interface ITopicService
    {
        Task<TopicDto> GetByIdAsync(Guid id);
        Task<IEnumerable<TopicDto>> GetAllAsync();
        Task<Guid> CreateAsync(TopicCreateDto dto);
        Task UpdateAsync(Guid id, TopicUpdateDto dto);
        Task DeleteAsync(Guid id);
    }
}
