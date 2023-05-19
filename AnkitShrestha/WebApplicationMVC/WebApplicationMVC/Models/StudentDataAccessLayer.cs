using MVC.Models;
using System.Data;
using System.Data.SqlClient;

namespace WebApplicationMVC.Models
{
    public class StudentDataAccessLayer
    {
        string connectionString = "Data Source=.;Initial Catalog=StudentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

        public IEnumerable<Student> GetAllStudent()
        {
            List<Student> lstStudent = new List<Student>();

            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand sqlCmd = new SqlCommand("Select * From Student", connection);

            sqlCmd.CommandType = CommandType.Text;

            connection.Open();

            SqlDataReader rdr = sqlCmd.ExecuteReader();

            while (rdr.Read())
            {
                Student student = new Student();

                student.Id = Convert.ToInt32(rdr["id"]);
                student.Name = rdr["Name"].ToString();
                student.Section = rdr["Section"].ToString();
                lstStudent.Add(student);
            }

            connection.Close();

            return lstStudent;
        }

        public void addStudent(Student student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCmd = new SqlCommand("spAddStudent", connection);
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.Parameters.AddWithValue("@Name", student.Name);
                sqlCmd.Parameters.AddWithValue("@Section", student.Section);
                connection.Open();
                sqlCmd.ExecuteNonQuery();
                connection.Close();

            }

        }


        public Student getStudentsById(int id)
        {
            Student newStudent = new Student();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand("Select * From Student WHERE id=" + id, connection);
            sqlCmd.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader rdr= sqlCmd.ExecuteReader();
            newStudent.Id = Convert.ToInt32(rdr["id"]);
            newStudent.Name = rdr["Name"].ToString();
            newStudent.Section = rdr["Section"].ToString();
            return newStudent;
        }

        public void editStudent(Student std)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand sqlCmd = new SqlCommand("Update s set s.Name="+std.Name +"s.Section="+std.Section+" Student s where s.id"+std.Id+, connection);
            sqlCmd.CommandType = CommandType.Text;
            connection.Open();
            connection.Close();

        }

        
    }
}
