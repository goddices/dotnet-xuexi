using Microsoft.EntityFrameworkCore;
using MySqlTest.LocalTest;
using MySqlTest.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace MySqlTest
{
    public class Program
    {

        public static void Main()
        {
            //consoledbContext dbctxt = new consoledbContext();

            //var query = dbctxt.Robots.AsQueryable().AsNoTracking();

            //var result = query.Where(x => x.Name.Contains("SD"));


            //Console.WriteLine(result.Count());
            //Console.ReadLine();


            MySqlDbContext dbctxt = new MySqlDbContext();

            var query = dbctxt.Set<MyRobots>().AsQueryable();
            query = query.OrderByDescending(x => x.Id);
            var result = query.Where(x => x.Name.Contains("aa"));

            var a = result.Count();
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }

    public static class WhereExtension
    {
        public static IQueryable<TSource> Where<TSource>(this IQueryable<TSource> source, Expression<Func<TSource, bool>> predicate)
            where TSource : IEntity
        {
            return source.Where(predicate);
        }

        public static bool Contains(this string source, string val)
        {
            return source.Contains(val, StringComparison.OrdinalIgnoreCase);
        }
    }
}
