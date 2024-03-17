using apbd_3.enums;
using apbd_3.exceptions;
using apbd_3.interfaces;
using apbd_3.products;

namespace apbd_3.containers;

public class LiquidContainer : Container, IHazardNotifier
{
    private ProductType _productType;


    private LiquidContainer(Dictionary<Product, int> products, int cargoWeight, int cargoHeight, int cargoDepth, int maxLoadWeight, int tmp)
        : base(products, cargoWeight, cargoHeight, cargoDepth, maxLoadWeight)
    {
        var liquidProducts = new Dictionary<LiquidProduct, int>();
        foreach (var product in products)
        {
            LiquidProduct liquidProduct = product.Key as LiquidProduct;
            if (liquidProduct != null)
            {
                liquidProducts.Add(liquidProduct, product.Value);
            }
        }

        var productDictionary = new Dictionary<LiquidProduct, int>();
            foreach (var product in liquidProducts)
            {
                productDictionary.Add(product.Key, product.Value);
            }


            bool isDifferent = false;

            foreach (var product in liquidProducts)
            {
                var currentType = product.Key.ProductType;

                if (isDifferent)
                {
                    throw new DifferentProductsException();
                }

                isDifferent = currentType != product.Key.ProductType;
            }

            if ((LoadWeight > 0.5 * MaxLoadWeight & _productType == ProductType.Unsafe) ||
                (LoadWeight > 0.5 * MaxLoadWeight & _productType == ProductType.Safe))
            {
                PushHazardNotifier();
                throw new OverfillException();
            }
    }
    

    public override void Load(Dictionary<Product,int> products) 
    {
        base.Load(products);
        if ( (LoadWeight > 0.5 * MaxLoadWeight & _productType == ProductType.Unsafe) || 
             (LoadWeight > 0.5 * MaxLoadWeight & _productType == ProductType.Safe) ) {
            PushHazardNotifier();
            throw new OverfillException();
        }
    }

    public void PushHazardNotifier()
    {
        Console.WriteLine("ALERT - Dangerous situation has occured at container:  " + SerialNumber);
    }

}