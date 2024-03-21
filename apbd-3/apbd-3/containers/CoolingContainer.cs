using apbd_3.enums;
using apbd_3.exceptions;
using apbd_3.interfaces;
using apbd_3.products;

namespace apbd_3.containers;

public class CoolingContainer:  Container

{
    protected Type _productType;
    protected float Temperature { get; set; }

    public CoolingContainer(Product product, float loadWeight, float cargoWeight, float cargoHeight, float cargoDepth, float maxLoadWeight, float temperature, ProductType productType) : base(product, loadWeight, cargoWeight, cargoHeight, cargoDepth, maxLoadWeight)
    {
        
        _productType = product.GetType();
        if (product.Temperature > temperature)
        {
            throw new TemperatureException();
        }
        Temperature = temperature;
        

    }

    public override void Load(Product product, int weight)
    {
        base.Load(product, weight);
        if (product.GetType() != Product?.GetType())
        {
            throw new DifferentProductsException();
        }
    }

   
}