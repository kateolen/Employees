using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseEmployeesApp
{

    public static class Logger
    {
        public static void WriteLog(string errorMessage, Action displayErrorToUser)
        {
            System.IO.File.WriteAllText("errorlog.txt", errorMessage);

            displayErrorToUser();
        }
    }
}
