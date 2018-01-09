using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BookShopApi.Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static void CopyProperties(this object source, object destination)
        {
            // Iterate the Properties of the destination instance and  
            // populate them from their source counterparts  
            PropertyInfo[] destinationProperties = destination.GetType().GetProperties();
            foreach (PropertyInfo destinationPi in destinationProperties)
            {
                PropertyInfo sourcePi = source.GetType().GetProperty(destinationPi.Name);
                destinationPi.SetValue(destination, sourcePi.GetValue(source, null), null);
            }
        }
    }
}
