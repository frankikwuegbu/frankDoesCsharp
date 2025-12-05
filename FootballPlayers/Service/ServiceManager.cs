using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ITeamService> _teamService;
    private readonly Lazy<IPlayerService> _playerService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _teamService = new Lazy<ITeamService>(() => new TeamService(repositoryManager, logger, mapper));

        _playerService = new Lazy<IPlayerService>(() => new PlayerService(repositoryManager, logger, mapper));
    }

    public ITeamService TeamService => _teamService.Value;
    public IPlayerService PlayerService => _playerService.Value;
}
