namespace EntityFrameworkExercise
{
    using System;
    using EntityFrameworkExercise.Data;
    public class Startup
    {
        static void Main(string[] args)
        {
            var context = new BookShopContext();
            context.Database.EnsureCreated();
        }
    }
}
