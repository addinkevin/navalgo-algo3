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

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        public enum ResultadoMenuDisparos { NINGUNO, DISPARO_COMUN, MINA_PUNTUAL, MINA_DOBLE, MINA_TRIPLE, MINA_POR_CONTACTO };
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 posicionFondoDePantalla;
        Texture2D fondoDePantalla, bloqueTablero, botonDeRadioVacio, botonDeRadioSeleccionado;
        Texture2D ImagenBotonAvanzarTurno, imagenParteNaveGris, imagenParteNaveRoja, imagenParteNaveVerde, imagenParteNaveMarron, imagenParteNaveRota;        
        Texture2D imagenMinaPuntual, imagenMinaDoble, imagenMinaTriple, imagenMinaContacto;
        Boton AvanzarTurnoButton;
        SpriteFont fuenteBatallaNavalgo;
        VistaTablero vistaTablero;
        MenuArmamentos menuArmamentos;
        ControladorMouse controladorMouse;
        Juego juegoBatallaNavalgo;
        Posicion posicionDeImpactoEnElTablero;

        MouseState estadoActualDelMouse, estadoAnteriorDelMouse;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Batalla Navalgo";
            this.IsMouseVisible = true;            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            posicionFondoDePantalla = new Vector2(0, -700);
            vistaTablero = new VistaTablero();
            menuArmamentos = new MenuArmamentos(new Vector2(0, 120));
            juegoBatallaNavalgo = new Juego();
            controladorMouse = new ControladorMouse(vistaTablero);
            posicionDeImpactoEnElTablero = new Posicion(0, 0);
            AvanzarTurnoButton = new Boton(new Vector2(50,375));            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            fondoDePantalla = Content.Load<Texture2D>("Imagenes\\fondoAgua");
            fuenteBatallaNavalgo = Content.Load<SpriteFont>("Fuente\\fuente");
            bloqueTablero = Content.Load<Texture2D>("Imagenes\\bloqueTablero");
            botonDeRadioVacio = Content.Load<Texture2D>("Imagenes\\seleccionVacio");
            botonDeRadioSeleccionado = Content.Load<Texture2D>("Imagenes\\seleccionElegido");
            ImagenBotonAvanzarTurno = Content.Load<Texture2D>("Imagenes\\BotonAvanzarTurno");
            imagenMinaContacto = Content.Load<Texture2D>("Imagenes\\minaContacto");
            imagenMinaPuntual = Content.Load<Texture2D>("Imagenes\\minaPuntual");
            imagenMinaDoble = Content.Load<Texture2D>("Imagenes\\minaDoble");
            imagenMinaTriple = Content.Load<Texture2D>("Imagenes\\minaTriple");
            CargarPartesDeNaves();            
            menuArmamentos.CrearBotonesDeMenu(botonDeRadioVacio, botonDeRadioSeleccionado);
            AvanzarTurnoButton.CargarImagen(ImagenBotonAvanzarTurno);
            
        }        

        /*Carga partes de naves de distintos colores.*/
        private void CargarPartesDeNaves() 
        {
            imagenParteNaveGris = Content.Load<Texture2D>("Imagenes\\parteNaveGris");
            imagenParteNaveRoja = Content.Load<Texture2D>("Imagenes\\parteNaveRoja");
            imagenParteNaveVerde = Content.Load<Texture2D>("Imagenes\\parteNaveVerde");
            imagenParteNaveMarron = Content.Load<Texture2D>("Imagenes\\parteNaveMarron");
            imagenParteNaveRota = Content.Load<Texture2D>("Imagenes\\parteNaveRota");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();            
            
            // Get the mouse state relevant for this frame
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
                    juegoBatallaNavalgo.AvanzarTurno();
                    //Actualizar;                    
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

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
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
            DibujarNaves(spriteBatch);
            DibujarMinas(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }


        public void DibujarNaves(SpriteBatch spriteBatch)
        {
            IEnumerator<Nave> recorredorDeNaves = juegoBatallaNavalgo.IteradorNaves();
            while (recorredorDeNaves.MoveNext())
            {
                DibujarUnaNave(spriteBatch, recorredorDeNaves.Current);
            }
        }


        /*Dibuja Nave generica*/
        public void DibujarUnaNave(SpriteBatch spriteBatch, Nave nave) 
        {
            if (nave.ObtenerResistenciaGeneral() == 2) 
            {
                DibujarUnRompeHielos(spriteBatch, nave);
                return;
            }
            List<Posicion> posiciones = nave.GetPosiciones();
            foreach (Posicion posicion in posiciones) 
            {
                int fila = posicion.Fila;
                int columna = posicion.Columna;
                Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);
                spriteBatch.Draw(imagenParteNaveGris, posicionDeImagen, Color.White);               
            }
        }

        /*Dibuja Destructor*/
        public void DibujarUnaNave(SpriteBatch spriteBatch, Destructor nave) 
        {
            List<Posicion> posiciones = nave.GetPosiciones();
            foreach (Posicion posicion in posiciones)
            {
                int fila = posicion.Fila;
                int columna = posicion.Columna;
                Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);
                spriteBatch.Draw(imagenParteNaveRoja, posicionDeImagen, Color.White);                
            }
        }

        /*Dibuja Buque*/
        public void DibujarUnaNave(SpriteBatch spriteBatch, Buque nave) 
        {
            List<Posicion> posiciones = nave.GetPosiciones();
            foreach (Posicion posicion in posiciones)
            {
                int fila = posicion.Fila;
                int columna = posicion.Columna;
                Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);
                spriteBatch.Draw(imagenParteNaveVerde, posicionDeImagen, Color.White);                
            }            
        }

        /*Dibuja Rompehielos*/
        public void DibujarUnRompeHielos(SpriteBatch spriteBatch, Nave nave)
        {
            List<Posicion> posiciones = nave.GetPosiciones();
            foreach (Posicion posicion in posiciones)
            {
                int fila = posicion.Fila;
                int columna = posicion.Columna;
                Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);
                spriteBatch.Draw(imagenParteNaveMarron, posicionDeImagen, Color.White);                
            } 
        }

        public void IngresarArmamentoDesdeMenu(Posicion posicion, ResultadoMenuDisparos seleccion) 
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

        /*Dibuja las minas en el tablero*/
        public void DibujarMinas(SpriteBatch spriteBatch)
        {
            IEnumerator<Armamento> recorredorDeArmamentos = juegoBatallaNavalgo.IteradorArmamentos();
            while (recorredorDeArmamentos.MoveNext())
            {
                if (recorredorDeArmamentos.Current.GetType().ToString() == "BatallaNavalgo.MinaPorContacto") 
                {
                    DibujarMinaContacto(spriteBatch, (MinaPorContacto)recorredorDeArmamentos.Current);                    
                }
                if (recorredorDeArmamentos.Current.GetType().ToString() == "BatallaNavalgo.MinaConRetardo") 
                {
                    DibujarMinaRetardo(spriteBatch, (MinaConRetardo)recorredorDeArmamentos.Current);
                }               
            }
        }       

        /*Dibuja mina con retardo, distinto color segun su radio.*/
        public void DibujarMinaRetardo(SpriteBatch spriteBatch, MinaConRetardo mina)
        {     
            Posicion posicion = mina.Posicion;
            int fila = posicion.Fila;
            int columna = posicion.Columna;
            Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);
            Texture2D imagenMina = ObtenerImagenDeMinaConretardo(mina);

            spriteBatch.Draw(imagenMina, posicionDeImagen, Color.White);

        }

        /*Dibuja mina por contacto*/
        public void DibujarMinaContacto(SpriteBatch spriteBatch, MinaPorContacto mina)
        {
            Posicion posicion = mina.Posicion;
            int fila = posicion.Fila;
            int columna = posicion.Columna;
            Vector2 posicionDeImagen = vistaTablero.GetPosicionDe(fila, columna);
            Texture2D imagenMina = imagenMinaContacto;
            spriteBatch.Draw(imagenMina, posicionDeImagen, Color.White);
        }
        
        /*Obtiene textura de mina segun su radio.*/
        private Texture2D ObtenerImagenDeMinaConretardo(MinaConRetardo mina) 
        {
            int radio = mina.Radio;
            switch (radio) 
            {
                case 0:
                    return imagenMinaPuntual;
                    break;
                case 1:
                    return imagenMinaDoble;
                    break;
                case 2:
                    return imagenMinaTriple;
                    break;
                default:
                    return imagenMinaPuntual;
                    break;
            }
        }
    }
}
