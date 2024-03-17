namespace apbd_3.exceptions;

public class ProductEmptinessException : Exception
{
    public override string Message => "Mass of unloaded product is smaller than the actual load of product!";
}