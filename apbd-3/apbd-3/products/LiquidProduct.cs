using apbd_3.enums;

namespace apbd_3.products;

public class LiquidProduct : Product
{
    private ProductType productType;

    public ProductType ProductType => productType;

    public LiquidProduct(string name, float temperature, ProductType productType) : base(name, temperature)
    {
        this.productType = productType;
    }
}