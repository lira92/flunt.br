using System.Text.RegularExpressions;
using Flunt.Br.Document.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Flunt.Br.Document
{
    internal class Phone : IValidate
    {

        public Phone()
        {
            this.format = null;
        }
        public Phone(string numberFormat)
        {
            var regex = new Regex(@"[0-9]+");
            var phonePattern = Regex.Replace(numberFormat, @"[0-9,?]+", m => { 
                var optionalsCount = m.Value.Split(new char[] { '?' }).Length - 1;
                var stringRegex = "";
                if(optionalsCount != 0)
                {
                    stringRegex += (m.Length - optionalsCount);
                    stringRegex += ",";
                    stringRegex += (optionalsCount + (m.Length - optionalsCount));
                }
                else
                {
                     stringRegex = m.Length.ToString();
                }
                return $@"\d{{{stringRegex}}}";
            });
            phonePattern = @"^" + Regex.Replace(phonePattern, @"(?:(?(1)(?!))(\+)|(?(2)(?!))(\()|(?(3)(?!))(\)))+", m => $@"\{m.Value}").Replace("-", @"\-").Replace(" ", @"\s") + "$";
            this.format = new Regex(phonePattern);
        }

        public bool Validate(string value)
        {
            if (this.format != null)
            {
                return this.format.IsMatch(value);
            }
            else
            {
                foreach (var regex in this.ListPhoneValidFormat)
                {
                    if (regex.IsMatch(value)) return true;
                }
                return false;
            }
        }

        private IReadOnlyCollection<Regex> ListPhoneValidFormat
        {
            get
            {
                return new List<Regex>
                {
                //(99) 9999-9999
                new Regex(@"^\(\d{2}\)\s\d{4}\-\d{4}"),
                //(99) 99999-9999
                new Regex(@"^\(\d{2}\)\s\d{5}-\d{4}$"),
                //(99)9999-9999
                new Regex(@"^\(\d{2}\)\d{4}-\d{4}$"),
                //(99)99999-9999
                new Regex(@"^\(\d{2}\)\d{5}-\d{4}$"),
                //999999-9999
                new Regex(@"^\d{6}\-\d{4}$"),
                //9999999-9999
                new Regex(@"^\d{7}\-\d{4}$"),
                //99999999999
                new Regex(@"^\d{11}$"),
                //9999999999
                new Regex(@"^\d{10}$"),
                //99 99999 9999
                new Regex(@"^\d{2}\s\d{5}\s\d{4}$"),
                //99 9999 9999
                new Regex(@"^\d{2}\s\d{4}\s\d{4}$"),
                //55(99) 9999-9999
                new Regex(@"^\d{2}\(\d{2}\)\s\d{4}\-\d{4}$"),
                //55(99) 99999-9999
                new Regex(@"^\d{2}\(\d{2}\)\s\d{5}\-\d{4}$"),
                //55(99)99999-9999
                new Regex(@"^\d{2}\(\d{2}\)\d{5}\-\d{4}$"),
                //55(99)9999-9999
                new Regex(@"^\d{2}\(\d{2}\)\d{4}\-\d{4}$"),
                //55999999-9999
                new Regex(@"^\d{2}\d{2}\d{4}\-\d{4}$"),
                //5599 99999 9999
                new Regex(@"^\d{4}\s\d{5}\s\d{4}$"),
                //5599 9999 9999
                new Regex(@"^\d{4}\s\d{4}\s\d{4}$"),
                //5599 9999 9999
                new Regex(@"^\d{4}\s\d{4}\s\d{4}$"),
                //55 (99) 9999-9999
                new Regex(@"^\d{2}\s\(\d{2}\)\s\d{4}\-\d{4}$"),
                //55 (99) 9999 9999
                new Regex(@"^\d{2}\s\(\d{2}\)\s\d{4}\s\d{4}$"),
                //55 (99) 99999-9999
                new Regex(@"^\d{2}\s\(\d{2}\)\s\d{5}\-\d{4}$"),
                //55 (99) 999999999
                new Regex(@"^\d{2}\s\(\d{2}\)\s\d{5}\d{4}$"),
                //55 (99)999999999
                new Regex(@"^\d{2}\s\(\d{2}\)\d{5}\d{4}$"),
                //55 (99)99999999
                new Regex(@"^\d{2}\s\(\d{2}\)\d{4}\d{4}$"),
                //55 (99)99999-9999
                new Regex(@"^\d{2}\s\(\d{2}\)\d{5}\-\d{4}$"),
                //55 (99)9999-9999
                new Regex(@"^\d{2}\s\(\d{2}\)\d{4}\-\d{4}$"),
                //55 999999-9999
                new Regex(@"^\d{2}\s\d{2}\d{5}\-\d{4}$"),
                //55 9999999-9999
                new Regex(@"^\d{2}\s\d{2}\d{5}\-\d{4}$"),
                //55 9999999 9999
                new Regex(@"^\d{2}\s\d{2}\d{5}\s\d{4}$"),
                //55 999999-9999
                new Regex(@"^\d{2}\s\d{2}\d{4}\-\d{4}$"),
                //55 999999 9999
                new Regex(@"^\d{2}\s\d{2}\d{4}\s\d{4}$"),
                //55 9999999999
                new Regex(@"^\d{2}\s\d{2}\d{4}\d{4}$"),
                //55 9999999999
                new Regex(@"^\d{2}\s\d{2}\d{4}\d{4}$"),
                //559999999999
                new Regex(@"^\d{2}\d{2}\d{4}\d{4}$"),
                //559999999999
                new Regex(@"^\d{2}\d{2}\d{4}\d{4}$"),
                //559999999-9999
                new Regex(@"^\d{2}\d{2}\d{5}\-\d{4}$"),
                //5599999999999
                new Regex(@"^\d{2}\d{2}\d{5}\d{4}$"),
                //559999999999
                new Regex(@"^\d{2}\d{2}\d{4}\d{4}$"),
                //55 99999999999
                new Regex(@"^\d{2}\s\d{2}\d{5}\d{4}$"),
                //55 99 9999 9999
                new Regex(@"^\d{2}\s\d{2}\s\d{4}\s\d{4}$"),
                //55 99 99999 9999
                new Regex(@"^\d{2}\s\d{2}\s\d{5}\s\d{4}$"),
                //+55(99) 9999-9999
                new Regex(@"^\+\d{2}\(\d{2}\)\s\d{4}\-\d{4}$"),
                //+55(99) 99999-9999
                new Regex(@"^\+\d{2}\(\d{2}\)\s\d{5}\-\d{4}$"),
                //+55(99)99999-9999
                new Regex(@"^\+\d{2}\(\d{2}\)\d{5}\-\d{4}$"),
                //+55(99)9999-9999
                new Regex(@"^\+\d{2}\(\d{2}\)\d{4}\-\d{4}$"),
                //+55999999-9999
                new Regex(@"^\+\d{2}\d{2}\d{4}\-\d{4}$"),
                //+559999999-9999
                new Regex(@"^\+\d{2}\d{2}\d{5}\-\d{4}$"),
                //+5599 99999 9999
                new Regex(@"^\+\d{4}\s\d{5}\s\d{4}$"),
                //+5599 9999 9999
                new Regex(@"^\+\d{4}\s\d{4}\s\d{4}$"),
                //+5599 9999 9999
                new Regex(@"^\+\d{4}\s\d{4}\s\d{4}$"),
                //+55 (99) 9999-9999
                new Regex(@"^\+\d{2}\s\(\d{2}\)\s\d{4}\-\d{4}$"),
                //+55 (99) 9999 9999
                new Regex(@"^\+\d{2}\s\(\d{2}\)\s\d{4}\s\d{4}$"),
                //+55 (99) 999999999
                new Regex(@"^\+\d{2}\s\(\d{2}\)\s\d{5}\d{4}$"),
                //+55 (99)999999999
                new Regex(@"^\+\d{2}\s\(\d{2}\)\d{5}\d{4}$"),
                //+55 (99)99999999
                new Regex(@"^\+\d{2}\s\(\d{2}\)\d{4}\d{4}$"),
                //+55 (99)99999-9999
                new Regex(@"^\+\d{2}\s\(\d{2}\)\d{5}\-\d{4}$"),
                //+55 (99)9999-9999
                new Regex(@"^\+\d{2}\s\(\d{2}\)\d{4}\-\d{4}$"),
                //+55 999999-9999
                new Regex(@"^\+\d{2}\s\d{2}\d{5}\-\d{4}$"),
                //+55 9999999-9999
                new Regex(@"^\+\d{2}\s\d{2}\d{5}\-\d{4}$"),
                //+55 9999999 9999
                new Regex(@"^\+\d{2}\s\d{2}\d{5}\s\d{4}$"),
                //+55 999999-9999
                new Regex(@"^\+\d{2}\s\d{2}\d{4}\-\d{4}$"),
                //+55 999999 9999
                new Regex(@"^\+\d{2}\s\d{2}\d{4}\s\d{4}$"),
                //+55 9999999999
                new Regex(@"^\+\d{2}\s\d{2}\d{4}\d{4}$"),
                //+55 9999999999
                new Regex(@"^\+\d{2}\s\d{2}\d{4}\d{4}$"),
                //+559999999999
                new Regex(@"^\+\d{2}\d{2}\d{4}\d{4}$"),
                //+559999999999
                new Regex(@"^\+\d{2}\d{2}\d{4}\d{4}$"),
                //+55 99999999999
                new Regex(@"^\+\d{2}\s\d{2}\d{5}\d{4}$"),
                //+55 99 99999 9999
                new Regex(@"^\+\d{2}\s\d{2}\s\d{5}\s\d{4}$"),
                //+55 99 9999 9999
                new Regex(@"^\+\d{2}\s\d{2}\s\d{4}\s\d{4}$"),
                //+55 (99) 99999-9999
                new Regex(@"^\+\d{2}\s\(\d{2}\)\s\d{5}\-\d{4}$"),
            };
            }

        }

        private Regex format { get; set; }
    }
}