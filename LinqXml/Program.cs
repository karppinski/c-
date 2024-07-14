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



            var customer2 = new XElement("custmer2", address);
            var customer3 = new XElement("custmer3", address);

            customer2.Element("address").Element("street").Value = "Another St";
            Console.WriteLine(
                customer3.Element("address").Element("street").Value);

            var bench = new XElement("bench",
                new XElement("toolbox",
                    new XElement("handtool", "Hammer"),
                    new XElement("handtool", "Rasp")
                    ),
                new XElement("toolbox",
                    new XElement("handtool", "Saw"),
                    new XElement("powertool", "Nailgun")
                    ),
                new XComment("Be careful with the nailgun")
                );


            foreach (XNode node in bench.Nodes())
                Console.WriteLine(node.ToString(SaveOptions.DisableFormatting) + ".");


            foreach (XElement e in bench.Elements())
                Console.WriteLine(e.Name + "= "  + e.Value);

            IEnumerable<string> query =
                from toolbox in bench.Elements()
                where toolbox.Elements().Any(tool => tool.Value == "Nailgun")
                select toolbox.Value;

            foreach (string s in query)
            {
                Console.WriteLine(s);
            }

            IEnumerable<string> query1 =
                from toolbox in bench.Elements()
                from tool in toolbox.Elements()
                where tool.Name == "handtool"
                select tool.Value;


            foreach (string s in query1)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine();

            Console.WriteLine(bench.Descendants("handtool").Count());

            foreach(XNode node in bench.DescendantNodes())
                Console.WriteLine(node.ToString(/*SaveOptions.DisableFormatting*/));


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


            XElement setting = new XElement("settings",
                new XElement("timeout", 30)
                );

            setting.SetValue("blah");
            Console.WriteLine(setting.ToString());


            XElement items = new XElement("itmes",
                new XElement("one"),
                new XElement("three")
                );
            items.FirstNode.AddAfterSelf(new XElement("two")
                );


        }
    }
}
