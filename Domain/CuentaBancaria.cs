using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    public string Numero { get; }
    public decimal Saldo { get; protected set; }
    public Estado Estado { get; protected set; } = Estado.Activa;
    public string[] Titulares { get; }

    protected CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        if (string.IsNullOrWhiteSpace(numero))
            throw new NumeroCuentaInvalidoException();

        if (saldo < 0)
            throw new SaldoInicialInvalidoException();

        if (titulares == null || titulares.Length == 0)
            throw new TitularesInvalidosException();
        Numero = numero;
        Saldo = saldo;
        Titulares = titulares;
    }

    public virtual void Depositar(decimal monto)
    {
        ValidarOperacion(monto);
        Saldo += monto;
    }

    public abstract void Retirar(decimal monto);

    protected void ValidarOperacion(decimal monto)
    {
        if (Estado != Estado.Activa)
            throw new CuentaNoActivaException(Estado);

        if (monto <= 0)
            throw new MontoNoValidoException();
    }

    public abstract string ObtenerResumen();
}
