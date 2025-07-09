using Microsoft.EntityFrameworkCore;
using SoQuestoesIF.App.Dtos;
using SoQuestoesIF.Domain.Entities;
using SoQuestoesIF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoQuestoesIF.Infra.Data.Repositories
{
    public class QuestionSetRepository : IQuestionSetRepository
    {
        private readonly AppDbContext _context;

        public QuestionSetRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<QuestionSet> GetByIdAsync(Guid id)
        {
            return await _context.QuestionSets
                .Include(qs => qs.QuestionSetQuestion)
                .FirstOrDefaultAsync(qs => qs.Id == id);
        }

        public async Task<PagedResult<QuestionSet>> GetAllAsync(QuestionSetFilterDto filter)
        {
            var query = _context.QuestionSets
                .Include(qs => qs.QuestionSetQuestion)
                .AsQueryable();

            if (filter.UserId.HasValue)
            {
                query = query.Where(qs => qs.UserId == filter.UserId.Value);
            }

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(qs => qs.Name.Contains(filter.Name));
            }

            if (filter.IsActive.HasValue)
            {
                query = query.Where(qs => qs.IsActive == filter.IsActive.Value);
            }

            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new PagedResult<QuestionSet>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }

        public async Task AddAsync(QuestionSet entity)
        {
            await _context.QuestionSets.AddAsync(entity);
        }

        public void Update(QuestionSet entity)
        {
            _context.QuestionSets.Update(entity);
        }

        public void Delete(QuestionSet entity)
        {
            _context.QuestionSets.Remove(entity);
        }

        public async Task SaveQuestionSetQuestionsAsync(QuestionSet set, List<Guid> questionIds)
        {
            // Remove os links existentes
            var existingLinks = _context.QuestionSetQuestions.Where(q => q.QuestionSetId == set.Id);
            _context.QuestionSetQuestions.RemoveRange(existingLinks);

            // Adiciona novos links se houver questions
            if (questionIds != null && questionIds.Any())
            {
                var newLinks = questionIds.Select(qid => new QuestionSetQuestion
                {
                    QuestionSetId = set.Id,
                    QuestionId = qid
                }).ToList(); // Materializa para evitar problemas com AddRangeAsync

                await _context.QuestionSetQuestions.AddRangeAsync(newLinks);
            }
        }

        public async Task<bool> QuestionExistsAsync(Guid questionId)
        {
            // Implemente a verificação se a questão existe na tabela Question
            // Ex: return await _context.Questions.AnyAsync(q => q.Id == questionId);
            // Por enquanto, retorna true para simular a existência
            return await Task.FromResult(true);
        }
    }
}
