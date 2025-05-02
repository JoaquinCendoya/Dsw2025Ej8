using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsw2025Ej8.Domain
{
    internal class Excepciones
    {
        public class MontoNoValidoException : Exception
        {
            public MontoNoValidoException() : base("El monto ingresado no es válido para la operación solicitada") { }
        }

        public class CuentaNoActivaException : Exception
        {
            public CuentaNoActivaException(Estado estado)
                : base($"No se puede operar con la cuenta {estado}") { }
        }

        public class SaldoInsuficienteException : Exception
        {
            public SaldoInsuficienteException(string numeroCuenta) : base($"La cuenta {numeroCuenta} no cuenta con saldo para la operación solicitada. Fue suspendida.") { }
        }

        public class NumeroCuentaInvalidoException : Exception
        {
            public NumeroCuentaInvalidoException()
                : base("El numero de cuenta no puede estar vacio o nulo") { }
        }

        public class SaldoInicialInvalidoException : Exception
        {
            public SaldoInicialInvalidoException()
                : base("El saldo inicial no puede ser negativo") { }
        }

        public class TitularesInvalidosException : Exception
        {
            public TitularesInvalidosException()
                : base("La lista de titulares no puede ser nula o vacia") { }
        }
    }
}
