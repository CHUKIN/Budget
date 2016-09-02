using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace Budget.Models
{
    public static class SampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetService<UserContext>();

            if (context.Cashs.Where(i=>i.Name=="Наличные").FirstOrDefault()==null)
            {
                context.Cashs.Add(new Cash { Name = "Наличные", Money = 0 });
                context.Units.Add(new Unit{Name="Килограмм"});
                context.Units.Add(new Unit{Name="Литр"});
                context.Units.Add(new Unit{Name="Шутк"});
                context.SaveChanges();
            }
        }
    }
}
