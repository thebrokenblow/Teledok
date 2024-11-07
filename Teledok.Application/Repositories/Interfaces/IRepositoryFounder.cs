using Teledok.Application.Founders.Commands.UpdateFounder;
using Teledok.Domain;

namespace Teledok.Application.Repositories.Interfaces;

public interface IRepositoryFounder
{
    Task AddAsync(Founder founder, CancellationToken cancellationToken = default);
    Task DeleteAsync(string iNN, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateFounderCommand request, CancellationToken cancellationToken = default);
    Task<Founder> GetDetailsAsync(string iNN, CancellationToken cancellationToken = default);
    Task<List<Founder>> GetAsync(int countSkip, int countTake, CancellationToken cancellationToken = default);
    Task<List<Founder>> GetByInnAsync(List<string> iNNFounders, CancellationToken cancellationToken = default);
}