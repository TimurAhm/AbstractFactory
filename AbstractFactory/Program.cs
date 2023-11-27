internal class Program
{
    private static void Main(string[] args)
    {
        Hero elf = new Hero(new ElfFactory());
        Hero warrior = new Hero(new WarriorFactory());

        elf.Hit();
        elf.Run();
        Console.WriteLine(new String('-', 29));
        warrior.Hit();
        warrior.Run();

        Console.ReadKey();
    }
}

//abstract class AbstractFactory
//{
//    public abstract AbstractProductA CreateProductA();
//    public abstract AbstractProductB CreateProductB();
//}

//class ConcreteFactory1 : AbstractFactory
//{
//    public override AbstractProductA CreateProductA()
//    {
//        return new ProductA1();
//    }

//    public override AbstractProductB CreateProductB()
//    {
//        return new ProductB1();
//    }
//}

//class ConcreteFactory2 : AbstractFactory
//{
//    public override AbstractProductA CreateProductA()
//    {
//        return new ProductA2();
//    }

//    public override AbstractProductB CreateProductB()
//    {
//        return new ProductB2();
//    }
//}

//abstract class AbstractProductA
//{ }

//abstract class AbstractProductB
//{ }

//class ProductA1 : AbstractProductA
//{ }

//class ProductB1 : AbstractProductB
//{ }

//class ProductA2 : AbstractProductA
//{ }

//class ProductB2 : AbstractProductB
//{ }

//class Client
//{
//    private AbstractProductA abstractProductA;
//    private AbstractProductB abstractProductB;

//    public Client(AbstractFactory factory)
//    {
//        abstractProductA = factory.CreateProductA();
//        abstractProductB = factory.CreateProductB();
//    }

//    public void Run()
//    { }
//}


abstract class HeroFactory//AbstractFactory
{
    public abstract Weapon CreateWeapon();//AbstractProductA CreateProductA();
    public abstract Movement CreateMovement();//AbstractProductB CreateProductB();
}

class ElfFactory : HeroFactory//ConcreteFactory1 : AbstractFactory
{
    public override Weapon CreateWeapon()//AbstractProductA CreateProductA()    
    {
        return new Arbalet();//return new ProductA1();
    }

    public override Movement CreateMovement()//AbstractProductB CreateProductB()
    {
        return new FlyMovement();//return new ProductB1();
    }
}

class WarriorFactory : HeroFactory
{
    public override Weapon CreateWeapon()//AbstractProductA CreateProductA()
    {
        return new Sword();//return new ProductA2();
    }

    public override Movement CreateMovement()//AbstractProductB CreateProductB()
    {
        return new RunMovement();//return new ProductB2();
    }
}

abstract class Weapon//AbstractProductA
{
    public abstract void Hit();
}

abstract class Movement//AbstractProductB
{
    public abstract void Move(); 
}

class Arbalet : Weapon//ProductA1 : AbstractProductA
{
    public override void Hit()
    {
        Console.WriteLine("Выстрелы с арбалета");
    }
}

class Sword : Weapon//ProductA2 : AbstractProductA
{
    public override void Hit()
    {
        Console.WriteLine("Бьем мечом");
    }
}

class FlyMovement : Movement//ProductB1 : AbstractProductB
{
    public override void Move()
    {
        Console.WriteLine("Передвигаемся со скоростью полета");
    }
}

class RunMovement : Movement//ProductB2 : AbstractProductB
{
    public override void Move()
    {
        Console.WriteLine("Передвигаемся со скоростью бега");
    }
}

class Hero //Client
{
    private Weapon weapon;//AbstractProductA abstractProductA;
    private Movement movement;//AbstractProductB abstractProductB;

    public Hero(HeroFactory heroFactory)//Client(AbstractFactory factory)
    {
        weapon = heroFactory.CreateWeapon();//abstractProductA = factory.CreateProductA();
        movement = heroFactory.CreateMovement();//abstractProductB = factory.CreateProductB();
    }

    public void Run()
    {
        movement.Move();
    }

    public void Hit()
    {
        weapon.Hit();
    }
}