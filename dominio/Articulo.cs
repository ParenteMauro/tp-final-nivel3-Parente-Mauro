﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace dominio
{
    public class Articulo
    {
        private decimal precio;
        public Articulo() 
        {
            Marca = new Marca();
            Categoria = new Categoria();

        }
        public int Id { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }

        public decimal Precio
        {
            get
            {
                return Math.Round(precio, 2);
            }
            set
            {
                precio = value;
            }
        }


        public string UrlImagen { get; set; }
    }
}
