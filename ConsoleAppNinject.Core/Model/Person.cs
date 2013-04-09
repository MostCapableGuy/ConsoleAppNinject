namespace ConsoleAppNinject.Core.Model
{
    public class Person : PersistentEntity
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Location { get; set; }
    }
}