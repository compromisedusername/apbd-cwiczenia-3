using System.Data;
using apbd_3.containers;
using apbd_3.exceptions;

namespace apbd_3.ships;

public class Ship
{
    private List<Container?> Containers { get; set; }
    private float MaxSpeed{ get; set; }
    private int MaxContainersAmount{ get; set; }
    private float MaxWeigthInTons{ get; set; }
    public string Name { get; }

    public Ship(string name, float maxSpeed, List<Container?> containers, int maxContainersAmount, float maxWeigthInTons)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        Containers = containers;
        MaxContainersAmount = maxContainersAmount;
        MaxWeigthInTons = maxWeigthInTons;
        foreach (var container in containers)
        {
            if (container != null) container.OnShip = true;
        }
    }

    public void Load(Container? container)
    {
        if (Containers.Count >= MaxContainersAmount)
        {
            throw new OverfillException();
        }

        if (container != null && container.OnShip)
        {
            throw new ContainerOnShipException();
        }

        if (container != null)
        {
            container.OnShip = true;
            Containers.Add(container);
        }
    }

    public void Load(List<Container?> containers)
    {
        if (containers.Count + Containers.Count > MaxContainersAmount)
        {
            throw new OverfillException();
        }

        foreach (var container in containers)
        {
            if (container != null && container.OnShip)
            {
                throw new ContainerOnShipException();
            }
            Containers.Add(container);
        }
    }

    public List<Container> Unload()
    {
        if (Containers == null)
        {
            throw new ContainerNotOnShipException();
        }
        foreach (var container in Containers)
        {
            if (container != null) container.OnShip = false;
        }
        var list = Containers;
        this.Containers = [];
        return list;
    }

    public void RemoveContainer(string serialNumber)
    {
        foreach (var container in Containers)
        {
            if (container != null && container.SerialNumber.Equals(serialNumber))
            {
                container.OnShip = false;
                Containers.Remove(container);
            }
        }
    } 
    public void SwapContainer(Container? container, string serialNumberContainerForRemove)
    {
        foreach (var containerLoop in Containers)
        {
            if (containerLoop != null && containerLoop.SerialNumber.Equals(serialNumberContainerForRemove))
            {
                Containers.Remove(containerLoop);
                Containers.Add(container);
            }
        }
    }public void SwapContainerBetweenShips(string containerSerialNumber, string containerSerialNumberFromAnotherShip, Ship ship)
    {

        Container? removeContainer = null;
        foreach (var containerLoop in Containers.Where(containerLoop => containerLoop.SerialNumber.Equals(containerSerialNumber)))
        {
            if (containerLoop != null && !containerLoop.OnShip)
                throw new ContainerNotOnShipException();
            ship.Containers.Add(containerLoop);
            
            removeContainer = containerLoop;
            Console.WriteLine("Container " + containerSerialNumber + " swapped between ships!");

        }
        
        if(removeContainer!=null)
            Containers.Remove(removeContainer);

        removeContainer = null;
        foreach (var containerLoop in ship.Containers)
        {
            if (containerLoop != null && containerLoop.SerialNumber.Equals(containerSerialNumberFromAnotherShip))
            {
                if (!containerLoop.OnShip)
                    throw new ContainerNotOnShipException();
                Containers.Add(containerLoop);
                removeContainer = containerLoop;
                Console.WriteLine("Container " + containerSerialNumber + " swapped between ships!");

            }
        }
        ship.Containers.Remove(removeContainer);

    }

    public void ShipInfo()
    {
        Console.WriteLine("\nShip name: " + Name +
                          "\nMax speed: "+ MaxSpeed + 
                          "\nMax containers: "+MaxContainersAmount+
                          "\nMax wiegth in tons: " +MaxWeigthInTons+
                          "\nContainers:");
        
        foreach (var container in Containers)
        {
            container?.ContainerInfo();
        }
    }
    

}

