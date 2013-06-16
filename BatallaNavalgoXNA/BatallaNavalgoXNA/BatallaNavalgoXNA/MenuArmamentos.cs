using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BatallaNavalgo;

namespace BatallaNavalgoXNA
{
    class MenuArmamentos
    {
        public enum Disparos {DISPARO_COMUN, MINA_PUNTUAL, MINA_DOBLE, MINA_TRIPLE, MINA_POR_CONTACTO};

        private Vector2 posicionInicialEnPantalla;
        private int cantidadDeLineas;
        private Texture2D botonSeleccionado, botonVacio;
        private SpriteFont fuente;
        private const int SALTO_DE_LINEA = 40;


        public MenuArmamentos(Vector2 posicionMenuEnPantalla, Texture2D seleccionado, Texture2D vacio) 
        {
            posicionInicialEnPantalla = posicionMenuEnPantalla;            
            botonSeleccionado = seleccionado;
            botonVacio = vacio;
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont fuente) 
        {
            cantidadDeLineas = 0;
            this.fuente = fuente;
            spriteBatch.DrawString(fuente, "Seleccion de disparo.", posicionInicialEnPantalla, Color.Wheat);
            cantidadDeLineas++;           

            DibujarLinea("Convencional: 200 ptos." ,spriteBatch);
            DibujarLinea("Mina puntual: 50 ptos.", spriteBatch);
            DibujarLinea("Mina doble: 100 ptos.", spriteBatch);
            DibujarLinea("Mina triple: 125 ptos.", spriteBatch);
            DibujarLinea("Mina contacto: 150 ptos.", spriteBatch);
        }

        private void DibujarLinea(String texto, SpriteBatch spriteBatch)
        {
            Vector2 vectorAuxiliar = new Vector2(posicionInicialEnPantalla.X, posicionInicialEnPantalla.Y + (SALTO_DE_LINEA * cantidadDeLineas));
            spriteBatch.DrawString(fuente, texto, vectorAuxiliar, Color.White);
           
            cantidadDeLineas++;
        }            
    }
}
