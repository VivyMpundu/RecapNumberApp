using RecapNewCore.Data;
using RecapNewCore.Modules;

namespace RecapNewCore.Service;

public class NumberService
{
    private readonly AppDbContext _context;

    public NumberService(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<NumbersResponse> AddNumbers(NumbersRequest request)
{
    var answer = request.FirstNumber + request.SecondNumber;

    var number = new Numbers
    {
        FirstNumber = request.FirstNumber,
        SecondNumber = request.SecondNumber,
        Answer = answer,
        CreatedAt =  DateTime.UtcNow
       
    };

    await _context.Numbers.AddAsync(number);
    await _context.SaveChangesAsync();

    return new NumbersResponse()
    {
        Id = number.Id,
        FirstNumber = number.FirstNumber,
        SecondNumber = number.SecondNumber,
        Answer = number.Answer,
        CreatedAt = number.CreatedAt
    };
}

    public NumbersResponse ViewAnswerById(int Id )
    {
        var ViewedAnswer = _context.Numbers.Find(Id);

        if (ViewedAnswer == null)
        {
            return null;
        }

        return new NumbersResponse
        {
            Answer = ViewedAnswer.Answer
        };
        
    }

    public async Task<bool> DeleteNumber(int id)
    {
        var number = await _context.Numbers.FindAsync(id);

        if (number == null)
        {
            return false;
        }

        _context.Numbers.Remove(number);

        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<NumbersResponse> EditNumber(int id, NumbersRequest request)
    {
        var number = await _context.Numbers.FindAsync(id);
        number.FirstNumber = request.FirstNumber;
        number.SecondNumber = request.SecondNumber;
        number.Answer = request.FirstNumber + request.SecondNumber;
        
        _context.Update(number);
       await _context.SaveChangesAsync();
        return  new NumbersResponse
        {
            Id = number.Id,
            FirstNumber = number.FirstNumber,
            SecondNumber = number.SecondNumber,
            Answer = number.Answer,
            CreatedAt = number.CreatedAt
        };

    }

    public async Task<List<NumbersResponse>>ViewAllNumbers()
    {
       var numbers= _context.Numbers.ToList();
       Console.WriteLine($"Records found: {numbers.Count}");
        return numbers.Select(numbers => new NumbersResponse
        {
            Id = numbers.Id, 
            FirstNumber = numbers.FirstNumber,
            SecondNumber = numbers.SecondNumber,
            Answer = numbers.Answer,
            CreatedAt = numbers.CreatedAt
        } ).ToList(); 
    }
}
