using System.Text.Json.Serialization.Metadata;
using apbd_3.exceptions;
using apbd_3.interfaces;
using apbd_3.products;

namespace apbd_3.containers;

public abstract class Container : IContainer
{
    private Dictionary<Product, int> _products = new();
    private static int _id = 0;
    
    protected int CargoWeight { get;  set; }
    protected int CargoHeight { get;  set; }
    protected int LoadWeight { get;  set; }
    protected int CargoDepth { get;  set; }
    protected string SerialNumber { get;  set; }
    protected int MaxLoadWeight { get;  set; }
    


    protected  Container( Dictionary<Product,int> liquidProducts, int cargoWeight, int cargoHeight, int cargoDepth, int maxLoadWeight)
    {
        var loadWeight = 0;
        foreach ( var product in liquidProducts)
        {
            loadWeight += product.Value;
            if (loadWeight > maxLoadWeight)
            {
                throw new OverfillException();
            }
        }
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


    public virtual Dictionary<Product,int> Unload()
    {
        var products = _products;
        _products = new Dictionary<Product, int>();
        Console.WriteLine("Ship is unloaded");
        return products;
    }
    public virtual Dictionary<Product, int> Unload(Dictionary<Product, int> products)
    {
        var tmpproducts = _products;
        var unloadedWeight = 0;
        foreach (var product in products)
        {
            tmpproducts[product.Key] -= product.Value;
            if (tmpproducts[product.Key] < 0)
            {
                throw new ProductEmptinessException();
            }
            unloadedWeight += product.Value;
            if (unloadedWeight > LoadWeight)
            {
                throw new EmptinessExceotion();
            }
            
        }
        LoadWeight -= unloadedWeight;
        if(LoadWeight==0)
            Console.WriteLine("Ship is unloaded!");
        _products = tmpproducts;
        return products;
    }

    public virtual void Load(Dictionary<Product, int> products)

    {
        var loadWeight = 0;
        foreach (var product in products)
        {
            loadWeight += product.Value;
            if (loadWeight > CargoWeight)
            {
                throw new OverfillException();
            }

            if (_products.ContainsKey(product.Key))
            {
                _products[product.Key] += product.Value;
            }

            else
            {
                products.Add(product.Key, product.Value);
            }
        }
        LoadWeight = loadWeight;
    }

}