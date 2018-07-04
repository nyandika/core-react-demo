using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactCrudDemo.Models
{
    public class DataAccessLayer
    {
        CoreReactContext context = new CoreReactContext();

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return context.Employee.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record     
        public int AddEmployee(Employee employee)
        {
            try
            {
                context.Employee.Add(employee);
                context.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee    
        public int UpdateEmployee(Employee employee)
        {
            try
            {
                context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();

                return 1;
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee    
        public Employee GetEmployeeData(int id)
        {
            try
            {
                Employee employee = context.Employee.Find(id);
                return employee;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee    
        public int DeleteEmployee(int id)
        {
            try
            {
                Employee emp = context.Employee.Find(id);
                context.Employee.Remove(emp);
                context.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }
        }

        //To Get the list of Cities    
        public List<City> GetCities()
        {
            List<City> cities = new List<City>();
            cities = (from CityList in context.City select CityList).ToList();

            return cities;
        }
    }
}
