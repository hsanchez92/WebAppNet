using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respuestas
{
    public class RespuestaDetalleProductoVO
    {

        public class Values
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }
            [DefaultValue("")] public List<string> structs { get; set; }

        }
        public class Sale_terms
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }
            [DefaultValue("")] public string value_id { get; set; }
            [DefaultValue("")] public string value_name { get; set; }
            public List<Values> values { get; set; }

        }
        public class Pictures
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string url { get; set; }
            [DefaultValue("")] public string secure_url { get; set; }
            [DefaultValue("")] public string size { get; set; }
            [DefaultValue("")] public string max_size { get; set; }
            [DefaultValue("")] public string quality { get; set; }

        }
        public class Descriptions
        {
            [DefaultValue("")] public string id { get; set; }

        }
        public class Shipping
        {
            [DefaultValue("")] public string mode { get; set; }
            [DefaultValue("")] public List<string> methods { get; set; }
            [DefaultValue("")] public List<string> tags { get; set; }
            [DefaultValue("")] public List<string> dimensions { get; set; }
            [DefaultValue(false)] public bool local_pick_up { get; set; }
            [DefaultValue(false)] public bool free_shipping { get; set; }
            [DefaultValue("")] public string logistic_type { get; set; }
            [DefaultValue(false)] public bool store_pick_up { get; set; }

        }
        public class City2
        {
            [DefaultValue("")] public string name { get; set; }

        }
        public class State
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }

        }
        public class Country
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }

        }
        public class City
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }

        }
        public class State2
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }

        }
        public class Search_location
        {
            public City city { get; set; }
            public State state { get; set; }

        }
        public class Seller_address
        {
            public City2 city { get; set; }
            public State2 state { get; set; }
            public Country country { get; set; }
            public Search_location search_location { get; set; }
            [DefaultValue(0)] public int id { get; set; }

        }
        public class Location
        {

        }

        public class Attributes
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }
            [DefaultValue("")] public string value_id { get; set; }
            [DefaultValue("")] public string value_name { get; set; }
            //[DefaultValue("")] public List<string> value_struct { get; set; } = null;
            public List<Values> values { get; set; }
            [DefaultValue("")] public string attribute_group_id { get; set; }
            [DefaultValue("")] public string attribute_group_name { get; set; }

        }
        public class Attribute_combinations
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }
            [DefaultValue("")] public string value_id { get; set; }
            [DefaultValue("")] public string value_name { get; set; }
            [DefaultValue("")] public List<string> value_struct { get; set; }
            public List<Values> values { get; set; }

        }
        public class Variations
        {
            [DefaultValue(0)] public long id { get; set; }
            [DefaultValue(0)] public double price { get; set; }
            public List<Attribute_combinations> attribute_combinations { get; set; }
            [DefaultValue(0)] public int available_quantity { get; set; }
            [DefaultValue(0)] public int sold_quantity { get; set; }
            [DefaultValue("")] public List<string> sale_terms { get; set; }
            [DefaultValue("")] public List<string> picture_ids { get; set; }
            //[DefaultValue("")] public List<string> catalog_product_id { get; set; }

        }

        [DefaultValue("")] public string id { get; set; }
        [DefaultValue("")] public string site_id { get; set; }
        [DefaultValue("")] public string title { get; set; }
        [DefaultValue("")] public List<string> subtitle { get; set; }
        [DefaultValue(0)] public int seller_id { get; set; }
        [DefaultValue("")] public string category_id { get; set; }
        [DefaultValue("")] public string official_store_id { get; set; }
        [DefaultValue(0)] public double price { get; set; }
        [DefaultValue(0)] public double base_price { get; set; }
        [DefaultValue("")] public string currency_id { get; set; }
        [DefaultValue(0)] public int initial_quantity { get; set; }
        [DefaultValue(0)] public int available_quantity { get; set; }
        [DefaultValue(0)] public int sold_quantity { get; set; }
        public List<Sale_terms> sale_terms { get; set; }
        [DefaultValue("")] public string buying_mode { get; set; }
        [DefaultValue("")] public string listing_type_id { get; set; }
        [DefaultValue("")] public DateTime start_time { get; set; }
        [DefaultValue("")] public DateTime stop_time { get; set; }
        [DefaultValue("")] public string condition { get; set; }
        [DefaultValue("")] public string permalink { get; set; }
        [DefaultValue("")] public string thumbnail_id { get; set; }
        [DefaultValue("")] public string thumbnail { get; set; }
        [DefaultValue("")] public string secure_thumbnail { get; set; }
        public List<Pictures> pictures { get; set; }
        [DefaultValue("")] public string video_id { get; set; }
        public List<Descriptions> descriptions { get; set; }
        [DefaultValue(false)] public bool accepts_mercadopago { get; set; }
        [DefaultValue("")] public List<string> non_mercado_pago_payment_methods { get; set; }
        public Shipping shipping { get; set; }
        [DefaultValue("")] public string international_delivery_mode { get; set; }
        public Seller_address seller_address { get; set; }
        [DefaultValue("")] public List<string> seller_contact { get; set; }
        public Location location { get; set; }
        [DefaultValue("")] public List<string> coverage_areas { get; set; }
        public List<Attributes> attributes { get; set; }
        [DefaultValue("")] public List<string> warnings { get; set; }
        [DefaultValue("")] public string listing_source { get; set; }
        public List<Variations> variations { get; set; }
        [DefaultValue("")] public string status { get; set; }
        [DefaultValue("")] public List<string> sub_status { get; set; }
        [DefaultValue("")] public List<string> tags { get; set; }
        [DefaultValue("")] public string warranty { get; set; }
        [DefaultValue("")] public string domain_id { get; set; }
        [DefaultValue("")] public List<string> parent_item_id { get; set; }
        [DefaultValue("")] public List<string> differential_pricing { get; set; }
        [DefaultValue("")] public List<string> deal_ids { get; set; }
        [DefaultValue(false)] public bool automatic_relist { get; set; }
        [DefaultValue("")]public DateTime date_created { get; set; }
        [DefaultValue("")]public DateTime last_updated { get; set; }
        [DefaultValue(false)] public bool catalog_listing { get; set; }
        [DefaultValue("")] public List<string> channels { get; set; }
    }
}
