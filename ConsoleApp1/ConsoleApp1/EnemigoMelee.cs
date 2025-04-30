using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPorTurnos
{
    class EnemigoMelee : Enemigo
    {
        public EnemigoMelee(int vida, int daño) : base(vida, daño) { }

        public override void AtacarJugador(Jugador jugador)
        {
            if (EstaVivo())
            {
                Console.WriteLine("¡Enemigo melee ataca!");
                jugador.RecibirDaño(ObtenerDaño());
            }
        }
    }
}
