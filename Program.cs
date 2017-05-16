using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{

    class Customer
    {
        string freight;
        DateTime orderDate;
        decimal customerID;
        string companyName;

        public Customer(string freight, DateTime orderDate, decimal customerID, string companyName)
        {
            this.freight = freight;
            this.orderDate = orderDate;
            this.customerID = customerID;
            this.companyName = companyName;
        }

        public string CompanyName
        {
            get { return companyName;  }
            set { companyName = value;  }
        }

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }


        public override string ToString()
        {
            return String.Format("{0}     {1}    {2}    {3}", freight, orderDate, customerID, companyName);
        }
    }

    class CustomerList
    {
        Customer[] M;
        int count;

        public CustomerList(int count)
        {
            M = new Customer[count];
        }

        public int Count
        {
            get { return count; }
        }

        public int Capacity
        {
            get
            {
                return M.Length;
            }

            set
            {
                if (value < count) value = count;
                if(value != M.Length)
                {
                    Customer[] newM = new Customer[value];
                    Array.Copy(M, 0, newM, 0, count);
                }
            }
        }

        public Customer this[int index]
        {
            get
            {
                return M[index];
            }

            set
            {
                M[index] = value;
            }
        }

        public void Add(Customer item)
        {
            if (count == Capacity) Capacity = count * 2;
            M[count] = item;
            count++;
        }

        public static CustomerList addList(CustomerList obj1, CustomerList obj2, string comName)
        {
            int counter = 0;

            for(int i = 0; i < obj1.Count; i++)
            {
                if (obj1[i].CompanyName == comName) counter++;
            }

            for (int i = 0; i < obj2.Count; i++)
            {
                if (obj2[i].CompanyName == comName) counter++;
            }

            CustomerList resultList = new CustomerList(counter);

            for (int i = 0; i < obj1.Count; i++)
            {
                if (obj1[i].CompanyName == comName) resultList.Add(obj1[i]);
            }

            for (int i = 0; i < obj2.Count; i++)
            {
                if (obj2[i].CompanyName == comName) resultList.Add(obj2[i]);
            }

            Customer t;

            for(int i = 0; i < resultList.Count; i++)
            {
                for(int j = 0; j < resultList.Count - i - 1; j++)
                {
                    if(resultList[j].OrderDate < resultList[j+1].OrderDate)
                    {
                        t = resultList[j];
                        resultList[j] = resultList[j+1];
                        resultList[j + 1] = t;
                    }
                }
            }

            return resultList;

        }
        
    }




    class Program
    {
        static void Main(string[] args)
        {
            CustomerList listFirst = new CustomerList(5);
            CustomerList listSecond = new CustomerList(5);

            Customer one = new Customer("CHM", new DateTime(12, 3, 5), 228, "Danon");
            Customer two = new Customer("CHM", new DateTime(10, 3, 2), 228, "Legacy");
            Customer three = new Customer("CHM", new DateTime(10, 3, 5), 228, "Danon");
            Customer four = new Customer("CHM", new DateTime(12, 3, 5), 228, "Freelance");
            Customer five = new Customer("CHM", new DateTime(12, 3, 5), 228, "Cambridge");

            listFirst.Add(one);
            listFirst.Add(two);
            listSecond.Add(three);
            listSecond.Add(four);
            listSecond.Add(five);

            CustomerList resultList = CustomerList.addList(listFirst, listSecond, "Danon");

            for(int i = 0; i < resultList.Count; i++)
            {
                Console.WriteLine(resultList[i]);
            }
        }
    }
}
