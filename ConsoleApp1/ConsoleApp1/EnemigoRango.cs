using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPorTurnos
{
    internal class EnemigoRango : Enemigo
    {
        private int balas;

        public EnemigoRango(int vida, int daño, int balas) : base(vida, daño)
        {
            this.balas = balas;
        }

        public override int ObtenerDaño()
        {
            if (balas > 0)
                return daño;
            else
                return 0;
        }

        public override void AtacarJugador(Jugador jugador)
        {
            if (!EstaVivo())
            {
                Console.WriteLine("El enemigo esta muerto y no puede atacar");
                return;
            }

            if (balas > 0)
            {
                Console.WriteLine($"Enemigo a distancia dispara (Balas restantes: {balas - 1})");
                jugador.RecibirDaño(ObtenerDaño());
                balas--;
            }
            else
            {
                Console.WriteLine("El enemigo a distancia se quedo sin balas, pasa su turno.");
            }
        }
    }
}