using BAS_ASP.Data;
using BAS_ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAS_ASP.BusinessLogic
{
    public class TodoBL
    {
        DataContext dataContext = DataContext.Instance;

        public Todo GetTodoById(string id)
        {
            return dataContext.Users.SelectMany(t => t.todos).Where(t => t.id == id).FirstOrDefault();
        }
    }
}
