namespace Service.Contracts;

public interface IServiceManager
{
    ITeamService TeamService { get; }
    IPlayerService PlayerService { get; }
}
