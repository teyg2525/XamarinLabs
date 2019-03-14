using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace labs.Database
{
    class TaskComparer : IComparer<TaskModel>
    {
        public int Compare(TaskModel x, TaskModel y)
        {
            if(x.DateOfCreating > y.DateOfCreating)
            {
                return 1;
            }
            else if(x.DateOfCreating < y.DateOfCreating)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
