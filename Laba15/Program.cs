using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;

namespace Laba15
{
    class Company
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Adres { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader str = new StreamReader("C:/Users/raush/source/repos/Laba15/Laba15/strings.txt");
            List<Company> companies = new List<Company>();
            string S = str.ReadLine();
            while(S!=null)
            {
                companies.Add(new Company() { Name = S, Type=str.ReadLine(), Adres=str.ReadLine()});
                S = str.ReadLine();

            }


            IEnumerable<Company> companies1 = from comp in companies where comp.Type=="Shoes shop" || comp.Type=="Clothes shop" select comp;
            foreach (var t in companies1)
            {
                Console.WriteLine(t.Name + " " + t.Type + " " + t.Adres);
            }


            var companies2 = from u in companies where u.Type == "Shoes shop" select new{Name = u.Name, Adres=u.Adres};
            Console.WriteLine("\nNew list:\n");
            foreach (var t in companies2)
            {
                Console.WriteLine(t.Name + " " + t.Adres);
            }


            var companies3 = from comp in companies orderby comp.Adres, comp.Name select comp;
            Console.WriteLine("\nSorted by adres and name:\n");
            foreach (var t in companies3)
            {
                Console.WriteLine(t.Name + " " + t.Adres);
            }


            var companies56 = from comp in companies group comp by comp.Type;
            foreach (IGrouping<string, Company> comp in companies56)
            {
                Console.WriteLine("\n" + comp.Key + ":");
                foreach (var t in comp)
                {
                    Console.Write(" " + t.Name + ", " + t.Adres + "; ");
                }
            }


            var compsnies4 = from comp in companies group comp by comp.Type;
            foreach (IGrouping<string, Company> comp in compsnies4)
            {
                int n = 0;
                Console.WriteLine("\n"+comp.Key+":");
                foreach (var t in comp)
                {
                    Console.Write(" " + t.Name + ", " + t.Adres + "; ");
                    n++;
                }
                Console.WriteLine("\nNumber of "+comp.Key+": "+n);
            }


            int number = (from comp in companies where comp.Type == "Grocery shop" select comp).Count();
            Console.WriteLine("\n\nNumber of grocery: "+number);


            var companies5 = companies.TakeWhile(comp=>comp.Type=="Clothes shop" || comp.Type=="Shoes shop");
            foreach (var companies6 in companies.TakeWhile(comp => comp.Type == "Clothes shop" || comp.Type == "Shoes shop"))
                Console.WriteLine("\n"+companies6.Name+" "+companies6.Type+" "+companies6.Adres);
            bool result = companies.Any(comp => comp.Type=="Jewelry shop");
            if (result)
                Console.WriteLine("\nThere are jewelry shop\n");
            else
                Console.WriteLine("\nNo jewelry shops\n");


            StreamReader str1 = new StreamReader("C:/Users/raush/source/repos/Laba15/Laba15/string2.txt");
            List<Company> companies_2 = new List<Company>();
            string S2 = str1.ReadLine();
            while (S2 != null)
            {
                companies_2.Add(new Company() { Name = S2, Type = str1.ReadLine(), Adres = str1.ReadLine() });
                S2 = str1.ReadLine();

            }
            var NewCompanies = companies.Union(companies_2);
            foreach (var t in NewCompanies)
            {
                Console.WriteLine(t.Name + " " + t.Type + " " + t.Adres);
            }
        }
    }
}
