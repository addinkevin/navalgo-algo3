using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BatallaNavalgo;

namespace BatallaNavalgoXNA
{
    class ControladorMouse
    {
        VistaTablero vistaTableroActual;

        public ControladorMouse(VistaTablero vistaTablero)
        {
            vistaTableroActual = vistaTablero;
        }

        public Posicion ObtenerPosicionDeImpacto(int x, int y)
        {
            Posicion posicionDeImpacto;
            if (vistaTableroActual.EstaDentroDelTablero(x,y))
            {
                int posicionDeImpactoEnX = (int)(x - vistaTableroActual.PosicionInicialTableroEnX) / VistaTablero.TAMANIO_BLOQUE_DEL_TABLERO;
                int posicionDeImpactoEnY = (int)(y - vistaTableroActual.PosicionInicialTableroEnY) / VistaTablero.TAMANIO_BLOQUE_DEL_TABLERO;
                return (posicionDeImpacto = new Posicion(posicionDeImpactoEnY + 1, posicionDeImpactoEnX + 1));
            }
            /* Se devuelve una posicion fuera del tablero, ya que no se impacta */
            return (posicionDeImpacto = new Posicion(0,0));
        }
    }
}
