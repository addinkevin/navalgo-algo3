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
        public enum ResultadoMenuDisparos { NINGUNO, DISPARO_COMUN, MINA_PUNTUAL, MINA_DOBLE, MINA_TRIPLE, MINA_POR_CONTACTO, NO_HACER_NADA };
        private Vector2 posicionInicialEnPantalla;
        private int cantidadDeLineas;        
        private SpriteFont fuente;
        private const int SALTO_DE_LINEA = 40;
        private const int LADO_DE_BOTON = 24;
        private ResultadoMenuDisparos DisparoSeleccionado;
        private Queue<CuadroDeSeleccion> botones;


        public MenuArmamentos(Vector2 posicionMenuEnPantalla)
        {   
            posicionInicialEnPantalla = posicionMenuEnPantalla;
            DisparoSeleccionado = ResultadoMenuDisparos.NINGUNO;
            botones = new Queue<CuadroDeSeleccion>();           
        }

        /*Se cargan las imagenes para los botones para dibujarlos despues.*/
        public void CargarImagenes(Texture2D botonVacio, Texture2D botonSeleccionado) 
        {
            CrearBotonesDeMenu(botonVacio, botonSeleccionado);
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
            DibujarLinea("Avanzar de tuno: 10 ptos.", spriteBatch);
            
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
                c.Current.Dibujar(spriteBatch,LADO_DE_BOTON);                
            }
        }

        /*Llena la cola de botones correspondientes a las distintas opciones */
        public void CrearBotonesDeMenu(Texture2D vacio, Texture2D seleccionado)
        {
            int tiposDeArmamento =1;
            while (tiposDeArmamento <= 6)
            {                
                Vector2 posicionCorrespondienteDeBoton = new Vector2(posicionInicialEnPantalla.X, posicionInicialEnPantalla.Y + (SALTO_DE_LINEA * tiposDeArmamento));
                CuadroDeSeleccion cuadroAuxiliar = new CuadroDeSeleccion(posicionCorrespondienteDeBoton, seleccionado, vacio);
                botones.Enqueue(cuadroAuxiliar);
                tiposDeArmamento++;
            }
        }

        /*Actualiza permitiendo una sola seleccion (como un boton de radio)*/
        public ResultadoMenuDisparos ActualizarSeleccion(int fila, int columna)
        {
            IEnumerator<CuadroDeSeleccion> c = botones.GetEnumerator();
            ResultadoMenuDisparos disparoAnterior = DisparoSeleccionado;
            DisparoSeleccionado = ResultadoMenuDisparos.NINGUNO;
            while (c.MoveNext())
            {
                DisparoSeleccionado++;
                if (EstaDentroDeBoton(c.Current, fila, columna))
                {                                                          
                    QuitarSelecciones();
                    c.Current.Seleccionado=true;                    
                    return DisparoSeleccionado;
                }               
            }
            //Si no corresponde a ninguno, es porque no se selecciono ningun boton, entonces vuelvo
            //a la anterior, que era valida, pues no cambio.
            DisparoSeleccionado = ResultadoMenuDisparos.NINGUNO;            
            DisparoSeleccionado = disparoAnterior;
            return disparoAnterior;            
        }

        /*Des-Selecciona todos los botones*/
        private void QuitarSelecciones() 
        {
            IEnumerator<CuadroDeSeleccion> c = botones.GetEnumerator();
            while (c.MoveNext())
            {
                c.Current.Seleccionado = false;
            }
        }

        /*Se fija si los parametros de x e y corresponden a un cuadrado.*/
        private Boolean EstaDentroDeBoton(CuadroDeSeleccion cuadro,int y, int x)
        {            
            if ((y >= cuadro.Y) && (y <= (cuadro.Y + LADO_DE_BOTON))) 
            {
                if ((x >= cuadro.X) && (x <= (cuadro.X + LADO_DE_BOTON))) 
                {                    
                    return true;
                } 
            }
            return false;
        }


         public ResultadoMenuDisparos DevolverSeleccion()         
        {
            return DisparoSeleccionado;
        }
                
    }
}
