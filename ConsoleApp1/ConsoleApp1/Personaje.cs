using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPorTurnos
{
    abstract class Personaje
    {
        protected int vida;
        protected int daño;

        public Personaje(int vida, int daño)
        {
            this.vida = vida;
            this.daño = daño;
        }

        public virtual void RecibirDaño(int cantidad)
        {
            vida -= cantidad;
            if (vida < 0)
                vida = 0;

            Console.WriteLine($"Ha recibido {cantidad} puntos de daño, vida restante: {vida}");
        }

        public virtual int ObtenerDaño()
        {
            return daño;
        }

        public bool EstaVivo()
        {
            return vida > 0;
        }
    }
}
