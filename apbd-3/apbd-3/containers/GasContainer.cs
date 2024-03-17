using System.Text.Json.Serialization.Metadata;
using apbd_3.exceptions;
using apbd_3.interfaces;
using apbd_3.products;

namespace apbd_3.containers;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(Dictionary<Product, int> liquidProducts, int cargoWeight, int cargoHeight, int cargoDepth, int maxLoadWeight) : base(liquidProducts, cargoWeight, cargoHeight, cargoDepth, maxLoadWeight)
    {
        
    }

    public void PushHazardNotifier()
    {
        Console.WriteLine("ALERT - Dangerous situation has occured at container:  " + SerialNumber);
    }

    public override Dictionary<Product, int> Unload()
    {
        var productsLoadWeight = 0;
        LoadWeight = (int) 0.05 * MaxLoadWeight;
        foreach (var var in products)
        {
            if
        }
    }

    public override Dictionary<Product, int> Unload(Dictionary<Product, int> products)
    {
        
        Dictionary<Product,int> product = base.Unload();
        if (product.Values.Sum() < 0.05 * MaxLoadWeight)
        {
            throw new EmptinessExceotion();
        }
        return product;
    }
}