
namespace Unit_Converter;

class Program
{
    private int RenderMenu(string title , List<String> menu)
    {
        int option = 0;
        int maxLength = menu.Max(x => x.Length);
        if (title.Length > maxLength)
        {
            maxLength = title.Length;
        }
        string line = ("|" + new string('=', maxLength + 4) + "|");
        do
        {
            Console.Clear();
            
            Console.WriteLine(line);
            Console.WriteLine(string.Format("| {0, -"+ maxLength +"}   |", title));
            Console.WriteLine(line);
            for (int i = 0; i < menu.Count; i++)
            {
                if (i == option)
                {
                    Console.WriteLine(string.Format("| > {0, -"+ maxLength +"} |", menu[i]));
                }
                else
                {
                    Console.WriteLine(string.Format("|  {0, -"+ (maxLength + 1) +"} |", menu[i]));
                }
            }
            Console.WriteLine(line);
            //capture key press one at a time
            var cki = Console.ReadKey();
            
            if (cki.Key == ConsoleKey.UpArrow)
            {
                option--;
                if (option == 0)
                {
                    option = menu.Count - 1;
                }
            }
            else if (cki.Key == ConsoleKey.DownArrow)
            {
                option++;
                if (option == menu.Count)
                {
                    option = 0;
                }
            }
            else if (cki.Key == ConsoleKey.Enter)
            {
                return option;
            }
           
        } while (true);
    }
    public void Menu()
    {
        int option = 0;
        ConsoleKeyInfo cki = default;
        List<String> menu = new List<String>
        {
            "Mass",
            "Length",
            "Temperature",
            "Time",
            "Area",
            "Volume",
            "Data",
            "Quit"
        };
        do{
            option = RenderMenu( "Unit Converter",menu);
            switch (option)
            {
                case 0:
                    Console.WriteLine("Mass");
                    break;
                case 1:
                    Console.WriteLine("Length");
                    break;
                case 2:
                    Console.WriteLine("Temperature");
                    break;
                case 3:
                    Console.WriteLine("Time");
                    break;
                case 4:
                    Console.WriteLine("Area");
                    break;
                case 5:
                    Console.WriteLine("Volume");
                    break;
                case 6:
                    Console.WriteLine("Data");
                    break;
                case 7:
                    Console.WriteLine("Quit");
                    break;
            }
            cki = Console.ReadKey();
        } while (!(option == 13));
    }
    
    static void Main()
    {
        Program p = new Program();
        p.Menu();
    }
}