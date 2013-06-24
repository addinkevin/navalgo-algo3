using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BatallaNavalgo;

namespace BatallaNavalgoXNA
{
    class CuadroDeSeleccion
    {
        private Texture2D imagenSeleccionado, imagenNoSeleccionado;
        private Vector2 posicion;
        private Boolean seleccionado;

        public CuadroDeSeleccion(Vector2 posicion, Texture2D imagenSeleccionado, Texture2D imagenNoSeleccionado) 
        {
            this.posicion = posicion;
            this.imagenNoSeleccionado = imagenNoSeleccionado;
            this.imagenSeleccionado = imagenSeleccionado;
            seleccionado = false;            
        }

        
        public float X 
        {
            get { return posicion.X; }
        }
                
        public float Y
        {
            get { return posicion.Y; }
        }

        public Boolean Seleccionado 
        {
            get { return seleccionado;}
            set { seleccionado = value; }
        }

        public Texture2D Imagen 
        {
            get 
            {
                if (seleccionado)
                    return imagenSeleccionado;
                else
                    return imagenNoSeleccionado;                
            }
        }

    public void Dibujar(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(Imagen, posicion, Color.White);
    }

    }
}
