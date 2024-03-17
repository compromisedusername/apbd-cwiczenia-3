using apbd_3.interfaces;
using apbd_3.products;

namespace apbd_3.containers;

public class CoolingContainer : Container,IHazardNotifier
{

    public CoolingContainer(Dictionary<Product, int> liquidProducts, int cargoWeight, int cargoHeight, int cargoDepth, int maxLoadWeight) : base(liquidProducts, cargoWeight, cargoHeight, cargoDepth, maxLoadWeight)
    {
    }
    public void PushHazardNotifier()
    {
        throw new NotImplementedException();
    }

}