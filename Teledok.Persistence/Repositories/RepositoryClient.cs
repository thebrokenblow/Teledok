using Microsoft.EntityFrameworkCore;
using Teledok.Domain;
using Teledok.Application.Common.Exceptions;
using Teledok.Application.Repositories.Interfaces;
using Teledok.Application.Clients.Commands.UpdateClient;
using Teledok.Application.Clients.Commands.CreateClient;

namespace Teledok.Persistence.Repositories;

public class RepositoryClient(IRepositoryFounder repositoryFounder, TeledokDbContext teledokDbContext) : IRepositoryClient
{
    public async Task AddAsync(CreateClientCommand createClientCommand, CancellationToken cancellationToken)
    {
        await using var transaction = teledokDbContext.Database.BeginTransaction();

        try
        {
            var founders = await repositoryFounder.GetByInnAsync(createClientCommand.INNFounders, cancellationToken);

            var client = new Client
            {
                INN = createClientCommand.INN,
                TitleCompany = createClientCommand.TitleCompany,
                TypeCompany = createClientCommand.TypeCompany,
                DateAdd = DateTime.UtcNow,
                Founders = founders,
            };

            await teledokDbContext.AddAsync(client, cancellationToken);
            await teledokDbContext.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);

            throw;
        }
    }

    public async Task DeleteAsync(string iNN, CancellationToken cancellationToken)
    {
        var client = await teledokDbContext.Clients
            .FirstOrDefaultAsync(client => client.INN == iNN, cancellationToken) 
            ?? throw new NotFoundException(nameof(Client), iNN);

        teledokDbContext.Clients.Remove(client);
        await teledokDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Client> GetDetailsAsync(string iNN, CancellationToken cancellationToken)
    {
        var client = await teledokDbContext.Clients
            .Include(x => x.Founders)
            .FirstOrDefaultAsync(x => x.INN == iNN, cancellationToken) ??
             throw new NotFoundException(nameof(Client), iNN);

        return client;
    }

    public Task<List<Client>> GetAsync(int countSkip, int countTake, CancellationToken cancellationToken) =>
        teledokDbContext.Clients
            .Skip(countSkip)
            .Take(countTake)
            .ToListAsync(cancellationToken);

    public async Task UpdateAsync(UpdateClientCommand updateClientCommand, CancellationToken cancellationToken)
    {
        await using var transaction = teledokDbContext.Database.BeginTransaction();

        try
        {
            var client = await teledokDbContext.Clients
                                        .SingleOrDefaultAsync(
                                            client => client.INN == updateClientCommand.INN, cancellationToken) ??
                                                throw new NotFoundException(nameof(Client), updateClientCommand.INN);

            var founders = await repositoryFounder.GetByInnAsync(updateClientCommand.INNFounders, cancellationToken);

            client.INN = updateClientCommand.INN;
            client.TitleCompany = updateClientCommand.TitleCompany;
            client.TypeCompany = updateClientCommand.TypeCompany;
            client.Founders = founders;
            client.DateEdit = DateTime.UtcNow;

            await teledokDbContext.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);

            throw;
        }
    }
}