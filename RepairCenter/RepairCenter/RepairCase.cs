namespace RepairCenter
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

        public int ConvertPriorityToInteger()
        {         
            switch (priority)
            {
                case "Low":
                    return  1;                    
                case "medium":
                    return 2;                   
                case "High":
                    return  3;                  
            }
            return 0;
        }
    }
}
