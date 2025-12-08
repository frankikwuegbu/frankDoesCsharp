using Contracts;

namespace Repositories;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<ITeamRepository> _teamRepository;
    private readonly Lazy<IPlayerRepository> _playerRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _teamRepository = new Lazy<ITeamRepository>(() => new TeamRepository(repositoryContext));
        _playerRepository = new Lazy<IPlayerRepository>(() => new PlayerRepository(repositoryContext));
    }

    public ITeamRepository Team => _teamRepository.Value;
    public IPlayerRepository Player => _playerRepository.Value;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
