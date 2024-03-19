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
    protected string SerialNumber { get; set; }
    protected float MaxLoadWeight { get; set; }



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
        SerialNumber = "KON-" + GetContainerType() + "-" + _id++;
        MaxLoadWeight = maxLoadWeight;
    }

    private char GetContainerType()
    {
        return GetType().ToString().ToUpper()[0];

    }


    public virtual void Unload()
    {
        Product = null;
        LoadWeight = 0;
        Console.WriteLine("Container unloaded");
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
    }
}