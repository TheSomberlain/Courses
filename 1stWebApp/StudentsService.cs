
using System.Collections.Generic;

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
        public void removeAll(string name)
        {
           foreach(Student item in list)
            {
                if (item.Name == name) remove(item);
            }
        }


        public string view(Student elem)
        {
            return $"Age: {elem.Age}\nName: {elem.Name}\n\n";
        }
        public string viewAll()
        {
            string response = "";
            foreach (Student item in list)
            {
                response += view(item);
            };
            return response;
        }
        public IEnumerable<Student> GetStudents(string name)
        {
            foreach(Student student in list)
            {
                if (student.Name.Equals(name)) yield return student;
            }
        }
  
    }
}
