using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using BatallaNavalgo;

namespace BatallaNavalgoXNA
{
    /*Clase pricipal del juego.*/
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public enum ResultadoMenuDisparos { NINGUNO, DISPARO_COMUN, MINA_PUNTUAL, MINA_DOBLE, MINA_TRIPLE, MINA_POR_CONTACTO };
        private Boolean gameOver;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 posicionFondoDePantalla;
        Texture2D ImagenBotonAvanzarTurno, pantallaGameOver;
        Texture2D fondoDePantalla, bloqueTablero, botonDeRadioVacio, botonDeRadioSeleccionado;
        Texture2D imagenParteNaveGris, imagenParteNaveRoja, imagenParteNaveVerde, imagenParteNaveMarron, imagenParteNaveRota;
        Texture2D imagenMinaPuntual, imagenMinaDoble, imagenMinaTriple, imagenMinaContacto;
        Boton AvanzarTurnoButton;
        SpriteFont fuenteBatallaNavalgo;
        VistaTablero vistaTablero;
        MenuArmamentos menuArmamentos;
        ControladorMouse controladorMouse;
        Juego juegoBatallaNavalgo;
        Posicion posicionDeImpactoEnElTablero;
        DibujadorDeNaves dibujadorDeNaves;
        DibujadorDeMinas dibujadorDeMinas;
        MouseState estadoActualDelMouse, estadoAnteriorDelMouse;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Batalla Navalgo";
            this.IsMouseVisible = true;            
        }

        /*Inicializa lo necesario para poder correr el juego.*/
        protected override void Initialize()
        {
            posicionFondoDePantalla = new Vector2(0, -700);
            vistaTablero = new VistaTablero();
            menuArmamentos = new MenuArmamentos(new Vector2(0, 120));
            juegoBatallaNavalgo = new Juego();
            controladorMouse = new ControladorMouse(vistaTablero);
            posicionDeImpactoEnElTablero = new Posicion(0, 0);
            AvanzarTurnoButton = new Boton(new Vector2(50,375));            
            gameOver = false;
            base.Initialize();
        }

        /*Carga contenido desde archivos, se llama una unica vez.*/
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pantallaGameOver = Content.Load<Texture2D>("Imagenes\\GameOver"); 
            fondoDePantalla = Content.Load<Texture2D>("Imagenes\\fondoAgua");
            fuenteBatallaNavalgo = Content.Load<SpriteFont>("Fuente\\fuente");
            bloqueTablero = Content.Load<Texture2D>("Imagenes\\bloqueTablero");
            botonDeRadioVacio = Content.Load<Texture2D>("Imagenes\\seleccionVacio");
            botonDeRadioSeleccionado = Content.Load<Texture2D>("Imagenes\\seleccionElegido");
            ImagenBotonAvanzarTurno = Content.Load<Texture2D>("Imagenes\\BotonAvanzarTurno");
                                    
            CargarPartesDeNaves();
            CargarImagenesDeMinas();
            menuArmamentos.CrearBotonesDeMenu(botonDeRadioVacio, botonDeRadioSeleccionado);
            AvanzarTurnoButton.CargarImagen(ImagenBotonAvanzarTurno);            
        }

        private void CargarImagenesDeMinas() 
        {
            dibujadorDeMinas = new DibujadorDeMinas(spriteBatch, vistaTablero);
            imagenMinaContacto = Content.Load<Texture2D>("Imagenes\\minaContacto");
            dibujadorDeMinas.MinaContacto = imagenMinaContacto;
            imagenMinaPuntual = Content.Load<Texture2D>("Imagenes\\minaPuntual");
            dibujadorDeMinas.MinaPuntual = imagenMinaPuntual;
            imagenMinaDoble = Content.Load<Texture2D>("Imagenes\\minaDoble");
            dibujadorDeMinas.MinaDoble = imagenMinaDoble;
            imagenMinaTriple = Content.Load<Texture2D>("Imagenes\\minaTriple");
            dibujadorDeMinas.MinaTriple = imagenMinaTriple;
        }

        /*Carga partes de naves de distintos colores, dejndo al Dibujador en un estado valido.*/
        private void CargarPartesDeNaves()
        {
            dibujadorDeNaves = new DibujadorDeNaves(spriteBatch, vistaTablero);
            imagenParteNaveGris = Content.Load<Texture2D>("Imagenes\\parteNaveGris");
            dibujadorDeNaves.ParteGris = imagenParteNaveGris;
            imagenParteNaveRoja = Content.Load<Texture2D>("Imagenes\\parteNaveRoja");
            dibujadorDeNaves.ParteRoja = imagenParteNaveRoja;
            imagenParteNaveVerde = Content.Load<Texture2D>("Imagenes\\parteNaveVerde");
            dibujadorDeNaves.ParteVerde = imagenParteNaveVerde;
            imagenParteNaveMarron = Content.Load<Texture2D>("Imagenes\\parteNaveMarron");
            dibujadorDeNaves.ParteMarron = imagenParteNaveMarron;
            imagenParteNaveRota = Content.Load<Texture2D>("Imagenes\\parteNaveRota");
            dibujadorDeNaves.ParteRota = imagenParteNaveRota;
        }               

        /*Elimina contenido cargado*/
        protected override void UnloadContent()
        {  
            Content.Unload();
        }

        /*Actualiza Comportamiento.*/
        protected override void Update(GameTime gameTime)
        {
            /*Permite salir del juego.*/
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();            
            
            /*Obtiene estado del mouse.*/
            estadoActualDelMouse = Mouse.GetState();
            int filaDeImpacto = estadoActualDelMouse.Y;
            int columnaDeImpacto = estadoActualDelMouse.X;

            /*Si se clickea.*/            
            if ((estadoActualDelMouse.LeftButton == ButtonState.Pressed) && (estadoAnteriorDelMouse.LeftButton == ButtonState.Released))
            {
                ResultadoMenuDisparos seleccionActual =(ResultadoMenuDisparos) menuArmamentos.ActualizarSeleccion(filaDeImpacto, columnaDeImpacto);
                if (AvanzarTurnoButton.EsClickeado(columnaDeImpacto, filaDeImpacto))
                {
                    IngresarArmamentoDesdeMenu(posicionDeImpactoEnElTablero, seleccionActual);
                    /*Si hay un error al avanzar el turno, ignora la 
                     actualizacion y congela las naves pero no la seleccion
                     de minas, posicion de talbero, etc. para no dar una 
                     sensacion de "congelamiento" */
                    try
                    {
                        //Actualizar.
                        juegoBatallaNavalgo.AvanzarTurno();
                    }
                    catch (Exception e) 
                    {
                        gameOver = true;
                    }                                        
                } 
            }

            /*Puedo elegir posicion manteniendo apretado el boton izquierdo
            Va despues del metodo anterior para no romper la seleccion de casillero en el tablero */
            if (estadoActualDelMouse.LeftButton == ButtonState.Pressed)
            {
                posicionDeImpactoEnElTablero = controladorMouse.ObtenerPosicionDeImpacto(columnaDeImpacto, filaDeImpacto);            
            }            

            estadoAnteriorDelMouse = estadoActualDelMouse;
            base.Update(gameTime);
        }

       /*Se dibuja la Vista en pantalla.*/
        protected override void Draw(GameTime gameTime)
        {            
            GraphicsDevice.Clear(Color.CornflowerBlue);            
            spriteBatch.Begin();            

            spriteBatch.Draw(fondoDePantalla, posicionFondoDePantalla, Color.White);
            spriteBatch.DrawString(fuenteBatallaNavalgo, "Batalla Navalgo", new Vector2(300, 0), Color.White);
            spriteBatch.DrawString(fuenteBatallaNavalgo, "Puntos: " + juegoBatallaNavalgo.ObtenerPuntosDelJugador(),
                                    new Vector2(0, 25), Color.White);
            vistaTablero.Draw(spriteBatch, bloqueTablero, fuenteBatallaNavalgo);
            menuArmamentos.Draw(spriteBatch, fuenteBatallaNavalgo);            
            AvanzarTurnoButton.Draw(spriteBatch);
            spriteBatch.DrawString(fuenteBatallaNavalgo, "Impacto en fila: " + posicionDeImpactoEnElTablero.Fila,
                                    new Vector2(0, 50), Color.White);
            spriteBatch.DrawString(fuenteBatallaNavalgo, "Impacto en columna: " + posicionDeImpactoEnElTablero.Columna,
                                    new Vector2(0, 75), Color.White);
            dibujadorDeNaves.DibujarNaves(spriteBatch, juegoBatallaNavalgo.IteradorNaves());                                    
            dibujadorDeMinas.DibujarMinas(spriteBatch, juegoBatallaNavalgo.IteradorArmamentos());

            //Si termina el juego, dibuja una pantalla que lo indique.
            if (gameOver)
            {                
                DibujarPantallaGameOver(spriteBatch);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
        
        /*Intenta ingresar el armamento seleccionado en el menu visual.*/
        public void IngresarArmamentoDesdeMenu(Posicion posicion, ResultadoMenuDisparos seleccion) 
        {
            try
            {
                switch (seleccion)
                {
                    case ResultadoMenuDisparos.NINGUNO:
                        break;
                    case ResultadoMenuDisparos.DISPARO_COMUN:
                        juegoBatallaNavalgo.EfectuarDisparoComun(posicion);
                        break;
                    case ResultadoMenuDisparos.MINA_PUNTUAL:
                        juegoBatallaNavalgo.ColocarMinaPuntual(posicion);
                        break;
                    case ResultadoMenuDisparos.MINA_DOBLE:
                        juegoBatallaNavalgo.ColocarMinaDoble(posicion);
                        break;
                    case ResultadoMenuDisparos.MINA_TRIPLE:
                        juegoBatallaNavalgo.ColocarMinaTriple(posicion);
                        break;
                    case ResultadoMenuDisparos.MINA_POR_CONTACTO:
                        juegoBatallaNavalgo.ColocarMinaPorContacto(posicion);
                        break;
                }
            }
            catch (BatallaNavalgoExcepciones.JuegoJugadorSinPuntajeParaDisparoException e)
            {
                gameOver = true;                
            }
            catch (Exception e) 
            {
            /*ver tratamiento error general, posible grabado de error en
              archivo, etc.*/
                gameOver = true;
            }
        }

        
        
        /*Pantalla de fin de juego.*/
        private void DibujarPantallaGameOver(SpriteBatch spriteBatch)
        {
            Vector2 posicionGameOver = new Vector2(200, 200);
            spriteBatch.Draw(pantallaGameOver, posicionGameOver, Color.White);
        }
    }
}