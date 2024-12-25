namespace HackerRankPractice.Certificates.CSharp_Basics;

public class EmployeesManagement
{
    public static Dictionary<string, int> AverageAgeForEachCompany(List<Employee> employees)
    {
        var averageAgeForEachCompany = new Dictionary<string, int>();
        var companies = employees.Select(e => e.Company).Distinct().OrderBy(x => x).ToList();
        foreach (var company in companies)
        {
            averageAgeForEachCompany.Add(company,
                (int)Math.Round(employees.Where(e => e.Company == company).Average(x => x.Age)));
        }

        return averageAgeForEachCompany;
    }

    public static Dictionary<string, int> CountOfEmployeesForEachCompany(List<Employee> employees)
    {
        var countOfEmployees = new Dictionary<string, int>();
        var companies = employees.Select(e => e.Company).Distinct().OrderBy(x => x).ToList();
        foreach (var company in companies)
        {
            countOfEmployees.Add(company, employees.Count(x => x.Company == company));
        }

        return countOfEmployees;
    }

    public static Dictionary<string, Employee> OldestAgeForEachCompany(List<Employee> employees)
    {
        var oldestAgedEmployee = new Dictionary<string, Employee>();
        var companies = employees.Select(e => e.Company).Distinct().OrderBy(x => x).ToList();
        foreach (var company in companies)
        {
            var ownEmployees = employees.Where(e => e.Company == company).ToList();
            var oldestAge = ownEmployees.Max(y => y.Age);
            oldestAgedEmployee.Add(company, ownEmployees.First(x => x.Age == oldestAge));
        }

        return oldestAgedEmployee;
    }

    public static void EntryMethod()
    {
        // Here goes all the main method contents and test cases
        AverageAgeForEachCompany(new List<Employee>());
        CountOfEmployeesForEachCompany(new List<Employee>());
        OldestAgeForEachCompany(new List<Employee>());
    }
}

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Company { get; set; }
}