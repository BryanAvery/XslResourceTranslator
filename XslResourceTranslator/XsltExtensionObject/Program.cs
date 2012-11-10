using System;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;
using System.Threading;
using System.Globalization;
using Translator;

namespace ConsoleApplication9
{
    class Program
    {
        private const String _filename = "number.xml";
        private const String _stylesheet = "circle.xsl";
        private const String _culturename = "en";

        static void Main(string[] args)
        {
            Program test = new Program();
            Console.ReadLine();
        }

        public Program()
        {
            //Set the UI to the specified culture.
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(_culturename);

            //Create the XslTransform and load the stylesheet.
            //XslTransform xslt = new XslTransform();
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(_stylesheet);

            //Load the XML data file.
            XPathDocument doc = new XPathDocument(_filename);

            //Create an XsltArgumentList.
            XsltArgumentList xslArg = new XsltArgumentList();

            //Add an object to get the resources for the specified language.
            ResourceTranslator resTran = new ResourceTranslator("Resources.Resource");
            xslArg.AddExtensionObject("urn:myResTran", resTran);

            //Add an object to calculate the circumference of the circle.
            Calculate obj = new Calculate();
            xslArg.AddExtensionObject("urn:myObj", obj);

            //Create an XmlTextWriter to output to the console.             
            XmlTextWriter writer = new XmlTextWriter(Console.Out);

            //Transform the file.
            xslt.Transform(doc, xslArg, writer, null);

            writer.Close();
        }

        //Calculates the circumference of a circle given the radius.
        public class Calculate
        {
            public static double Circumference(double radius)
            {
                return Math.PI * 2 * radius;
            }
        }
    }
}
