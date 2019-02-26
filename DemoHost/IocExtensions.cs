using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Demo.IService;
using Demo.Service;
using Demo.Core.IReposotory;
using Demo.EntitFrameworkCore.Reposotory;
using Microsoft.EntityFrameworkCore;

namespace Demo.Host
{
    public static class IocExtensions
    {
        public static void AddAssmbles(this IServiceCollection services, bool isDevelopment, params string[] assmbleNames)
        {


            var types = GetTypes(isDevelopment, assmbleNames);
            foreach (var item in types)
            {
                foreach (var val in item.Value)
                {
                    //var aa=val;
                    //var bb= item.Key;
                    //var a = typeof(IPersonService);
                    //var b = typeof(PersonService);
                    //services.AddTransient(val.IsGenericType ? val.GetType() : val, item.Key.IsGenericType ? item.Key.GetType() : item.Key);
                    services.AddTransient( val,item.Key);
                }
            }

            //services.AddTransient<IPersonService, PersonService>();
            //services.AddTransient(typeof(IPersonService), typeof(PersonService));
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        }

        private static Dictionary<Type, List<Type>> GetTypes(bool isDevelopment, params string[] assmbleNames)
        {
            var dic = new Dictionary<Type, List<Type>>();

            foreach (var assmbleName in assmbleNames)
            {
                var path = assmbleName;
                if (isDevelopment)
                {
                    path = "bin/Debug/netcoreapp2.2/" + assmbleName;
                }
                var assmble = Assembly.LoadFrom(path);
                var types = assmble.GetTypes().Where(r => !r.IsInterface&&!r.IsGenericType);
                foreach (var type in types)
                {
                    if (type == typeof(DemoContext)) continue;

                    if (type.GetInterfaces().Count() > 0)
                    {
                        AddDic(dic, type, type.GetInterfaces());
                    }
                    else
                    {
                        if (type.BaseType != typeof(object))
                            AddDic(dic, type, type.BaseType);
                    }
                }
            }
            return dic;
        }


        private static void AddDic(Dictionary<Type, List<Type>> dic, Type key, Type[] values)
        {
            if (!dic.ContainsKey(key))
            {
                dic.Add(key, values.ToList());
            }
            else
            {
                dic[key].AddRange(values);
            }
        }
        private static void AddDic(Dictionary<Type, List<Type>> dic, Type key, Type value)
        {
            if (!dic.ContainsKey(key))
            {
                var values = new List<Type>();
                values.Add(value);
                dic.Add(key, values);
            }
            else
            {
                dic[key].Add(value);
            }
        }




    }
}
