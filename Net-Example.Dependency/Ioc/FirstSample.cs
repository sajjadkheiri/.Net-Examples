namespace Net_Example.Dependency.Ioc;

public class FirstSample
{
    public void PrintName()
    {
        Printer printer;

        // Without ioc
        printer = new Printer();

        // With ioc
        printer = PrinterFactory.InitialPrinter();

        printer.Print("Hello ioc");
    }

}

public class Printer
{
    public void Print(string text)
    {
        Console.WriteLine(text);
    }
}

public class PrinterFactory
{
    public static Printer InitialPrinter() => new Printer();
}