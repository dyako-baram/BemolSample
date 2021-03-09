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

            app.Get("/",(cxt)=>{
                cxt.Json(personList);
            });

            app.Get("/:id",(cxt)=>{
                int id=cxt.PathParam<int>("id");
                cxt.Json(personList.FirstOrDefault(x=>x.Id==id));
            });
            app.Post("/",(cxt)=>{
                Person person=cxt.Body<Person>();
                personList.Add(person);
                cxt.Json(person);
            });
        }
        public static List<Person> PopulatePersonList()
        {
            return new List<Person>{
                new Person(1,"john",25),
                new Person(2,"jane",34),
                new Person(3,"bob",12),
                new Person(4,"jake",45),
                new Person(5,"doe",22)
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
