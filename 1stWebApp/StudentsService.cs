
namespace _1stWebApp
{
    public class StudentsService : ICollectionService<Student>
    {
        MyList<Student> list = new MyList<Student>();

        public void add(Student elem)
        {
            list.add(elem);
        }

        public void remove(Student elem)
        {
            list.removeAt(list.indexOf(elem));
        }

        public string view(Student elem)
        {
            return $"Age: {elem.Age}\nName: {elem.Name}\n";
        }
    }
}
