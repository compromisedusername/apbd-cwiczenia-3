using apbd_3.interfaces;

namespace apbd_3.containers;

public class GasContainer : Container, IHazardNotifier
{
    public GasContainer(int cargoWeight, int cargoHeight, int loadWeight, int cargoDepth, int maxLoadWeight) : base(cargoWeight, cargoHeight, loadWeight, cargoDepth, maxLoadWeight)
    {
        
    }

    public void PushHazardNotifier()
    {
        throw new NotImplementedException();
    }
}