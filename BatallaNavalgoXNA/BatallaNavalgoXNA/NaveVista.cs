using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BatallaNavalgo;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace BatallaNavalgoXNA
{
    public class NaveVista
    {
        public enum ColorDeParte
        {
            Rojo, Marron, Verde, Gris,
        }
        private ColorDeParte colorDeParte;
        private Nave nave;
        private DibujadorDeNaves dibujador;

        public NaveVista(Nave nave, ColorDeParte color, DibujadorDeNaves dibujador)
        {
            this.nave = nave;
            this.colorDeParte = color;
            this.dibujador = dibujador;
        }

        public void Dibujar()
        {
            switch (this.colorDeParte)
            {
                case ColorDeParte.Rojo:
                    dibujador.DibujarNave(this.nave ,dibujador.ParteRoja);
                    break;
                case ColorDeParte.Marron:
                    dibujador.DibujarNave(this.nave, dibujador.ParteMarron);
                    break;
                case ColorDeParte.Verde:
                    dibujador.DibujarNave(this.nave, dibujador.ParteVerde);
                    break;
                case ColorDeParte.Gris:
                    dibujador.DibujarNave(this.nave, dibujador.ParteGris);
                    break;
            };
        }
    }
}