using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Buyer> buyers = Initializer.GenerateData().ToList();


            /* 1. Полные имена и количество машин у покупателей, чья зарплата больше 1000 */

            var sel = from t in buyers 
                                where t.Salary>1000 
                                select t;

          //  foreach (Buyer s in sel)
            //    Console.WriteLine(s.FirstName+"\n"+s.Cars.Count());


            /* 2. Имена покупателей, которые могут купить хотя бы один из своих автомобилей за одну зарплату 
                (если таких автомобилей несколько вывести первый из них) */

            var sel2 = from t in buyers 
                   from c in t.Cars
                       where c.Price<t.Salary 
                       select new
                   {
                      Name = t.FirstName,
                      nameCar = c.Model
                   } into g

                       group g by g.Name into gr
                       select new {
                           Name = gr.Key,
                           nameCar = from p in gr select p.nameCar
                       }
                   ; 


        //    foreach (var n in sel2)
          //      Console.WriteLine($"{n.Name} - {n.nameCar.First()}");

            /* 3. Названия улиц и фамилии покупателей живущих на ней(фамилии хранятся в одном свойстве через запятую) */

            var sel3 = from t in buyers 
                       select t;

           // foreach (var n in sel3)
             //   Console.WriteLine($"{n.FirstName} - {n.Address.Street}");

            /* 4. Имена покупателей, чья годовая зарплата меньше стоимости всех машин, 
                которыми он владеет и сумма на которую годовая зарплата меньше */


            var sel4 = from t in buyers 
                       
                       where (from c in t.Cars select c).Sum(i => i.Price) > t.Salary 
                       select t.FirstName
                  ;

            // foreach (var n in sel4)
            //   Console.WriteLine($"{n}");

            /* 5. Названия улиц и количество покупателей живущих на нечетной стороне каждой из улиц */

            var sel5 = from t in buyers 

                       where t.Address.Building % 2 != 0
                       select new {
                           name = t.FirstName,
                           street = t.Address.Street,
                       } 
                 ;
            //foreach (var n in sel5)
            // Console.WriteLine($"{n.name} - {n.street} ({sel5.Count()})");

            /* 6. Полные имена и полный адрес покупателей, владеющих хотя бы одной машиной не старше 2 лет */

            var sel6 = buyers
                .Where(b => b.Cars.Any())
                .Where(b => b.DateTime > 2019)
                .Select(g => new
                {
                    street = g.Address,
                    name = g.FirstName
                }) ;

                    foreach (var n in sel6)
                    Console.WriteLine($"{n.name} - {n.street} ");


                    /* 7. Топ 3 автомобилей по продажам: название модели и количество продаж */

                    var sel7 = (
                from t in buyers
                       from c in t.Cars
                       group c by c.Model into g
                       select new
                       { 
                          model = g.First().Model,
                          count = g.Count()
                       }
        ).Take (3);

            Console.WriteLine("7)");
            //foreach (var n in sel7)
                //Console.WriteLine ($"{n.model} - {n.count} ");


            /* 8. Названия улиц и названия моделей автомобилей, встречающихся у жильцов этой улицы
                (названия моделей хранятся в одном свойстве через запятую, и отсортированы по их количеству на этой улице) */
            var sel8 = buyers
         .Where(b => b.Cars.Any())
        .GroupBy(b => b.Address.Street)
        .Select(g => new {
            street = g.First().Address.Street,
            model = g.SelectMany(b => b.Cars).First().Model,
            count = g.SelectMany(b => b.Cars).Count()
        }).OrderBy(b => b.count);



            Console.WriteLine("8)");
            foreach (var n in sel8)
            Console.WriteLine($"{n.street} - {n.model} ({n.count}) ");


            /* 9. Полные имена, зарплаты и полный адрес покупателей не имеющих автомобилей */
            var sel9 = buyers
             .Where(b => !b.Cars.Any())
             .Select(b => new { b.FirstName, b.Salary, b.Address.Street });
           // foreach (var n in sel9)
               // Console.WriteLine($"{n.FirstName} - {n.Salary} - {n.Street}");




            /* 10. Фамилии покупателей, которые не имеют машин, но которые могут себе позволить за пол года, 
                откладывая по 20 % зарплаты, купить самый недорогой из проданных автомобилей */
            var sel10 = buyers
                .Where(b => !b.Cars.Any())
                .Where(b => b.Salary * 6 * 0.2 >= buyers.SelectMany(b => b.Cars).Min(c => c.Price))
                .Select(b => new { b.LastName });









            //11. Названия улиц и названия моделей самого дорогого и самого дешевого автомобиля на ней
            var sel11max = buyers.GroupBy(b => b.Address.Street).Select(g => new {Street = g.Key, Max = g.SelectMany(b => b.Cars).OrderByDescending(c => c.Price).FirstOrDefault()?.Model });
            var sel11min = buyers.GroupBy(b => b.Address.Street).Select(g => new {Street = g.Key, Min = g.SelectMany(b => b.Cars).OrderBy(c => c.Price).FirstOrDefault()?.Model });
            //var sel11 = sel11min.Join(sel11max, min => min.Street, max => max.Street, (min, max) => { Street = min.Street,Min = min.Min,Max = max.Max}
            //
           // var sel15_1 = buyers.SelectMany(b => b.Cars).GroupBy(c => c.Model).Select(g => new { Model = g.Key, Max = g.Max(p => p.Price) }):
           // var sel15_2 = buyers.SelectMany(b => b.Cars).GroupBy(c => c.Model).Select(g => new { Model = g.Key, Min = g.Min(p => p.Price) });
           // var sel15 = sel15_1.Join(sel15_2, max => max.Model, min => min.Model, (max, min) => new { Model = max.Model, Max = max.Max, Min = min.Min });
            /* 12. Фамилии покупателей и названия моделей автомобилей (строка через запятую), которых нет у соседей (соседями считаются один или два дома, находящиеся на той же стороне улицы)*/
          //  var sel12 = buyers
               // .Where (b => b.Cars.Any())
                //.Where (b => b.Address.Building % 2 > 0)
                //.OrderBy (b=> b.Address.Building)
               // .GroupBy (b=> b.Address.Street)
            //    .Select (b => new LinkedList <Buyer> (b))
               // .Aggregate (new List <object>(), (list,linred
               // ))

      }

   }
}
