using HotChocolate.Types;

namespace github_object_bug
{
  [ExtendObjectType("Mutation")]
  public class MyMutations
  {
    public string TestMutation(string str) => str;
    public string BuggyMutation(object value) => "hello world";
  }

}
