using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrettyPrint
{
    public class PrettyPrinter
    {
        public string Print(object something)
        {
            var className = something.GetType().Name;

            var properties = something.GetType().GetProperties();

            var output = new StringBuilder();
            output.AppendLine(className + ':');

            foreach (var property in properties)
            {
                if (property.PropertyType != typeof(string) && property.GetValue(something) is IEnumerable)
                {
                    output.AppendLine(property.Name + "[]:" + CountEnumerable(property.GetValue(something) as IEnumerable));    
                }
                else
                {
                    output.AppendLine(property.Name + ':' + property.GetValue(something));        
                }
            }

            return output.ToString();
        }

        private int CountEnumerable(IEnumerable e)
        {
            int count = 0;

            var enumerator = e.GetEnumerator();
            while (enumerator.MoveNext() == true)
            {
                count ++;
            }

            return count;
        }
    }
}
