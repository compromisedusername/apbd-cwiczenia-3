// See https://aka.ms/new-console-template for more information

using apbd_3.containers;
using apbd_3.enums;
using apbd_3.exceptions;
using apbd_3.products;
using apbd_3.ships;

SolidProduct banana = new SolidProduct("Banana", -13);
SolidProduct apple = new SolidProduct("apple", -256);
LiquidProduct dihydrogenMonoxide = new LiquidProduct("dihydrogen monoxide", -100, ProductType.Safe);
LiquidProduct mountainDew = new LiquidProduct("mountain dew", 56, ProductType.Unsafe);
GasProduct metan = new GasProduct("metan", -12000);
GasProduct air = new GasProduct("air", -1000);

LiquidContainer? containerDihyrogenMonoxide = new LiquidContainer(dihydrogenMonoxide,100,1000,2000,3000,300);
GasContainer containerMetan = new GasContainer(metan,100,1000,2000,3000,300,200);
CoolingContainer? containerBanana = new CoolingContainer(banana,100,1000,2000,3000,300,100,ProductType.Unsafe);

LiquidContainer? containerMountainDew = new LiquidContainer(mountainDew,100,1000,2000,3000,300);
GasContainer containerAir = new GasContainer(air,100,1000,2000,3000,300,200);
CoolingContainer? containerApple = new CoolingContainer(apple,100,1000,2000,3000,300,100,ProductType.Unsafe);

List<Container?> containersForBlackPearl = new List<Container?>() {   containerMetan,   containerBanana,  containerDihyrogenMonoxide };
List<Container?> containersForSilentMary = new List<Container?>() {   containerAir,   containerApple,  containerMountainDew };
Ship blackPearl = new Ship("Black Pearl",100,containersForBlackPearl,20,50);
Ship silentMary  = new Ship("Silent Mary",100,containersForSilentMary,20,50);

blackPearl.ShipInfo();
silentMary.ShipInfo();

blackPearl.SwapContainerBetweenShips(containerBanana.SerialNumber, containerMountainDew.SerialNumber, silentMary);

blackPearl.ShipInfo();
silentMary.ShipInfo();

List<Container> blackPearlContainers = blackPearl.Unload();
List<Container> silentMaryContainers = silentMary.Unload();

blackPearl.ShipInfo();
silentMary.ShipInfo();


foreach (var container in blackPearlContainers)
{
    container.Unload();
}

foreach (var container in silentMaryContainers)
{
    container.Unload();
}


blackPearl.Load(blackPearlContainers);    
silentMary.Load(silentMaryContainers);


