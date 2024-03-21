using System.Text.Json.Serialization.Metadata;
using apbd_3.exceptions;
using apbd_3.interfaces;
using apbd_3.products;

namespace apbd_3.containers;

public class GasContainer : Container, IHazardNotifier

{
    private float Pressure { get; set; }
    public GasContainer(GasProduct product, float loadWeight, float cargoWeight, float cargoHeight, float cargoDepth, float maxLoadWeight, float pressure) : base(product, loadWeight, cargoWeight, cargoHeight, cargoDepth, maxLoadWeight)
    {
        Pressure = pressure;
    }

    public override void Unload()
    {
        base.Unload();
        LoadWeight = (float)(0.05 * LoadWeight);
    }

    public void PushHazardNotifier()
    {
        Console.WriteLine("ALERT - Dangerous situation has occured at container:  " + SerialNumber);
    }
}