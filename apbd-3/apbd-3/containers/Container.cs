using System.Text.Json.Serialization.Metadata;
using apbd_3.exceptions;
using apbd_3.interfaces;
using apbd_3.products;

namespace apbd_3.containers;

public abstract class Container : IContainer
{
    private static int _id = 0;
    protected Product? Product { get; set; }
    protected float CargoWeight { get; set; }
    protected float CargoHeight { get; set; }
    protected float LoadWeight { get; set; }
    protected float CargoDepth { get; set; }
    public string SerialNumber { get; }
    protected float MaxLoadWeight { get; set; }
    public bool OnShip  { get; set; }



    protected Container(Product product, float loadWeight, float cargoWeight, float cargoHeight, float cargoDepth,
        float maxLoadWeight)
    {
        if (loadWeight > maxLoadWeight)
        {
            throw new OverfillException();
        }
        Product = product;
        LoadWeight = loadWeight;
        CargoWeight = cargoWeight;
        CargoHeight = cargoHeight;
        LoadWeight = loadWeight;
        CargoDepth = cargoDepth;
        SerialNumber = "KON-" + GetType().ToString().Split(".")[2][0] + "-" + _id++;
        MaxLoadWeight = maxLoadWeight;
        OnShip = false;
    }

   


    public virtual void Unload()
    {
        Product = null;
        LoadWeight = 0;
        Console.WriteLine("Container " +SerialNumber +" unloaded." );

    }


    public virtual void Load(Product product, int weight)
    {


        if (product != null & product != Product)
        {
            throw new DifferentProductsException();
        }

        if (weight + LoadWeight > MaxLoadWeight)
        {
            throw new OverfillException();
        }
        Product = product;
        LoadWeight = weight;
        Console.WriteLine("Container " +SerialNumber +" loaded." );

    }

    public void ContainerInfo()
    {
        Console.WriteLine(
           "\nProduct: "+ Product.Name +
           "\nLoadWeight: " + LoadWeight +
           "\nCargoWeight: " + CargoWeight +
           "\nCargoHeight: " + CargoHeight +
           "\nLoadWeight: " + LoadWeight +
           "\nCargoDepth: " + CargoDepth +
           "\nSerialNumber: " + SerialNumber +
           "\nMaxLoadWeight: " + MaxLoadWeight 

    
            );
    }
}