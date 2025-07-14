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
    public class QuestionAccessService : IQuestionAccessService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserQuestionResolutionRepository _logRepository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionAccessService(
            ISubscriptionRepository subscriptionRepository,
            IUserQuestionResolutionRepository logRepository,
            IUnitOfWork unitOfWork)
        {
            _subscriptionRepository = subscriptionRepository;
            _logRepository = logRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CanResolveQuestionAsync(Guid userId)
        {
            // Verifica se tem assinatura

            // Verifica se a assinatura está vencida e expira, se necessário
            await CheckAndExpireSubscriptionAsync(userId);

            var activeSub = await _subscriptionRepository.GetActiveSubscriptionAsync(userId);
            if (activeSub != null)
                return true;

            // Usuário grátis: verifica limite diário
            var today = DateTime.UtcNow.Date;
            var log = await _logRepository.GetTodayLogAsync(userId, today);
            if (log == null)
                return true; // ainda não resolveu nenhuma hoje

            return log.ResolvedCount < 10;
        }
       
        // Verifica se a assinatura ativa do usuário expirou e inativa.       
        public async Task CheckAndExpireSubscriptionAsync(Guid userId)
        {
            var activeSub = await _subscriptionRepository.GetActiveSubscriptionAsync(userId);
            if (activeSub != null && activeSub.EndDate.HasValue && activeSub.EndDate.Value < DateTime.UtcNow)
            {
                activeSub.IsActive = false;
                _subscriptionRepository.Update(activeSub);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task IncrementResolutionCountAsync(Guid userId)
        {
            var today = DateTime.UtcNow.Date;
            var log = await _logRepository.GetTodayLogAsync(userId, today);

            if (log == null)
            {
                var newLog = new UserQuestionResolutionLog
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Date = today,
                    ResolvedCount = 1
                };
                await _logRepository.AddAsync(newLog);
            }
            else
            {
                log.ResolvedCount++;
                _logRepository.Update(log);
            }

            await _unitOfWork.CommitAsync();
        }
    }
}
