namespace NHS.NumberValidator;

public class Validator
{
    private const int NhsNumberLength = 10;
    private const int RemainderConstant = 11;
    private static readonly int[] Weightings = {10,9,8,7,6,5,4,3,2};

    public static bool Validate(string? number)
    {
        try
        {
            _ = number ?? throw new ArgumentNullException(nameof(number));
            var characters = ExplodeNumber(number);
            var checkSum = ExtractChecksum(characters);
            var weightedTotal = CalculateWeightedTotal(characters);
            var remainder = CalculateRemainder(weightedTotal);
            return RemainderAndChecksumMatch(remainder, checkSum);
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }
    
    private static List<int> ExplodeNumber(string number)
    {
        var characters = number.Select(x => new string(x, 1)).ToList();
        return characters.Select(int.Parse).ToList();
    }
    
    private static int ExtractChecksum(IReadOnlyList<int> characters)
    {
        if (characters.Count != NhsNumberLength) throw new IndexOutOfRangeException($"NHS Number had {characters.Count} characters instead of {NhsNumberLength}.");
        return characters[NhsNumberLength - 1];
    }
    
    private static int CalculateWeightedTotal(IReadOnlyCollection<int> characters)
    {
        
        var position = 0;
        var lastCharacter = characters.Count;

        return characters.TakeWhile(_ => position != lastCharacter - 1).Sum(character => character * Weightings[position++]);
    }
    
    private static int CalculateRemainder(int weightedTotal)
    {
        return weightedTotal % RemainderConstant;
    }
    
    private static bool RemainderAndChecksumMatch(int remainder, int checkSum)
    {
        var actual = (remainder == 0) ? 0 : RemainderConstant - remainder;
        return actual == checkSum;
    }
}