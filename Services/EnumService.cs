using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace CrudVeiculos.Services
{
    public interface IEnumService
    {
        Dictionary<string, List<EnumDto>> GetAllEnums();
    }

    public class EnumService : IEnumService
    {
        public Dictionary<string, List<EnumDto>> GetAllEnums()
        {
            var result = new Dictionary<string, List<EnumDto>>();

            // Pega todos os tipos enum do seu assembly de entidades (ou de todos aqui, se preferir)
            var enums = Assembly.GetExecutingAssembly()
                                .GetTypes()
                                .Where(t => t.IsEnum);

            foreach (var e in enums)
            {
                var list = new List<EnumDto>();
                foreach (var val in Enum.GetValues(e))
                {
                    var mem = e.GetMember(val.ToString()).First();
                    // Se existir DisplayAttribute, usa a descrição; senão, o nome do membro
                    var display = mem.GetCustomAttribute<DisplayAttribute>()?.Name ?? val.ToString();

                    list.Add(new EnumDto
                    {
                        Name = val.ToString(),
                        Value = (int)val,
                        Description = display
                    });
                }
                result.Add(e.Name, list);
            }

            return result;
        }
    }

    public class EnumDto
    {
        public string Name { get; set; } = null!;
        public int Value { get; set; }
        public string Description { get; set; } = null!;
    }
}
