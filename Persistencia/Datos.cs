using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dsw2025Ej8.Domain;
using static Dsw2025Ej8.Domain.Excepciones;
namespace Dsw2025Ej8.Persistencia
{
    internal class Datos
    {
        public static List<CuentaBancaria> ObtenerCuentas()
        {
            var cuentas = new List<CuentaBancaria>();

            try
            {
                var caja1 = new CajaAhorro("CA001", 1000m, new[] { "Ana" })
                { TasaDeInteres = 0.05m };
                cuentas.Add(caja1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cuenta caja de ahorro: {ex.Message}");
            }

            try
            {
                var caja2 = new CajaAhorro("CA002", 200m, new[] { "Luis" })
                { TasaDeInteres = 0.03m };
                cuentas.Add(caja2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cuenta caja de ahorro: {ex.Message}");
            }

            try
            {
                var cc1 = new CuentaCorriente("CC001", 500m, new[] { "Marta" })
                { Comision = 0.02m, LimiteDeDescubierto = 300m };
                cuentas.Add(cc1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cuenta cuenta corriente: {ex.Message}");
            }

            try
            {
                var cc2 = new CuentaCorriente("CC002", 50m, new[] { "Pablo" })
                { Comision = 0.01m, LimiteDeDescubierto = 100m };
                cuentas.Add(cc2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cuenta cuenta corriente: {ex.Message}");
            }

            // Cuentas invalidas para probar excepciones
            try
            {
                var cc3 = new CuentaCorriente("", 100m, new[] { "Juliano" })
                { Comision = 0.03m, LimiteDeDescubierto = 200m };
                cuentas.Add(cc3);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cuenta cuenta corriente: {ex.Message}");
            }

            try
            {
                var cc4 = new CuentaCorriente("CC004", -100m, new[] { "Joaquin" })
                { Comision = 0.03m, LimiteDeDescubierto = 200m };
                cuentas.Add(cc4);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cuenta cuenta corriente: {ex.Message}");
            }

            try
            {
                var cc5 = new CuentaCorriente("CC005", 1000m, new[] { "" })
                { Comision = 0.03m, LimiteDeDescubierto = 200m };
                cuentas.Add(cc5);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear cuenta cuenta corriente: {ex.Message}");
            }


            return cuentas;
        }
    }
}
