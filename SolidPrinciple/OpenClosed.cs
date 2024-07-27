namespace SolidPrinciple.OpenClosed;

public enum Color
{
    Red, Green, Blue,
}
public enum Size
{
    Small, Medium, Large
}
public class Product
{
    public string _name;
    public Color _color;
    public Size _size;
    public Product(string name, Color color, Size size)
    {
        if(name == null)
        {
            throw new ArgumentNullException(nameof(name));
        }

        _name = name;
        _color = color;
        _size = size;
    }
}

public  class ProductFilter
{
    public  IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
    {
        foreach(Product product in products)
        {
            if(product._size == size)
            {
                yield return product;
            }
        }
    }
}
//Enhancement of ProductFilter
public  class BetterProductFilter : IFilter<Product>
{
    public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> spec)
    {
        foreach(var item in items)
        {
            if(spec.IsSatisfiedBy(item))
            {
                yield return item;
            }
        }
    }
}

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T item); 
}

public interface IFilter<T>
{
    IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
}

public class ColorSpecification : ISpecification<Product>
{
    private Color _color;

    public ColorSpecification(Color color)
    {
        this._color = color;
    }   

    public bool IsSatisfiedBy(Product product)
    {
        return product._color == _color;
    }
}


public class SizeSpecification : ISpecification<Product>
{
    private Size _size;

    public SizeSpecification(Size size)
    {
        this._size = size;
    }   

    public bool IsSatisfiedBy(Product product)
    {
        return product._size == _size;
    }
}

public class SizeAndColorSpecification : ISpecification<Product>
{
    private Size _size;
    private Color _color;

    public SizeAndColorSpecification(Size size, Color color)
    {
        this._size = size;
        this._color = color;    
    }

    public bool IsSatisfiedBy(Product p)
    {
        return p._size == _size && p._color == _color;
    }
}


public class AndSpecification<T> : ISpecification<T>
{
    private ISpecification<T> _first, _second;
    public AndSpecification(ISpecification<T> first, ISpecification<T> second)
    {
        _first = first ?? throw new ArgumentNullException(nameof(first));
        _second = second ?? throw new ArgumentNullException(nameof(second));
    }

    public bool IsSatisfiedBy(T item)
    {
        return _first.IsSatisfiedBy(item) && _second.IsSatisfiedBy(item);
    }
}