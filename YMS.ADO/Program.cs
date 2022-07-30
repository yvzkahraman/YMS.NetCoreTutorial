// See https://aka.ms/new-console-template for more information
using System.Data.SqlClient;
using YMS.ADO;

Console.WriteLine("Hello, World!");
SqlConnection con = new SqlConnection("server=(localdb)\\mssqllocaldb; database =YMSNetTutorial; integrated security=true;");

con.Open();
SqlCommand command = new SqlCommand("select * from Employees", con);
var reader = command.ExecuteReader();
List<Employee> employees = new List<Employee>();


while (reader.Read())
{
    Employee emp = new Employee();
    emp.Id = int.Parse(reader["Id"].ToString());

    //reader.IsDBNull(0) ? 0 : int.Parse(reader[0].ToString());
    emp.Name = reader["Name"].ToString();
    emp.Surname = reader["Surname"].ToString();
    employees.Add(emp);
}

reader.Close();
con.Close();

Console.WriteLine("Çalışan Listesi :");
employees.ForEach(x =>
{
    global::System.Console.WriteLine($"{x.Id} Name: {x.Name} Surname :{x.Surname}");
});


//SqlCommand command2 = new SqlCommand("Insert into Employees values (@Name,@Surname)",con);
//SqlParameter parameter = new SqlParameter("Name", emp.Id);

