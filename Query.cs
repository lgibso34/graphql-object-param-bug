using HotChocolate.Types;

namespace github_object_bug
{
  [ExtendObjectType("Query")]
  public class MyQueries
  {
    public Person GetPerson() => new Person("Luke Skywalker");
  }

  public class Person
  {
    public Person(string name)
    {
      Name = name;
    }

    public string Name { get; }
  }
}
