using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPorTurnos
{
    abstract class Enemigo : Personaje
    {
        public Enemigo(int vida, int daño) : base(vida, daño) { }

        public abstract void AtacarJugador(Jugador jugador);
    }
}
