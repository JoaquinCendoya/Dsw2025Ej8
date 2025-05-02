using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain
{
    public class CajaAhorro : CuentaBancaria
    {
        public decimal TasaDeInteres { get; init; } //init: si quiero que se le asigne unicamente un valor al crear la instancia, en vez de usar set, uso init. Es decir,solo le puedo poner un valor invocandolo como una propiedad cuando se instancia.

        public CajaAhorro(string numero, decimal saldo, string[] titulares)
        : base(numero, saldo, titulares) { }

        public void AplicarInteres()
        {
            if (Estado != Estado.Activa) throw new CuentaNoActivaException(Estado);
            Saldo += Saldo * TasaDeInteres;
        }
        public override void Retirar(decimal monto)
        {
            ValidarOperacion(monto);

            if (Saldo >= monto)
            {
                Saldo -= monto;
            }
            else
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficienteException(Numero);
            }
        }
        public override string ObtenerResumen()
        {
            return $"Caja de Ahorro - Nro: {Numero}, Saldo: {Saldo:C}";
        }


    }
}
