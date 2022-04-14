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
            return students.Find(s => s.Id == id);
        }

        public Student Add(Student item)
        {
            item.Id = _nextId++;
            students.Add(item);
            return item;
        }

        public void Remove(int id)
        {
            students.RemoveAll(s => s.Id == id);
        }

        public bool Update(Student item)
        {
            int index = students.FindIndex(s => s.Id == item.Id);

            students.RemoveAt(index);
            students.Add(item);
            return true;
        }
    }
}
