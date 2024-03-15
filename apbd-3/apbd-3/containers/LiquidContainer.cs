namespace apbd_3.containers;

public class LiquidContainer : Container{
    public LiquidContainer(int cargoWeight, int cargoHeight, int loadWeight, int cargoDepth, int maxLoadWeight) : base(cargoWeight, cargoHeight, loadWeight, cargoDepth, maxLoadWeight)
    {
        
    }

    public override void Load(int cargoWeight) 
    {
        base.Load(cargoWeight);
        throw new NotImplementedException();
    }
}