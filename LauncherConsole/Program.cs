
using BDDSampleProject;
using BDDSampleProject.Operations;
using BDDSampleProject.Operations.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

internal class Program
{
    private static void Main(string[] args)
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        InitCalculatorServices(builder.Services);

        using IHost host = builder.Build();

        Run(host.Services);

        host.Run();
    }

    private static void InitCalculatorServices(IServiceCollection services)
    {
        services.AddCalculatorServices();
    }

    static void Run(IServiceProvider hostProvider)
    {
        using IServiceScope serviceScope = hostProvider.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;
        ICalculator calculator = provider.GetRequiredService<ICalculator>();
        IEnumerable<IOperation> operations = provider.GetServices<IOperation>();

        Console.WriteLine("Calculator loaded : Press x to exit then enter");
        while(true)
        {
            try
            {
                AskLeftMember(calculator);
                AskRightMember(calculator);
                OperationType operationType = ChooseOperation(operations);
                try
                {
                    var result = calculator.MakeOperation(operationType);
                    Console.WriteLine($"Your result is {result}");
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch (ExitRequiredException e)
            {
                if (!string.IsNullOrEmpty(e.Message))
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("Calculator stopped");
                Task.Delay(2000);
                break;
            }
        }
    }

    private static OperationType ChooseOperation(IEnumerable<IOperation> operations)
    {
        if (operations.Count() == 0)
            throw new ExitRequiredException("No operations found");
    ChooseOperation:
        Console.WriteLine("What is your operation ?");
        foreach (var possibleOperation in operations)
        {
            Console.WriteLine($"{(int)possibleOperation.OperationType + 1} : {possibleOperation.OperationType.ToString()}");
        }
        var choice = Console.ReadLine(); 
        if (choice == "x")
            throw new ExitRequiredException();
        if (int.TryParse(choice, out int operationType))
        {
            operationType--;
            if (Enum.IsDefined(typeof(OperationType), operationType))
            {
                return (OperationType)operationType;
            }
            goto ChooseOperation;
        }
        throw new ExitRequiredException();
    }

    private static void AskRightMember(ICalculator calculator)
    {
    NeedRightMember:
        Console.WriteLine("What is your right member of your operation ?");
        var line = Console.ReadLine();
        if (line == "x")
            throw new ExitRequiredException();
        if (int.TryParse(line, out int rightmember))
        {
            calculator.AddRightMember(rightmember);
        }
        else
        {
            goto NeedRightMember;
        }
    }
    private static void AskLeftMember(ICalculator calculator)
    {
    NeedLeftMember:
        Console.WriteLine("What is your left member of your operation ?");
        var line = Console.ReadLine();
        if (line == "x")
            throw new ExitRequiredException();
        if (int.TryParse(line, out int rightmember))
        {
            calculator.AddLeftMember(rightmember);
        }
        else
        {
            goto NeedLeftMember;
        }
    }
}