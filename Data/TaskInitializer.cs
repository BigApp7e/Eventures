namespace Eventures.Data
{
    public static class TaskInitializer
    {
        public static WebApplication Seed(this WebApplication app)
        {
            using(var scope = app.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                try
                {
                    context.Database.EnsureCreated();

                    var users = context.users.FirstOrDefault();

                    if(users == null)
                    {
                        context.users.Add(

                            new Models.UserModel("admin", "admin", "admin@eventures.com", "Admin", "Admin", "1234", "Admin"));
                    }

                    context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
                return app;
            }
        }
    }
}
