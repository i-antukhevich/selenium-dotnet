using AutomationHost.Actors.Abilities;

namespace AutomationHost.Actors;

public class ActorBuilder(string name)
{
    private readonly IList<IAbility> _abilities = new List<IAbility>();
    private ActorInformation _information;

    public ActorBuilder WithInformation(ActorInformation information)
    {
        _information = information;
        return this;
    }

    public ActorBuilder WithAbilityTo(IAbility ability)
    {
        _abilities.Add(ability);
        return this;
    }

    public Actor Build()
    {
        return new Actor(_information, _abilities);
    }
}