namespace SystemRCP_CSV
{
    public class ReadFile
    {
        public static List<WorkDay> ReadFile1(string fileName)
        {
            var employees = new List<WorkDay>();

            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    var parts = line.Split(';');
                    if (parts.Length < 5) continue;

                    var employeeCode = parts[0];
                    var date = DateTime.Parse(parts[1]);
                    var startTime = TimeSpan.Parse(parts[2]);
                    var endTime = TimeSpan.Parse(parts[3]);

                    employees.Add(new WorkDay
                    {
                        EmployeeCode = employeeCode,
                        Date = date,
                        StartTime = startTime,
                        EndTime = endTime
                    });
                }
            }

            return employees;
        }


        public static List<WorkDay> ReadFile2(string fileName)
        {
            var employees = new List<WorkDay>();

            using (var reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split(';');
                    if (parts.Length < 4) continue;

                    if (!parts.Contains(string.Empty))
                    {
                        var employeeCode = parts[0];
                        var date = DateTime.Parse(parts[1]);
                        var time = TimeSpan.Parse(parts[2]);
                        var type = parts[3];

                        var workday = employees.FirstOrDefault(x => x.EmployeeCode == employeeCode && x.Date == date);
                        if (workday == null)
                        {
                            if (type == "WE")
                            {
                                workday = new WorkDay
                                {
                                    EmployeeCode = employeeCode,
                                    Date = date,
                                    StartTime = time
                                };
                                employees.Add(workday);
                            }
                        }
                        else
                        {
                            if (type == "WY")
                            {
                                workday.EndTime = time;
                            }
                        }
                    }
                }
            }

            return employees;
        }
    }
}
