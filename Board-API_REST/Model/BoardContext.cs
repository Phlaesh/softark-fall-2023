// TodoContext.cs
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class BoardContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }

        public string DbPath { get; }

        public BoardContext(DbContextOptions<BoardContext> options)
              : base(options)
        {
            // Den her er tom. Men ": base(options)" sikre at constructor
            // på DbContext super-klassen bliver kaldt.
        }
    }
}

