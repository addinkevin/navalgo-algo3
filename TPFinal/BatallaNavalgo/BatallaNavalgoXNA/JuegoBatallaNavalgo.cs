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
    public class JuegoBatallaNavalgo : Microsoft.Xna.Framework.Game, IObservador
    {
        private static Vector2 POSICION_FONDO_DE_PANTALLA = new Vector2(0, -700);

        public enum ResultadoMenuDisparos { NINGUNO, DISPARO_COMUN, MINA_PUNTUAL, MINA_DOBLE, MINA_TRIPLE, MINA_POR_CONTACTO, NO_HACER_NADA };
        private Boolean gameOver, ganado;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D ImagenBotonAvanzarTurno, pantallaGameOver, pantallaGanadora;
        Texture2D fondoDePantalla, bloqueTablero, botonDeRadioVacio, botonDeRadioSeleccionado;
        Texture2D imagenParteNaveGris, imagenParteNaveRoja, imagenParteNaveVerde, imagenParteNaveMarron, imagenParteNaveRota;
        Texture2D imagenMinaPuntual, imagenMinaDoble, imagenMinaTriple, imagenMinaContacto;        
        SpriteFont fuenteBatallaNavalgo;
        VistaTablero vistaTablero;
        MenuArmamentos menuArmamentos;
        ControladorMouse controladorMouse;
        Juego juegoBatallaNavalgo;
        Posicion posicionDeImpactoEnElTablero;
        MouseState estadoActualDelMouse, estadoAnteriorDelMouse;
        List<NaveVista> coleccionNaveVista;
        List<MinaVista> coleccionMinaVista;
        public JuegoBatallaNavalgo()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Batalla Navalgo";
            this.IsMouseVisible = true;            
        }

        /*Inicializa lo necesario para poder correr el juego.*/
        protected override void Initialize()
        {
            coleccionNaveVista = new List<NaveVista>();
            coleccionMinaVista = new List<MinaVista>();
            vistaTablero = new VistaTablero(Tablero.Filas, Tablero.Columnas);
            menuArmamentos = new MenuArmamentos();
            controladorMouse = new ControladorMouse(vistaTablero);
            posicionDeImpactoEnElTablero = new Posicion(0, 0);
            gameOver = false;
            ganado = false;

            
            base.Initialize();

            juegoBatallaNavalgo = new Juego();
            juegoBatallaNavalgo.AddObservador(this);
            juegoBatallaNavalgo.Inicializar();
        }

        /*Carga contenido desde archivos, se llama una unica vez.*/
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            pantallaGameOver = Content.Load<Texture2D>("Imagenes\\GameOver");
            pantallaGanadora = Content.Load<Texture2D>("Imagenes\\Ganaste"); 
            fondoDePantalla = Content.Load<Texture2D>("Imagenes\\fondoAgua");
            fuenteBatallaNavalgo = Content.Load<SpriteFont>("Fuente\\fuente");
            bloqueTablero = Content.Load<Texture2D>("Imagenes\\bloqueTablero");
            botonDeRadioVacio = Content.Load<Texture2D>("Imagenes\\seleccionVacio");
            botonDeRadioSeleccionado = Content.Load<Texture2D>("Imagenes\\seleccionElegido");
            ImagenBotonAvanzarTurno = Content.Load<Texture2D>("Imagenes\\AvanzarTurno");
                                    
            CargarPartesDeNaves();
            CargarImagenesDeMinas();
            menuArmamentos.CrearBotonesDeMenu(botonDeRadioVacio, botonDeRadioSeleccionado);
        }

        private void CargarImagenesDeMinas() 
        {
            imagenMinaContacto = Content.Load<Texture2D>("Imagenes\\minaContacto");
            imagenMinaPuntual = Content.Load<Texture2D>("Imagenes\\minaPuntual");
            imagenMinaDoble = Content.Load<Texture2D>("Imagenes\\minaDoble");
            imagenMinaTriple = Content.Load<Texture2D>("Imagenes\\minaTriple");
        }

        /*Carga partes de naves de distintos colores, dejndo al Dibujador en un estado valido.*/
        private void CargarPartesDeNaves()
        {
            imagenParteNaveGris = Content.Load<Texture2D>("Imagenes\\parteNaveGris");
            imagenParteNaveRoja = Content.Load<Texture2D>("Imagenes\\parteNaveRoja");
            imagenParteNaveVerde = Content.Load<Texture2D>("Imagenes\\parteNaveVerde");
            imagenParteNaveMarron = Content.Load<Texture2D>("Imagenes\\parteNaveMarron");
            imagenParteNaveRota = Content.Load<Texture2D>("Imagenes\\parteNaveRota");
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
            if (juegoBatallaNavalgo.Ganado())
            {
                ganado = true;
                gameOver = true;
            }
            else if (juegoBatallaNavalgo.EstaTerminado())
            {
                ganado = false;
                gameOver = true;
            }
            
            /*Si se clickea.*/
            Boolean seClickea = (estadoActualDelMouse.LeftButton == ButtonState.Pressed) && (estadoAnteriorDelMouse.LeftButton == ButtonState.Released);
            if (seClickea && !gameOver && !ganado)
            {
                ResultadoMenuDisparos seleccionActual =(ResultadoMenuDisparos) menuArmamentos.ActualizarSeleccion(filaDeImpacto, columnaDeImpacto);
                                
                
                if (vistaTablero.EstaDentroDelTablero(columnaDeImpacto,filaDeImpacto))
                {   
                    //Actualizar.                        
                    posicionDeImpactoEnElTablero = controladorMouse.ObtenerPosicionDeImpacto(columnaDeImpacto, filaDeImpacto);            
                    IngresarArmamentoDesdeMenu(posicionDeImpactoEnElTablero, seleccionActual);               
                }
            
            }
            estadoAnteriorDelMouse = estadoActualDelMouse;
            base.Update(gameTime);
        }

       /*Se dibuja la Vista en pantalla.*/
        protected override void Draw(GameTime gameTime)
        {            
            GraphicsDevice.Clear(Color.CornflowerBlue);            
            spriteBatch.Begin();            

            spriteBatch.Draw(fondoDePantalla, POSICION_FONDO_DE_PANTALLA, Color.White);
            spriteBatch.DrawString(fuenteBatallaNavalgo, "Batalla Navalgo", new Vector2(300, 0), Color.White);
            spriteBatch.DrawString(fuenteBatallaNavalgo, "Puntos: " + juegoBatallaNavalgo.ObtenerPuntosDelJugador(),
                                    new Vector2(0, 25), Color.White);
            vistaTablero.Draw(spriteBatch, bloqueTablero, fuenteBatallaNavalgo);
            menuArmamentos.Draw(spriteBatch, fuenteBatallaNavalgo);                        
            spriteBatch.DrawString(fuenteBatallaNavalgo, "Impacto en fila: " + posicionDeImpactoEnElTablero.Fila,
                                    new Vector2(0, 50), Color.White);
            spriteBatch.DrawString(fuenteBatallaNavalgo, "Impacto en columna: " + posicionDeImpactoEnElTablero.Columna,
                                    new Vector2(0, 75), Color.White);
            DibujarNaves(coleccionNaveVista);
            DibujarMinas(coleccionMinaVista);
            //Si termina el juego, dibuja una pantalla indicando el motivo.
            if (gameOver) 
            {
                if (ganado)
                    DibujarPantallaFindeJuego(spriteBatch, pantallaGanadora);
                else
                    DibujarPantallaFindeJuego(spriteBatch, pantallaGameOver);
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
            catch (BatallaNavalgoExcepciones.JuegoJugadorSinPuntajeParaDisparoException)
            {
                /* No hacemos nada porque el jugador tiene al menos alguna posibilidad de disparar */
            }
            catch (BatallaNavalgoExcepciones.ArmamentoFueraDelTableroException)
            {
                //Tratamiento de mina fuera de tablero. No se hace nada.
            }
            catch (BatallaNavalgoExcepciones.JuegoTerminadoException)
            {
                gameOver = true;
            }
            catch (Exception)
            {
                /*ver tratamiento error general, posible grabado de error en
                  archivo, etc.*/
                gameOver = true;
            }
        }

        private void DibujarMinas(List<MinaVista> coleccionMinaVista)
        {
            foreach (MinaVista minaVista in coleccionMinaVista)
            {
                minaVista.Dibujar(spriteBatch);
            }
        }

        private void DibujarNaves(List<NaveVista> coleccionNavesVista)
        {
            foreach (NaveVista naveVista in coleccionNavesVista)
            {
                naveVista.Dibujar(spriteBatch);
            }
        }

        /*Pantalla de fin de juego.*/
        private void DibujarPantallaFindeJuego(SpriteBatch spriteBatch, Texture2D pantalla)
        {
            Vector2 posicionGameOver = new Vector2(200, 200);
            spriteBatch.Draw(pantalla, posicionGameOver, Color.White);
        }

        public void NotificarCreacionDeLancha(Nave nave)
        {
            NaveVista navevista = new NaveVista(nave, imagenParteNaveGris, imagenParteNaveRota, vistaTablero);
            coleccionNaveVista.Add(navevista);
        }
        public void NotificarCreacionDeDestructor(Destructor nave)
        {
            NaveVista navevista = new NaveVista(nave, imagenParteNaveRoja, imagenParteNaveRota, vistaTablero);
            coleccionNaveVista.Add(navevista);
        }
        public void NotificarCreacionDePortaAviones(Nave nave)
        {
            NaveVista navevista = new NaveVista(nave, imagenParteNaveGris, imagenParteNaveRota, vistaTablero);
            coleccionNaveVista.Add(navevista);
        }
        public void NotificarCreacionDeRompeHielo(Nave nave)
        {
            NaveVista navevista = new NaveVista(nave, imagenParteNaveMarron, imagenParteNaveRota, vistaTablero);
            coleccionNaveVista.Add(navevista);
        }
        public void NotificarCreacionDeBuque(Buque nave)
        {
            NaveVista navevista = new NaveVista(nave, imagenParteNaveVerde, imagenParteNaveRota, vistaTablero);
            coleccionNaveVista.Add(navevista);
        }
        public void NotificarCreacionDeMinaConRetardo(MinaConRetardo mina)
        {
            int radio = mina.Radio;
            Texture2D imagenMina;
            switch (radio)
            {
                case 0:
                    imagenMina = imagenMinaPuntual;
                    break;
                case 1:
                    imagenMina = imagenMinaDoble;
                    break;
                case 2:
                    imagenMina = imagenMinaTriple;
                    break;
                default:
                    imagenMina = imagenMinaPuntual;
                    break;
            }

            MinaVista minaVista = new MinaVista(mina, imagenMina, vistaTablero);
            coleccionMinaVista.Add(minaVista);
        }

        public void NotificarCreacionDeMinaPorContacto(MinaPorContacto mina)
        {
            MinaVista minaVista = new MinaVista(mina, imagenMinaContacto, vistaTablero);
            coleccionMinaVista.Add(minaVista);
        }

    }
}