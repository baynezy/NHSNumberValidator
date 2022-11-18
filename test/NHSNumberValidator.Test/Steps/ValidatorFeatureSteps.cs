using Xunit;

namespace NHSNumberValidator.Test.Steps;

[Binding]
public class ValidatorFeatureSteps
{
    private static readonly Random Random = new();
    private readonly List<string?> _validNumbers = new()
    {
        "4841981608",
        "4130083619",
        "7156652133",
        "7117334363",
        "4692588128",
        "2779085797",
        "1688935126"
    };
    
    private readonly List<string?> _invalidNumbers = new()
    {
        "4841981607",
        "4130083618",
        "7156652132",
        "7117334362",
        "4692588127",
        "2779085796",
        "1688935125"
    };

    private string? _generated;

    [Given(@"A single valid NHS Number")]
    public void GivenASingleValidNhsNumber()
    {
        var shuffled = Shuffle(_validNumbers);
        _generated = shuffled.First();
    }

    [Then(@"NHS Number should be valid")]
    public void ThenNhsNumberShouldBeValid() => Assert.True(Validator.Validate(_generated));

    [Given(@"A single invalid NHS Number")]
    public void GivenASingleInvalidNhsNumber()
    {
        var shuffled = Shuffle(_invalidNumbers);
        _generated = shuffled.First();
    }

    [Then(@"NHS Number should be invalid")]
    public void ThenNhsNumberShouldBeInvalid() => Assert.False(Validator.Validate(_generated));

    private static IEnumerable<string?> Shuffle(IEnumerable<string?> numbers) => numbers.OrderBy(_ => Random.Next());

    [Given(@"A single invalid NHS Number which is too short")]
    public void GivenASingleInvalidNhsNumberWhichIsTooShort() => _generated = "1234";

    [Given(@"A single invalid NHS Number which is null")]
    public void GivenASingleInvalidNhsNumberWhichIsNull() => _generated = null;

    [Then(@"The validator should not accept the input")]
    public void ThenTheValidatorShouldNotAcceptTheInput()
    {
        try
        {
            Validator.Validate(_generated);
            Assert.True(false, "This should never be reached, as the above should always fail.");
        }
        catch (ArgumentNullException)
        {
            Assert.True(true);
        }
    }

    [Given(@"An NHS Number that has a remainder of 0")]
    public void GivenAnNhsNumberThatHasARemainderOfZero() => _generated = "7572469280";
}