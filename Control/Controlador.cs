using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dsw2025Ej8.Domain;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Control
{
    public class Controlador
    {
        public void Ejecutar()
        {
            var cuentas = new List<CuentaBancaria>();

            var caja1 = new CajaAhorro("CA001", 1000m, new[] { "Ana" }) 
            { TasaDeInteres = 0.05m 
            };
            var caja2 = new CajaAhorro("CA002", 200m, new[] { "Luis" }) 
            { TasaDeInteres = 0.03m 
            };

            var cc1 = new CuentaCorriente("CC001", 500m, new[] { "Marta" }) 
            { Comision = 0.02m, LimiteDeDescubierto = 300m 
            };
            var cc2 = new CuentaCorriente("CC002", 50m, new[] { "Pablo" }) 
            { Comision = 0.01m, LimiteDeDescubierto = 100m 
            };

            cuentas.AddRange(new CuentaBancaria[] { caja1, caja2, cc1, cc2 });


            // Realizar operaciones de prueba
            try { caja1.Depositar(500); } catch (Exception ex) { Console.WriteLine(ex.Message); }
            try { caja2.Retirar(300); } catch (Exception ex) { Console.WriteLine(ex.Message); }
            try { cc1.Depositar(1000); } catch (Exception ex) { Console.WriteLine(ex.Message); }
            try { cc2.Retirar(200); } catch (Exception ex) { Console.WriteLine(ex.Message); }

            try
            {
                caja1.AplicarInteres();
            }
            catch (CuentaNoActivaException ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {
                caja2.AplicarInteres();
            }
            catch (CuentaNoActivaException ex)
            {
                Console.WriteLine(ex.Message);
            }
         

            // Mostrar resumen de todas las cuentas con clase anónima
            Console.WriteLine("\n=======RESUMEN DE CUENTAS=======");
            foreach (var cuenta in cuentas)
            {
                var resumen = new
                {
                    Numero = cuenta.Numero,
                    Tipo = cuenta.GetType().Name,
                    Saldo = cuenta.Saldo
                };

                Console.WriteLine($"Número: {resumen.Numero}, Tipo: {resumen.Tipo}, Saldo: {resumen.Saldo:C}");
            }
        }
    }
}
