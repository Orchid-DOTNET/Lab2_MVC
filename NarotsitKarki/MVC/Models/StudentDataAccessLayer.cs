using MVC.Models;
using System.Data.SqlClient;
using System.Data;
namespace AccessLayer
{
    public class StudentDataAccessLayer
    {

           private string connection_string = "Data Source=(localdb)\\ProjectModels;Initial Catalog=student_db;Integrated Security=True;Connect Timeout=30;trusted_connection=True;Encrypt=False";
    

           public IEnumerable<Student> GetallStudents()
        {
           List<Student> student_list = new List<Student>();

            string Name, Section;
            int Id;
            using (SqlConnection conn = new SqlConnection(connection_string))
            {
                
                SqlCommand cmd = new SqlCommand("spGetAllStudents", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                
                while (reader.Read())
                {
                    Id = (int) reader["Id"];
                    Name = (string) reader["Name"];
                    Section = (string) reader["Section"];
          

                    Student student = new Student
                    {
                        Id = Id,Name = Name,Section = Section
                    };
                    student_list.Add(student);
                  
                }

                conn.Close();
            }

            return student_list;
        }

        public bool AddNewStudent(Student student)
        {
            using(SqlConnection conn = new SqlConnection(connection_string))
            {
                SqlCommand cmd = new SqlCommand("spAddNewStudent", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@Name",student.Name);
                cmd.Parameters.AddWithValue("@Section", student.Section);

                conn.Open();
                int affected_rows  = cmd.ExecuteNonQuery();
                conn.Close();
                if(affected_rows > 0)
                {
                    return true;
                }
                
                conn.Close();
            }
            return false;
        }

        public bool UpdateStudent(Student student)
        {
            using(SqlConnection conn = new SqlConnection(connection_string))
            {
                SqlCommand cmd = new SqlCommand("spUpdateStudent", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Section", student.Section);
                cmd.Parameters.AddWithValue("@Id", student.Id);
                conn.Open();
                int affected_rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (affected_rows > 0)
                {
                    return true;
                }

                conn.Close();
            }
            return false;
        }

        public  bool DeleteStudent(int Id)
        {
            using(SqlConnection conn = new SqlConnection(connection_string))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudent", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Id", Id);
                conn.Open();
                int affected_rows = cmd.ExecuteNonQuery();
                conn.Close();
                if (affected_rows > 0)
                {
                    return true;
                }

                conn.Close();
            }
            return false;
        }
     }
}
