using AutomationHost.Actors.Abilities;
using AutomationHost.Utils.Validators;
using Newtonsoft.Json;

namespace AutomationHost.Actors;

public class Actor (ActorInformation information, IList<IAbility> abilities) : IDisposable
{
    public ActorInformation Information { get; set; } = information;
    
    public TAbility Use<TAbility>()
    {
        return abilities.OfType<TAbility>().FirstOrDefault()
               ?? throw new InvalidOperationException($"Actor {Information.Username} does not have the ability to {typeof(TAbility).Name}");
    }

    public void Add<TAbility>(TAbility ability) where TAbility : IAbility
    {
        abilities.Add(ability);
    }

    public void Performs(Delegate command, params object[] args)
    {
        var arguments = new object[] { this }.Concat(args).ToArray();
        Validate.CommandArgs(command, arguments);
        command.DynamicInvoke(arguments);
    }

    public object? AsksFor(Delegate command, params object[] args)
    {
        var arguments = new object[] { this }.Concat(args).ToArray();
        Validate.CommandArgs(command, arguments);
        return command.DynamicInvoke(arguments) ?? null;
    }

    public T AsksFor<T>(Delegate command, params object[] args)
    {
        var value = AsksFor(command, args);

        try
        {
            return value is not null
                ? (T)value
                : throw new NullReferenceException($"Returned object is NULL and cannot be casted to type {typeof(T)}");
        }
        catch (InvalidCastException)
        {
            throw new InvalidCastException($"It is impossible to cast object {JsonConvert.SerializeObject(value)} to type {typeof(T)}");
        }
    }

    public void Dispose()
    {
        foreach (var ability in abilities)
        {
            ability.Dispose();
        }
    }
}