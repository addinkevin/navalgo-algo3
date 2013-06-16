using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BatallaNavalgo;

namespace BatallaNavalgoXNA
{
    class Boton
    {
        private Texture2D imagen;
        private Vector2 posicion;
        private int alto, ancho;

        public Boton(Vector2 posicion)
        {
            this.posicion = posicion;
            alto = 0;
            ancho = 0;
            imagen = null;
        }
        
        public void CargarImagen(Texture2D imagen) 
        {
            this.imagen = imagen;
            alto = imagen.Height;
            ancho = imagen.Width;            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(imagen, posicion, Color.White);
        }

        public Boolean EsClickeado(int x, int y) 
        {
            if ((y >= posicion.Y) && (y <= (posicion.Y + alto)))
            {
                if ((x >= posicion.X) && (x <= (posicion.X + ancho)))
                {
                    return true;
                }
            }
            return false;
        
        }
    


    }
}
