using EMprestimosLivros.Models;
using Microsoft.EntityFrameworkCore;

namespace EMprestimosLivros.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }
   
    public DbSet<EmprestimosModel> Emprestimos { get; set; }

    }

}
