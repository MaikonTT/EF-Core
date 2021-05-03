using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CursoEFCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using var db = new Data.ApplicationContext();
            var existe = db.Database.GetPendingMigrations().Any();

            if (existe)
            {
                Console.WriteLine("Existe migrações pendentes!");
            }
            else
            {
                Console.WriteLine("Não existe migrações pendentes!");
            }
        }
    }
}