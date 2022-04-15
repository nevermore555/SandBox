using SandBox.Entities;

namespace SandBox.Repositories
{
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();
        private int _nextId = 1;

        public StudentRepository()
        {
            Add(new Student { Name = "Alex"});
            Add(new Student { Name = "Jack"});
            Add(new Student { Name = "Finn"});
        }

        public List<Student> GetAll()
        {
            return students;
        }

        public Student Get(int id)
        {
            if (students.FindIndex(s => s.Id == id) == -1)
            {
                throw new Exception($"ID \"{id}\" not found");
            }
            return students.Find(s => s.Id == id);
        }

        public bool Add(Student item)
        {

            if (item.Name is null)
            {
                return false;
            }

            item.Id = _nextId++;
            students.Add(item);

            return true;
        }

        public bool Remove(int id)
        {
            if (students.FindIndex(s => s.Id == id) == -1)
            {
                return false;
            }

            students.RemoveAll(s => s.Id == id);

            return true;
        }

        public bool Update(Student item)
        {
            int index = students.FindIndex(s => s.Id == item.Id);
            if (index == -1 || item.Name is null)
            {
                return false;
            }

            students.RemoveAt(index);
            students.Add(item);

            return true;
        }
    }
}
