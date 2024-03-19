using apbd_3.containers;

namespace apbd_3.ships;

public class Ship
{
    private List<Container> Containers { get; set; }
    private float Speed{ get; set; }
    private int MaxContainersAmount{ get; set; }
    private float MaxWeigthInTons{ get; set; }

    public Ship(float speed, List<Container> containers, int maxContainersAmount, float maxWeigthInTons)
    {
        Speed = speed;
        Containers = containers;
        MaxContainersAmount = maxContainersAmount;
        MaxWeigthInTons = maxWeigthInTons;
    }

    public void Load(Container container)
    {
        
    }

    public void Load(List<Container> containers)
    {
        
    }

    
    

}