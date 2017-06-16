﻿namespace RepairCenter
{
    public class RepairCase
    {
        private string caseName;
        private string priority;
        public RepairCase(string caseName,string priority)
        {
            this.caseName = caseName;
            this.priority = priority;
        }

        public int GetPriorityInInt()
        {         
            switch (priority)
            {
                case "Low":
                    return 1;                    
                case "Medium":
                    return 2;                   
                case "High":
                    return 3;                  
            }
            return 0;
        }
    }
}
