namespace Contracts;

public interface IRepositoryManager
{
    ITeamRepository Team { get; }
    IPlayerRepository Player { get; }
    void Save();
}
