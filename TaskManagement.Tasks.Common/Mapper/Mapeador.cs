using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace TaskManagement.Tasks.Common.Mapper
{
    public static class Mapeador
    {
        public static object MapObjectByProperties(object source, object target)
        {
            foreach(PropertyInfo sourceProp in source.GetType().GetProperties())
            {
                PropertyInfo targetProps = target.GetType().GetProperties().Where(p => p.Name == sourceProp.Name).FirstOrDefault();
                if(targetProps != null && targetProps.GetType().Name == sourceProp.GetType().Name)
                {
                    targetProps.SetValue(target, sourceProp.GetValue(source));
                }
            }
            return target;
        }
    }
}