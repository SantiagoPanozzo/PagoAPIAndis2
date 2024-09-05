public class Pago
{
    private static int nextId = 0;
    private int id;
    private int rut;
    private int numeroCuenta;
    private int monto;
    
    public Pago(int rut, int numeroCuenta, int monto)
    {
        this.id = nextId++;
        this.rut = rut;
        this.numeroCuenta = numeroCuenta;
        this.monto = monto;
    }
    
    public int Rut
    {
        get => rut;
        set => rut = value;
    }
    
    public int NumeroCuenta
    {
        get => numeroCuenta;
        set => numeroCuenta = value;
    }
    
    public int Monto
    {
        get => monto;
        set => monto = value;
    }
    
    public int Id
    {
        get => id;
    }
}