using apbd_3.interfaces;

namespace apbd_3.containers;

public class CoolingContainer : Container,IHazardNotifier
{
    public void PushHazardNotifier()
    {
        throw new NotImplementedException();
    }

    public CoolingContainer(int cargoWeight, int cargoHeight, int loadWeight, int cargoDepth, int maxLoadWeight) : base(cargoWeight, cargoHeight, loadWeight, cargoDepth, maxLoadWeight)
    {
        
    }
}