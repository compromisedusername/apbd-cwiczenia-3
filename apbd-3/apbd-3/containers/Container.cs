using apbd_3.exceptions;
using apbd_3.interfaces;

namespace apbd_3.containers;

public abstract class Container : IContainer
{
    private static int _id = 0;
    
    protected int CargoWeight { get;  set; }
    protected int CargoHeight { get;  set; }
    protected int LoadWeight { get;  set; }
    protected int CargoDepth { get;  set; }
    protected string SerialNumber { get;  set; }
    protected int MaxLoadWeight { get;  set; }
    


    protected  Container(int cargoWeight, int cargoHeight, int loadWeight, int cargoDepth, int maxLoadWeight)
    {
        CargoWeight = cargoWeight;
        CargoHeight = cargoHeight;
        LoadWeight = loadWeight;
        CargoDepth = cargoDepth;
        SerialNumber = "KON-"+GetContainerType()+"-"+_id++;
        MaxLoadWeight = maxLoadWeight;
    }

    private char GetContainerType()
    {
        return GetType().ToString().ToUpper()[0];
        
    }


    public void Unload()
    {
        LoadWeight = 0;
        Console.WriteLine("Ship is unloaded!");
   
    }

    public virtual void Load(int loadWeight)
    {
        if (LoadWeight > CargoWeight)
        {
            throw new OverfillException();
        }

        LoadWeight = loadWeight;
    }

}