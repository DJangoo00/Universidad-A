using System.Globalization;
using System.Reflection;
using CsvHelper;
using CsvHelper.Configuration;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Persistence;

public class ApiContextSeed
{
    public static async Task SeedAsync(ApiContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            //inicio de las insersiones en la db
            var ruta = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            
            if (!context.RolesUsers.Any())
            {
                using (var reader = new StreamReader(ruta + @"\Data\Csv\RoleUser.csv"))
                {
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HeaderValidated = null, // Esto deshabilita la validación de encabezados
                        MissingFieldFound = null
                    }))
                    {
                        // Resto de tu código para leer y procesar el archivo CSV
                        var list = csv.GetRecords<RoleUser>();
                        List<RoleUser> entidad = new List<RoleUser>();
                        foreach (var item in list)
                        {
                            entidad.Add(new RoleUser
                            {
                                IdUserFk = item.IdUserFk,
                                IdRoleFk = item.IdRoleFk
                            });
                        }
                        context.RolesUsers.AddRange(entidad);
                        await context.SaveChangesAsync();
                    }
                }
            }
        //fin de las insersiones en la db
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiContext>();
            logger.LogError(ex.Message);
        }
    }
    public static async Task SeedRolesAsync(ApiContext context, ILoggerFactory loggerFactory)
    {
        try
        {
            if (!context.Roles.Any())
            {
                var roles = new List<Role>()
                        {
                            new Role{Id=1, Nombre="Administrador"},
                            new Role{Id=2, Nombre="Empleado"},
                        };
                context.Roles.AddRange(roles);
                await context.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            var logger = loggerFactory.CreateLogger<ApiContext>();
            logger.LogError(ex.Message);
        }
    }
}
