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
        public enum MenuDisparos {NINGUNO, DISPARO_COMUN, MINA_PUNTUAL, MINA_DOBLE, MINA_TRIPLE, MINA_POR_CONTACTO};

        private Vector2 posicionInicialEnPantalla;
        private int cantidadDeLineas;
        private Texture2D botonSeleccionado, botonVacio;
        private SpriteFont fuente;
        private const int SALTO_DE_LINEA = 40;
        private const int LADO_DE_BOTON = 24;
        private MenuDisparos DisparoSeleccionado;
        private Queue<CuadroDeSeleccion> botones;


        public MenuArmamentos(Vector2 posicionMenuEnPantalla)
        {   
            posicionInicialEnPantalla = posicionMenuEnPantalla;  
            DisparoSeleccionado = MenuDisparos.NINGUNO;
            botones = new Queue<CuadroDeSeleccion>();
            
        }

        public Texture2D ImagenDebotonVacio 
        {
            set { botonVacio = value; }
        }

        public Texture2D ImagenDebotonSeleccionado
        {
            set { botonSeleccionado = value; }
        }

        /*Dibuja el menu con los botones correspondientes*/
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
            CrearBotonesDeMenu(botonVacio, botonSeleccionado);
            DibujarBloquesDeSeleccion(spriteBatch);
        }

        private void DibujarLinea(String texto, SpriteBatch spriteBatch)
        {
            int sangria = LADO_DE_BOTON + 10;
            Vector2 vectorAuxiliar = new Vector2(posicionInicialEnPantalla.X + sangria, posicionInicialEnPantalla.Y + (SALTO_DE_LINEA * cantidadDeLineas));
            spriteBatch.DrawString(fuente, texto, vectorAuxiliar, Color.White);           
            cantidadDeLineas++;
        }
            

        private void DibujarBloquesDeSeleccion(SpriteBatch spriteBatch)
        {
            IEnumerator<CuadroDeSeleccion> c = botones.GetEnumerator();
            while (c.MoveNext()) 
            {
                int x = (int)c.Current.X;
                int y = (int)c.Current.Y;
                spriteBatch.Draw(c.Current.Imagen, new Rectangle(x, y, LADO_DE_BOTON, LADO_DE_BOTON), Color.White);
            }
        }

        public void CrearBotonesDeMenu(Texture2D vacio, Texture2D seleccionado)
        {
            int tiposDeArmamento =1;
            while (tiposDeArmamento <= 5)
            {                
                Vector2 posicionCorrespondienteDeBoton = new Vector2(posicionInicialEnPantalla.X, posicionInicialEnPantalla.Y + (SALTO_DE_LINEA * tiposDeArmamento));
                CuadroDeSeleccion cuadroAuxiliar = new CuadroDeSeleccion(posicionCorrespondienteDeBoton, seleccionado, vacio);
                botones.Enqueue(cuadroAuxiliar);
                tiposDeArmamento++;
            }
        }


        public void ActualizarSeleccion(int fila, int columna)
        {
            


        }
                
    }
}
