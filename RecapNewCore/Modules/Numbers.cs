namespace RecapNewCore.Modules;

public class Numbers
{
   public int Id { get; set; }
 
    public int FirstNumber { get; set; }
    
   public  int SecondNumber { get; set; }
   
  public   int Answer { get; set; }
  
  public DateTimeOffset CreatedAt {get; set;}
  
}

public class NumbersResponse
{
 public int Id { get; set; }
 
 public int FirstNumber { get; set; }
    
 public  int SecondNumber { get; set; }
 public int Answer { get; set; } 
 
 public DateTimeOffset CreatedAt {get; set;}
}

public class NumbersRequest {
 public int FirstNumber { get; set; }
 public int SecondNumber { get; set; }
}