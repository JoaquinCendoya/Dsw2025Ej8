using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Domain
{
    public class CuentaCorriente : CuentaBancaria
    {
        public decimal LimiteDeDescubierto { get; init; }
        public decimal Comision { get; set; }

        public CuentaCorriente(string numero, decimal saldo, string[] titulares)
        : base(numero, saldo, titulares) { }

        public override void Depositar(decimal monto)
        {
            ValidarOperacion(monto);
            Saldo += monto - (monto * Comision);
        }
        public override void Retirar(decimal monto)
        {
            ValidarOperacion(monto);

            if (Saldo - monto >= -LimiteDeDescubierto)
            {
                Saldo -= monto;
                if (Saldo < 0)
                    Estado = Estado.Suspendida;
            }
            else
            {
                Estado = Estado.Suspendida;
                throw new SaldoInsuficienteException(Numero);
            }
        }
        public override string ObtenerResumen()
        {
            return $"Cuenta Corriente - Nro: {Numero}, Saldo: {Saldo:C}";
        }
    }
}
