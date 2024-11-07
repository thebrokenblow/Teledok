using AutoMapper;
using Teledok.Domain;
using Teledok.Application.Clients.Commands.UpdateClient;
using Teledok.Application.Clients.Queries.GetClientDetails;
using Teledok.Application.Clients.Commands.CreateClient;

namespace Teledok.Application.Repositories.Interfaces;

public interface IRepositoryClient
{
    Task AddAsync(CreateClientCommand createClientCommand, CancellationToken cancellationToken = default);
    Task DeleteAsync(string iNN, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateClientCommand request, CancellationToken cancellationToken = default);
    Task<List<Client>> GetAsync(int countSkip, int countTake, CancellationToken cancellationToken = default);
    Task<Client> GetDetailsAsync(string iNN, CancellationToken cancellationToken = default);
}