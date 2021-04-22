namespace WOT
{
    public interface ICrew
    {
        void CrewTraining(Tanks tanks, int index);

        void DismissACrew(Tank tank, int index);

        void HireACrew(Tanks tanks, int index);
        
        bool CrewAvailability { get; set; }
    }
}