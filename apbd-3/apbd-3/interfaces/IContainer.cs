using apbd_3.products;

namespace apbd_3.interfaces;

public interface IContainer
{
    Dictionary<Product,int> Unload(Dictionary<Product,int> products);
    Dictionary<Product,int> Unload();
    public void Load(Dictionary<Product, int> products);

}