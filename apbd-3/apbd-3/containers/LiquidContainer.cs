using apbd_3.enums;
using apbd_3.exceptions;
using apbd_3.interfaces;
using apbd_3.products;

namespace apbd_3.containers;

public class LiquidContainer : Container, IHazardNotifier
{
   


    public LiquidContainer(LiquidProduct product, float loadWeight, float cargoWeight, float cargoHeight, float cargoDepth, float maxLoadWeight) : base(product, loadWeight, cargoWeight, cargoHeight, cargoDepth, maxLoadWeight)
    {
        if (((product.ProductType == ProductType.Unsafe)  & (loadWeight > 0.5 * maxLoadWeight)) |
             ((product.ProductType == ProductType.Safe)  & (loadWeight > 0.9 * maxLoadWeight)))
        {
                PushHazardNotifier();
        }

    }  

    public void PushHazardNotifier()
    {
        Console.WriteLine("ALERT - Dangerous situation has occured at container:  " + SerialNumber);
    }

}