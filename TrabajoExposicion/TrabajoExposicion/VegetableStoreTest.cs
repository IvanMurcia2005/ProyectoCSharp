using System;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.InteropServices;

// Clase principal
public class VegetableStoreTest
{
    public static void Main(string[] args)
    {
        // Clases, Superclase y Subclase
        Vegetable carrot = new Vegetable
        {
            Name = "Carrot",
            Size = "Medium",
            Price = 0.50m,
            FreshnessLevel = "High"
        };
        carrot.DisplayVegetableInfo();

        // Interfaces
        SeasonalDiscount discount = new SeasonalDiscount();
        decimal discountedPrice = discount.ApplyDiscount(carrot.Price);
        Console.WriteLine($"Discounted Price: {discountedPrice}");

        // Clases de Atributos
        Produce item = new Produce { Name = "Broccoli", Size = "Large", NewPrice = 1.20m };
        item.DisplayInfo();

        // Encapsulamiento
        item.Price = 1.00m;
        Console.WriteLine($"Updated Price: {item.Price}");

        // Polimorfismo
        Produce lettuce = new Lettuce();
        lettuce.DisplayInfo();

        // Principios SOLID
        // S - Single Responsibility Principle
        ProduceRepository repository = new ProduceRepository();
        repository.Save(item);

        // O - Open/Closed Principle
        Discount holidayDiscount = new HolidayDiscount();
        decimal holidayDiscountedPrice = holidayDiscount.ApplyDiscount(item.Price);
        Console.WriteLine($"Holiday Discounted Price: {holidayDiscountedPrice}");

        // L - Liskov Substitution Principle
        Produce discountedProduce = new DiscountedProduce { Price = 2.00m };
        Console.WriteLine($"Discounted Produce Price: {discountedProduce.Price}");

        // I - Interface Segregation Principle
        Potato potato = new Potato();
        potato.DisplayInfo();
        Console.WriteLine($"Potato Price: {potato.CalculatePrice()}");

        // D - Dependency Inversion Principle
        IPaymentMethod paymentMethod = new CashPayment();
        Checkout checkout = new Checkout(paymentMethod);
        checkout.CompletePurchase(item.Price);

        // Abstracción
        Produce tomato = new Tomato { Name = "Cherry Tomato", Price = 2.50m };
        tomato.DisplayInfo();

        // Herencia
        StoreManager manager = new StoreManager { Name = "Alice", Position = "Manager" };
        manager.ManageStore();

        // Métodos y Funciones
        Inventory inventory = new Inventory();
        int stock = inventory.AddStock(30, 20);
        inventory.DisplayStock(stock);

        // Async y Await
        DisplayStockAsync().Wait();
    }

    // Async y Await
    public static async Task DisplayStockAsync()
    {
        Inventory inventory = new Inventory();
        int stock = await inventory.CheckStockAsync();
        Console.WriteLine("Async Stock: " + stock);
    }
}

// Clases, Superclase y Subclase
public class Produce
{
    public string Name { get; set; }
    public string Size { get; set; }
    public decimal Price { get; set; }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Size: {Size}, Price: {Price}");
    }
}

public class Vegetable : Produce
{
    public string FreshnessLevel { get; set; }

    public void DisplayVegetableInfo()
    {
        Console.WriteLine($"Name: {Name}, Size: {Size}, Price: {Price}, Freshness Level: {FreshnessLevel}");
    }
}

// Interfaces
public interface IDiscount
{
    decimal ApplyDiscount(decimal price);
}

public class SeasonalDiscount : IDiscount
{
    public decimal ApplyDiscount(decimal price)
    {
        return price * 0.9m; // 10% discount
    }
}

// Clases de Atributos
[Serializable]
public class Produce
{
    [DefaultValue("Unknown")]
    [Category("General Info")]
    public string Name { get; set; }

    [Browsable(false)]
    public string Size { get; set; }

    [Obsolete("Use NewPrice instead", true)]
    public decimal OldPrice { get; set; }

    [ComVisible(true)]
    public decimal NewPrice { get; set; }
}

// Encapsulamiento
public class Produce
{
    private decimal _price;

    public decimal Price
    {
        get { return _price; }
        set
        {
            if (value >= 0)
                _price = value;
        }
    }
}

// Polimorfismo
public class Lettuce : Produce
{
    public override void DisplayInfo()
    {
        Console.WriteLine("Displaying lettuce info...");
    }
}

// Principios SOLID
// S - Single Responsibility Principle
public class ProduceRepository
{
    public void Save(Produce item)
    {
        // Save item to the database
    }
}

// O - Open/Closed Principle
public abstract class Discount
{
    public abstract decimal ApplyDiscount(decimal price);
}

public class HolidayDiscount : Discount
{
    public override decimal ApplyDiscount(decimal price)
    {
        return price * 0.8m; // 20% discount
    }
}

// L - Liskov Substitution Principle
public class DiscountedProduce : Produce
{
    public override decimal Price
    {
        get { return base.Price * 0.9m; } // 10% discount
    }
}

// I - Interface Segregation Principle
public interface IProduce
{
    void DisplayInfo();
}

public interface IPriceCalculable
{
    decimal CalculatePrice();
}

public class Potato : IProduce, IPriceCalculable
{
    public void DisplayInfo()
    {
        Console.WriteLine("Displaying potato info...");
    }

    public decimal CalculatePrice()
    {
        return 0.75m;
    }
}

// D - Dependency Inversion Principle
public interface IPaymentMethod
{
    void ProcessPayment(decimal amount);
}

public class CashPayment : IPaymentMethod
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing cash payment of {amount}");
    }
}

public class Checkout
{
    private readonly IPaymentMethod _paymentMethod;

    public Checkout(IPaymentMethod paymentMethod)
    {
        _paymentMethod = paymentMethod;
    }

    public void CompletePurchase(decimal amount)
    {
        _paymentMethod.ProcessPayment(amount);
    }
}

// Abstracción
public abstract class Produce
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public abstract void DisplayInfo();
}

public class Tomato : Produce
{
    public override void DisplayInfo()
    {
        Console.WriteLine($"Tomato: {Name}, Price: {Price}");
    }
}

// Herencia
public class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }
}

public class StoreManager : Employee
{
    public void ManageStore()
    {
        Console.WriteLine("Managing the store...");
    }
}

// Métodos y Funciones
public class Inventory
{
    public int AddStock(int currentStock, int newStock)
    {
        return currentStock + newStock;
    }

    public void DisplayStock(int stock)
    {
        Console.WriteLine($"Current stock: {stock}");
    }

    public async Task<int> CheckStockAsync()
    {
        await Task.Delay(2000); // Simula una operación asincrónica
        return 100;
    }
}
