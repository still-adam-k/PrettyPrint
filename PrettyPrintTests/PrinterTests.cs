using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using PrettyPrint;

namespace PrettyPrintTests
{
    public class PrinterTests
    {
        class TestObject
        {
            public string SomeProperty { get; set; }
            public string NextProperty { get; set; }

            public string[] SomeCollection { get; set; }

        }

        [Fact]
        public void Print__prints_objects_class_name()
        {
            var subject = new PrettyPrinter();
            var something = new TestObject();

            string result = subject.Print(something);
            result.Should().StartWith("TestObject");
            
            Console.WriteLine(result);
        }

        
        [Fact]
        public void Print__prints_object_properties_with_value()
        {
            var subject = new PrettyPrinter();
            var something = new TestObject();
            something.SomeProperty = "Property Content";

            var s = subject.Print(something);

            Console.WriteLine(s);
            s.Should().Contain("SomeProperty:Property Content");
        }

        [Fact]
        public void Print__prints_all_properties_with_values()
        {
            var subject = new PrettyPrinter();
            var something = new TestObject();
            something.SomeProperty = "Property Content";
            something.NextProperty = "Next Content";

            var s = subject.Print(something);

            Console.WriteLine(s);
            s.Should().Contain("SomeProperty:Property Content");
            s.Should().Contain("NextProperty:Next Content");
        }

        [Fact]
        public void Print__property_is_a_collection_writes_collection_count()
        {
            var subject = new PrettyPrinter();
            var something = new TestObject();

            something.SomeCollection = new[] {""};

            var s = subject.Print(something);

            Console.WriteLine(s);
            s.Should().Contain("SomeCollection[]:1");
        }

    }
}
