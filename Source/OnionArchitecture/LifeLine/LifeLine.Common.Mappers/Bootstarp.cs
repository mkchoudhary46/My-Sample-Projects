using System;
using System.Linq;
using LifeLine.Common.Mappers.Mappers;

namespace LifeLine.Common.Mappers
{
    public class Bootstrap
    {
        /// <summary>
        /// Concrete class mapping implementation done here
        /// </summary>
        public static void InitMappingConfig()
        {
            var type = typeof(IMapper);
            var types = typeof(IMapper).Assembly.GetTypes()
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface).ToList();

            types.ForEach(t =>
            {
                var n = (IMapper)Activator.CreateInstance(t);
                n.CreateMap();
            });
        }
    }
}
