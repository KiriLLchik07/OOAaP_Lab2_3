public interface ICommand
{
    void Execute();
    
    static void Main()
    {
        Console.WriteLine("Hellow ICommand!");
    }
}