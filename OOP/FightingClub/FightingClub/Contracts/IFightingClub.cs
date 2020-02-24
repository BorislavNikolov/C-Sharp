namespace FightingClub.Contracts
{
    using Models;
    public interface IFightingClub
    {
        string Name { get; }

        string Location { get; }

        int FansCount { get; }

        void AddManager(Manager manager);

        void AddFighter(Fighter fighter);

        void AddCoach(Coach coach);
    }
}
