using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respuestas
{
    public class RespuestaInicioVO
    {
        public class Rules
        {
            public IList<string> enabled_taxpayer_types { get; set; }
            public string begins_with { get; set; }
            public string type { get; set; }
            public int min_length { get; set; }
            public int max_length { get; set; }

        }
        public class Identification_types_rules
        {
            public string identification_type { get; set; }
            public IList<Rules> rules { get; set; }

        }
        public class Settings
        {
            public IList<string> identification_types { get; set; }
            public IList<string> taxpayer_types { get; set; }
            public IList<Identification_types_rules> identification_types_rules { get; set; }

        }
        public class Currencies
        {
            public string id { get; set; }
            public string symbol { get; set; }

        }
        public class Categories
        {
            public string id { get; set; }
            public string name { get; set; }

        }

        public string id { get; set; }
        public string name { get; set; }
        public string country_id { get; set; }
        public string sale_fees_mode { get; set; }
        public int mercadopago_version { get; set; }
        public string default_currency_id { get; set; }
        public string immediate_payment { get; set; }
        public IList<string> payment_method_ids { get; set; }
        public Settings settings { get; set; }
        public IList<Currencies> currencies { get; set; }
        public IList<Categories> categories { get; set; }
        public IList<string> channels { get; set; }
        //public RespuestaInicioVO respuestaInicioVO { get; set; }
    }
}
