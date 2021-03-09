# Simple Web Api with bemol

Project Setup

```cs
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
```
Simulating Retriving Data From Database

```cs
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
```

Start the Server

```cs
App app = new App().Start(5000);
```
Puplate Data From the Database
```cs
var personList = PopulatePersonList();
```
Simple GET Response
```cs
app.Get("/",(cxt)=>{
    cxt.Json(personList);
});

app.Get("/:id",(cxt)=>{
    int id=cxt.PathParam<int>("id");
    cxt.Json(personList.FirstOrDefault(x=>x.Id==id));
});
```
Simple POST Request
```cs
app.Post("/",(cxt)=>{
    Person person=cxt.Body<Person>();
    personList.Add(person);
    cxt.Json(person);
});
```