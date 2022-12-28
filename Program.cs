
using SystemRCP_CSV;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string currentDirectory = Directory.GetCurrentDirectory();

            var rcp1Files = Directory.GetFiles(currentDirectory, "rcp1*.csv");

            var rcp2Files = Directory.GetFiles(currentDirectory, "rcp2*.csv");

            var employees1 = new List<WorkDay>();
            foreach (var file in rcp1Files)
            {
                employees1 = ReadFile.ReadFile1(file);
            }

            var employees2 = new List<WorkDay>();
            foreach (var file in rcp2Files)
            {
                employees2 = ReadFile.ReadFile2(file);

            }

            var employees = employees1.Concat(employees2).ToList();

            employees = employees.OrderBy(x => x.EmployeeCode).ThenBy(x => x.Date).ToList();

            var workdays = new List<WorkDay>();

            foreach (var employee in employees)
            {
                var workday = workdays.FirstOrDefault(x => x.EmployeeCode == employee.EmployeeCode && x.Date == employee.Date);
                if (workday == null)
                {
                    workdays.Add(employee);
                }
            }

            foreach (var employee in employees)
            {
                Console.WriteLine($"Pracownik {employee.EmployeeCode}:");
                if (!(employee.EndTime < employee.StartTime))
                    Console.WriteLine($"{employee.Date:yyyy-MM-dd}: {employee.StartTime:hh\\:mm} - {employee.EndTime:hh\\:mm} ({employee.EndTime - employee.StartTime:hh\\:mm})\n");
                else
                {
                    employee.EndTime = employee.EndTime.Add(new TimeSpan(24, 0, 0));
                    Console.WriteLine($"{employee.Date:yyyy-MM-dd}: {employee.StartTime:hh\\:mm} - {employee.EndTime:hh\\:mm} ({employee.EndTime - employee.StartTime:hh\\:mm})\n");
                }

            }
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Brak uprawnień do odczytu plików." + ex.Message);
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine("Katalog nie został odnaleziony." + ex.Message);
        }
    }
}