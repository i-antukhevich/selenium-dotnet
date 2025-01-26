using System.Reflection;

namespace AutomationHost.Utils.Validators;

public static class Validate
{
    public static void CommandArgs(Delegate command, object[] args)
    {
        // Get method parameters
        ParameterInfo[] parameters = command.Method.GetParameters();

        if (parameters.Length != args.Length)
        {
            throw new ArgumentException($"Expected {parameters.Length} arguments, but received {args.Length}.");
        }

        // Validate types of arguments
        for (int i = 0; i < parameters.Length; i++)
        {
            if (args[i] != null && !parameters[i].ParameterType.IsInstanceOfType(args[i]))
            {
                throw new ArgumentException($"Argument {i + 1} is of incorrect type. Expected {parameters[i].ParameterType}, but got {args[i].GetType()}.");
            }
        }
    }
}