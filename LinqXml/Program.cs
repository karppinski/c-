using System.Xml.Linq;

namespace LinqXml
{
    internal class Program
    {
        static void Main(string[] args)
        {

            XElement lastname = new XElement("lastname", "Bloggs");
            lastname.Add(new XComment("nice name"));

            XElement customer = new XElement("customer");
            customer.Add(new XAttribute("id", 123));
            customer.Add(new XElement("firstmane", "Joe"));
            customer.Add(lastname);

            XElement customer1 =
                new XElement("customer", new XAttribute("id", 123),
                new XElement("firstname", "joe"),
                new XElement("lastname","bloggins",
                    new XComment("nice name")
                    )
                );


            Console.WriteLine(customer.ToString());
            Console.WriteLine(customer1.ToString());

            var address = new XElement("address",
                new XElement("street", "Lawley St"),
                new XElement("town", "North Beach")
                );
        }
    }
}
