namespace FightingClub.Contracts
{
    public interface IPerson
    {
        string Name { get; }
        int Age { get; }

        string Nationality { get; }

        string Addres { get; }

        void Work();

        string Info();

        void ChangeAddres(string newAddres);
    }
}
