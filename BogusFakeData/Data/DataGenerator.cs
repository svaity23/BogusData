
using Bogus;

namespace BogusFakeData.Data;

public class DataGenerator
{
    Faker<PersonModel> personModelFake;

    public DataGenerator() { 
        Randomizer.Seed = new Random(Seed: 123);
        personModelFake = new Faker<PersonModel>()
            .RuleFor(u => u.Id, f => f.Random.Int(min: 1, max: 10000))
            .RuleFor(f => f.FirstName, f => f.Name.FirstName())
            .RuleFor(f => f.LastName, f => f.Name.LastName())
            .RuleFor(f => f.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(f => f.Phone, f => f.Phone.PhoneNumber())
            .RuleFor(f => f.StreetAddress, f => f.Address.StreetAddress())
            .RuleFor(f => f.City, f => f.Address.City())
            .RuleFor(f => f.State, f => f.Address.StateAbbr())
            .RuleFor(f => f.ZipCode, f => f.Address.ZipCode())
            .RuleFor(f => f.Rating, f => f.PickRandom<CreditRating>());
    }

    public PersonModel GeneratePerson()
    {
        return personModelFake.Generate();
    }

    public IEnumerable<PersonModel> GeneratePeople()
    {
        return personModelFake.GenerateForever();
    }
}
