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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 posicionFondoDePantalla;
        Texture2D fondoDePantalla;
        Texture2D bloqueTablero;
        Texture2D botonDeRadioVacio, botonDeRadioSeleccionado;
        Texture2D ImagenBotonAvanzarTurno;
        Boton AvanzarTurnoButton;
        SpriteFont fuenteBatallaNavalgo;
        VistaTablero vistaTablero;
        MenuArmamentos menuArmamentos;
        ControladorMouse controladorMouse;
        Juego juegoBatallaNavalgo;
        Posicion posicionDeImpactoEnElTablero;

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
            menuArmamentos.CrearBotonesDeMenu(botonDeRadioVacio, botonDeRadioSeleccionado);
            AvanzarTurnoButton.CargarImagen(ImagenBotonAvanzarTurno);
            
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

            var mouse = Mouse.GetState();
            if (mouse.LeftButton == ButtonState.Pressed)
            {
                int filaDeImpacto = mouse.Y;
                int columnaDeImpacto = mouse.X;
                menuArmamentos.ActualizarSeleccion(filaDeImpacto, columnaDeImpacto);                    
                posicionDeImpactoEnElTablero = controladorMouse.ObtenerPosicionDeImpacto(columnaDeImpacto, filaDeImpacto);
                if (AvanzarTurnoButton.EsClickeado(columnaDeImpacto, filaDeImpacto)) 
                {                    
                    //Actualizar;
                }
            }

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

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
