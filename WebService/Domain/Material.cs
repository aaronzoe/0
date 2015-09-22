using System.Drawing;
using ServiceStack.DataAnnotations;

namespace WebService.Domain
{
    public class Material
    {
        [AutoIncrement]
        public int ID { get; set; }

        public int TypeID { get; set; }

        public decimal Amount { get; set; }

        public string Name { get; set; }

        public decimal Limit { get; set; }

        public Color Color {
            get
            {
                if (Amount<=Limit)
                {
                    return ColorTranslator.FromHtml("#DB4D6D");
                }
                if ((Amount - Limit)/ Limit < (decimal)0.1)
                {
                    return Color.DarkOrange;
                    
                }
                return Color.White;
            }
        }

        public string Unit { get; set; }
        public string TypeName { get; set; }
    }
}