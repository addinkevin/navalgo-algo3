using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BatallaNavalgo;

namespace BatallaNavalgoXNA
{
    public class VistaTablero
    {
        private static Vector2 POSICION_TABLERO_EN_PANTALLA = new Vector2(400, 80);
        public static int TAMANIO_BLOQUE_DEL_TABLERO = 40;

        private int altoTablero;
        private int anchoTablero;
        private int posicionInicialTableroEnX;
        private int posicionInicialTableroEnY;
        private int posicionFinalTableroEnX;
        private int posicionFinalTableroEnY;

        public VistaTablero(int altoTablero, int anchoTablero)
        {
            this.altoTablero = altoTablero;
            this.anchoTablero = anchoTablero;
            posicionInicialTableroEnX = (int)POSICION_TABLERO_EN_PANTALLA.X;
            posicionInicialTableroEnY = (int)POSICION_TABLERO_EN_PANTALLA.Y;
            posicionFinalTableroEnX = posicionInicialTableroEnX + (TAMANIO_BLOQUE_DEL_TABLERO * anchoTablero);
            posicionFinalTableroEnY = posicionInicialTableroEnY + (TAMANIO_BLOQUE_DEL_TABLERO * altoTablero);
        }

        public int PosicionInicialTableroEnX
        {
            get { return posicionInicialTableroEnX; }
        }

        public int PosicionInicialTableroEnY
        {
            get { return posicionInicialTableroEnY; }
        }
        
        public Boolean EstaDentroDelTablero(int x, int y)
        {
            if ((y > posicionInicialTableroEnY) && (y < posicionFinalTableroEnY))
            {
                if ((x > posicionInicialTableroEnX) && (x < posicionFinalTableroEnX))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch, Texture2D bloqueTablero, SpriteFont fuenteBatallaNavalgo)
        {
            for (int i = 0; i < altoTablero; i++)
            {
                for (int j = 0; j < anchoTablero; j++)
                {
                    int ancho = posicionInicialTableroEnX + (i * TAMANIO_BLOQUE_DEL_TABLERO);
                    int alto = posicionInicialTableroEnY + (j * TAMANIO_BLOQUE_DEL_TABLERO);
                    spriteBatch.Draw(bloqueTablero, new Rectangle(ancho, alto, TAMANIO_BLOQUE_DEL_TABLERO, TAMANIO_BLOQUE_DEL_TABLERO), null, Color.White);
                }
            }
            DibujarPosicionesDelTablero(spriteBatch, fuenteBatallaNavalgo);
        }

        public void DibujarPosicionesDelTablero(SpriteBatch spriteBatch, SpriteFont fuenteBatallaNavalgo)
        {
            int posicionInicialEnX = posicionInicialTableroEnX + 10; //Se suma el 10 en ambas posiciones
            int posicionInicialEnY = posicionInicialTableroEnY + 10; //solo por un tema de vista.
            for (int i = 0; i < Tablero.Filas; i++)
            {
                spriteBatch.DrawString(fuenteBatallaNavalgo, "" + (i + 1), new Vector2(375, posicionInicialEnY), Color.White);
                posicionInicialEnY += 40;              
            }
            for (int j = 0; j< Tablero.Columnas; j++)
            {
                spriteBatch.DrawString(fuenteBatallaNavalgo, "" + (j + 1), new Vector2(posicionInicialEnX, 55), Color.White);
                posicionInicialEnX += 40;
            }
        }

        public Vector2 GetPosicionDe(int fila, int columna)
        {
            Vector2 posicionEnPantalla = new Vector2(0,0);
            posicionEnPantalla.X = (posicionInicialTableroEnX + 10) +
                                    ((columna - 1) * VistaTablero.TAMANIO_BLOQUE_DEL_TABLERO); //Se suma el 10 en ambas posiciones
            posicionEnPantalla.Y = (posicionInicialTableroEnY + 10) + 
                                    ((fila - 1) * VistaTablero.TAMANIO_BLOQUE_DEL_TABLERO); //solo por un tema de vista.

            return posicionEnPantalla;
            
        }       
    }
}
