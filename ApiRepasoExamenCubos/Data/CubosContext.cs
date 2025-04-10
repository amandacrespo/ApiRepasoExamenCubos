﻿using ApiRepasoExamenCubos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiRepasoExamenCubos.Data
{
    public class CubosContext: DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options) 
            : base(options) 
            {}
        public DbSet<Cubo> Cubos { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
