using apbd_3.products;

namespace apbd_3.interfaces;

public interface IContainer
{
    void Unload();
    void Load( Product product, int weight);

}