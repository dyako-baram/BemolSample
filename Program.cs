using System;
using System.Collections.Generic;
using System.Linq;
using Bemol;

namespace BemolSample
{
    class Program
    {
        static void Main(string[] args)
        {
            App app=new App().Start(5000);
            var personList=PopulatePersonList();

            app.Get("/",(x)=>{
                x.Json(personList);
            });

            app.Get("/:id",(x)=>{
                int id=x.PathParam<int>("id");
                x.Json(personList.FirstOrDefault(x=>x.Id==id));
            });

        }
        public static List<Person> PopulatePersonList()
        {
            return new List<Person>{
                new Person(1,"john",25),
                new Person(2,"jane",34),
                new Person(3,"bob",12),
                new Person(4,"jake",45),
                new Person(5,"doe",22),
                new Person(6,"sam",11),
                new Person(7,"drake",26),
                new Person(8,"naithen",66)
            };
        }
        
    }
    public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public Person(int id,string name,int age)
            {
                Id=id;
                Name=name;
                Age=age;
            }
        }
}
