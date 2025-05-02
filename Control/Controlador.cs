using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dsw2025Ej8.Persistencia;
using Dsw2025Ej8.Domain;
using static Dsw2025Ej8.Domain.Excepciones;

namespace Dsw2025Ej8.Control
{
    public class Controlador
    {
        public void Ejecutar()
        {
            var cuentas = Datos.ObtenerCuentas();
            // Obtener referencias individuales para operar
            var caja1 = cuentas.Find(c => c.Numero == "CA001") as CajaAhorro;
            var caja2 = cuentas.Find(c => c.Numero == "CA002") as CajaAhorro;
            var cc1 = cuentas.Find(c => c.Numero == "CC001") as CuentaCorriente;
            var cc2 = cuentas.Find(c => c.Numero == "CC002") as CuentaCorriente;

            // OPERACIONES DE PRUEBA
            try { caja1?.Depositar(500); } catch (Exception ex) { Console.WriteLine(ex.Message); }
            try { caja2?.Retirar(300); } catch (Exception ex) { Console.WriteLine(ex.Message); }
            try { cc1?.Depositar(1000); } catch (Exception ex) { Console.WriteLine(ex.Message); }
            try { cc2?.Retirar(200); } catch (Exception ex) { Console.WriteLine(ex.Message); }

            try { caja1?.AplicarInteres(); } catch (CuentaNoActivaException ex) { Console.WriteLine(ex.Message); }
            try { caja2?.AplicarInteres(); } catch (CuentaNoActivaException ex) { Console.WriteLine(ex.Message); }
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

                Console.WriteLine($"Numero: {resumen.Numero}, Tipo: {resumen.Tipo}, Saldo: {resumen.Saldo:C}");
            }
        }
    }
}
