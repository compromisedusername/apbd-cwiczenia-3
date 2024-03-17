using apbd_3.enums;

namespace apbd_3.products;

public abstract class Product
{
    private string _name;
    private float _temperature;

    public Product( string name, float temperature)
    {
        this._name = name;
        this._temperature = temperature;
    }
}