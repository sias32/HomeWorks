namespace HomeWork_05;
public static class HomeWork_05
{
    public static void Main()
    {
        Quadcopter quadcopter = new Quadcopter("Salut01");

        var info = quadcopter.GetInfo();
        Console.WriteLine($"Info[ {info} ]");

        foreach (var item in quadcopter.GetComponents())
        {
            Console.WriteLine("Component: " + item);
        }

        quadcopter.Charge();

        Console.WriteLine();

        IRobot robot = new Quadcopter("Robot01");
        IFlyingRobot flyingRobot = new Quadcopter("FlyingRobot01");

        IRobot[] robots = { robot, flyingRobot };
        foreach (var item in robots)
        {
            var robotInfo = item.GetInfo();
            Console.WriteLine($"Info[ {robotInfo} ]");

            var robotType = item.GetRobotType();
            Console.WriteLine("Type: " + robotType);

            Console.WriteLine();
        }

        Console.WriteLine("Реализация всех методов IRobot через класс Robot\n");
        Robot bot1 = new Robot();
        Console.WriteLine("GetRobotType: " + bot1.GetRobotType());
        Console.WriteLine("GetComponents: " + String.Join(" ", bot1.GetComponents()));
        Console.WriteLine("GetInfo: " + bot1.GetInfo());
        Console.WriteLine();

        Console.WriteLine("Реализация всех методов IFlyingRobot через класс FlyingRobot\n");
        FlyingRobot bot2 = new FlyingRobot();
        Console.WriteLine("GetRobotType: " + bot2.GetRobotType());
        Console.WriteLine("GetComponents: " + String.Join(" ", bot2.GetComponents()));
        Console.WriteLine("GetInfo: " + bot2.GetInfo());
        Console.WriteLine();

        Console.WriteLine("Реализация всех методов IChargeable через класс Chargeable\n");
        Chargeable bot3 = new Chargeable();
        Console.Write("Charge");
        bot3.Charge();
        Console.WriteLine("GetInfo: " + bot3.GetInfo());
    }
}

interface IRobot
{
    string GetInfo();
    List<string> GetComponents();
    string GetRobotType() => "I am a simple robot.";
}

interface IChargeable
{
    string GetInfo();

    void Charge();
}

interface IFlyingRobot : IRobot
{
    new string GetRobotType() => "I am a flying robot.";
}

public class Quadcopter : IFlyingRobot, IChargeable
{
    private List<string> components = new List<string>() { "rotor1", "rotor2", "rotor3", "rotor4" };

    public void Charge()
    {
        //throw new NotImplementedException();
        Console.WriteLine("Charging...");
        Thread.Sleep(3000);
        Console.WriteLine("Charged!");
    }

    public List<string> GetComponents() => components;

    public Quadcopter(string name) => _info = "Name: " + name;

    // Скрытая переменная
    private string _info;
    // Через метод можно информацию получить
    public string GetInfo() => _info;
}

public class Robot : IRobot
{
    public List<string> GetComponents() => new List<string>() { "Пустой лист" };

    public string GetInfo() => "Я класс Robot, от интерфейса IRobot";

    //Переопределил метод, в классе
    public string GetRobotType() => "Я метод IRobot, переопределен в классе Robot";
}

public class Chargeable : IChargeable
{
    public void Charge() => Console.WriteLine("Заряжен на 100%");

    public string GetInfo() => "Я класс Chargeable, от интерфейса IChargeable";
}

public class FlyingRobot : IFlyingRobot
{
    public List<string> GetComponents() => new List<string>() { "Пустой лист" };

    public string GetInfo() => "Я класс FlyingRobot, от интерфейса IFlyingRobot";

    public string GetRobotType() => "Я летающий робот, переопределен в классе FlyingRobot";
}