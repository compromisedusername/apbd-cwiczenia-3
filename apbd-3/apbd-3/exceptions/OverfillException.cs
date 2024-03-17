namespace apbd_3.exceptions;

public class OverfillException : Exception
{
   public override string Message => "Mass of load is bigger than the capable container load!";
}