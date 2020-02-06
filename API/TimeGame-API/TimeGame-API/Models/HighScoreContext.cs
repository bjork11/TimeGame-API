using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TimeGame_API.Models
{
    public class HighScoreContext : DbContext
    {
        public HighScoreContext(DbContextOptions<HighScoreContext> options) : base(options)
        { }
        public DbSet<HighScoreItem> HighScoreItems { get; set; }
    }

}