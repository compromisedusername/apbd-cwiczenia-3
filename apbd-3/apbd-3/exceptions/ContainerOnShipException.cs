using System.ComponentModel;

namespace apbd_3.exceptions;

public class ContainerOnShipException : Exception
{
    public override string Message => "Container is already loaded!";

}