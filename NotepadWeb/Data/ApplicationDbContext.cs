using NotepadWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace NotepadWeb.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Notepad> Notepads { get; set; }
    }
}
