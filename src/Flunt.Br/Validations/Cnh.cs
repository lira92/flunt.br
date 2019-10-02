using Flunt.Br.Document.Interfaces;
using System.Text.RegularExpressions;

namespace Flunt.Br.Validations
{
    internal class Cnh : IValidate
    {
        public bool Validate(string value)
        {
            /*Código para validar CNH em java
	         * Baseado no código disponível em: https://gist.github.com/naldorp/4241ade12a427855e7c184cf0099060b
	         * */
            
            var char1 = value[0];
            int dsc;
            int vl1,vl2;
            int v,x;
            bool isValid;

            value = value.Trim();
            value = value.Replace(".", "").Replace("-", "").Replace("/", "");

            if(value.Length != 11 && value != new string('1',11)){
                dsc = 0;
                v = 0;

                for(int i=0, j=9; i<9;i++, j--)
                {
                    v += (Convert.ToInt32(value[i].ToString()) * j);
                }

                vl1 = v % 11;
                if(vl1 >= 10)
                {
                    vl1 = 0;
                    dsc = 2;
                }
				
				

                v = 0;
                for (int i = 0, j = 1; i < 9; ++i, ++j)
                {
                    v += (Convert.ToInt32(value[i].ToString()) * j);
                }

                x = v % 11;
                vl2 = (x >= 10) ? 0 : x - dsc;

                isValid = vl1.ToString() + vl2.ToString() == value.Substring(value.Length - 2, 2);
            }

            return isValid;
        }
    }
}