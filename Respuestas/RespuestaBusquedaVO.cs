using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respuestas
{
    public class RespuestaBusquedaVO
    {
        public class Paging
        {
            [DefaultValue(0)]
            public int total { get; set; }
            [DefaultValue(0)]
            public int primary_results { get; set; }
            [DefaultValue(0)]
            public int offset { get; set; }
            [DefaultValue(0)]
            public int limit { get; set; }

        }
        public class Eshop
        {
            [DefaultValue("")]
            public string nick_name { get; set; }

            public Eshop_rubro e_Rubro { get; set; }
            [DefaultValue(0)] public int eshop_id { get; set; }
            //public Eshop_locations eshop_locations { get; set; }
            [DefaultValue("")]
            public string site_id { get; set; }
            [DefaultValue("")]
            public string eshop_logo_url { get; set; }
            [DefaultValue(0)]
            public int eshop_status_id { get; set; }
            [DefaultValue(0)]
            public int seller { get; set; }
            [DefaultValue(0)]
            public int eshop_experience { get; set; }

        }

        public class Eshop_locations
        {
            public state_Eshop_locations state { get; set; }
            public neighborhood_Eshop_locations neighborhood { get; set; }
            public country_Eshop_locations country { get; set; }
            public city_Eshop_locations city { get; set; }
        }

        public class state_Eshop_locations {[DefaultValue("")] public string id { get; set; } }
        public class neighborhood_Eshop_locations {[DefaultValue("")] public string id { get; set; } }
        public class country_Eshop_locations {[DefaultValue("")] public string id { get; set; } }
        public class city_Eshop_locations {[DefaultValue("")] public string id { get; set; } }



        public class Eshop_rubro
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }
            [DefaultValue("")] public string category_id { get; set; }

        }

        public class Ratings
        {
            [DefaultValue(0)]
            public double negative { get; set; }
            [DefaultValue(0)]
            public double positive { get; set; }
            [DefaultValue(0)]
            public double neutral { get; set; }

        }
        public class Transactions
        {
            [DefaultValue(0)]
            public int total { get; set; }
            [DefaultValue(0)]
            public int canceled { get; set; }
            [DefaultValue("")]
            public string period { get; set; }
            public Ratings ratings { get; set; }
            [DefaultValue(0)]
            public int completed { get; set; }

        }
        public class Claims
        {
            [DefaultValue(0)]
            public double rate { get; set; }
            [DefaultValue(0)]
            public int value { get; set; }
            [DefaultValue("")]
            public string period { get; set; }

        }
        public class Delayed_handling_time
        {
            [DefaultValue(0)]
            public double rate { get; set; }
            [DefaultValue(0)]
            public int value { get; set; }
            [DefaultValue("")]
            public string period { get; set; }

        }
        public class Sales
        {
            [DefaultValue("")]
            public string period { get; set; }
            [DefaultValue(0)]
            public int completed { get; set; }

        }
        public class Cancellations
        {
            [DefaultValue(0)]
            public double rate { get; set; }
            [DefaultValue(0)]
            public int value { get; set; }
            [DefaultValue("")]
            public string period { get; set; }

        }
        public class Metrics
        {
            public Claims claims { get; set; }
            public Delayed_handling_time delayed_handling_time { get; set; }
            public Sales sales { get; set; }
            public Cancellations cancellations { get; set; }

        }
        public class Seller_reputation
        {
            public Transactions transactions { get; set; }
            [DefaultValue("")]
            public string power_seller_status { get; set; }
            public Metrics metrics { get; set; }
            [DefaultValue("")]
            public string level_id { get; set; }

        }
        public class Seller
        {
            [DefaultValue(0)]
            public int id { get; set; }
            [DefaultValue("")]
            public string permalink { get; set; }
            [DefaultValue("")]
            public string registration_date { get; set; }
            [DefaultValue(false)]

            public bool car_dealer { get; set; }
            [DefaultValue(false)]
            public bool real_estate_agency { get; set; }
            [DefaultValue("")]
            public IList<string> tags { get; set; }
            public Eshop eshop { get; set; }
            public Seller_reputation seller_reputation { get; set; }

        }
        public class Conditions
        {
            [DefaultValue("")]
            public IList<string> context_restrictions { get; set; }
            [DefaultValue("")]
            public string start_time { get; set; }
            [DefaultValue("")]
            public string end_time { get; set; }
            [DefaultValue(false)]
            public bool eligible { get; set; }

        }
        public class Metadata
        {

        }
        public class Prices2
        {
            [DefaultValue("")]
            public string id { get; set; }
            [DefaultValue("")]
            public string type { get; set; }
            public Conditions conditions { get; set; }
            //[DefaultValue(0)]
            //public double amount { get; set; }
            [DefaultValue("")]
            //public string regular_amount { get; set; }
            //[DefaultValue("")]
            public string currency_id { get; set; }
            [DefaultValue("")]
            public string exchange_rate_context { get; set; }
            public Metadata metadata { get; set; }
            [DefaultValue("")]
            public string last_updated { get; set; }

        }
        public class Presentation
        {
            [DefaultValue("")]
            public string display_currency { get; set; }

        }

        public class Reference_prices
        {
            [DefaultValue("")]
            public string id { get; set; }
            [DefaultValue("")]
            public string type { get; set; }
            public Conditions conditions { get; set; }
            [DefaultValue(0)]
            public double amount { get; set; }
            [DefaultValue("")]
            public string currency_id { get; set; }
            [DefaultValue("")]
            public string exchange_rate_context { get; set; }
            [DefaultValue("")]
            public IList<string> tags { get; set; }
            [DefaultValue("")]
            public string last_updated { get; set; }

        }
        public class Prices
        {
            [DefaultValue("")] public string id { get; set; }
            public IList<Prices2> prices { get; set; }
            public Presentation presentation { get; set; }
            [DefaultValue("")]
            public IList<string> payment_method_prices { get; set; }
            public IList<Reference_prices> reference_prices { get; set; }
            [DefaultValue("")]
            public IList<string> purchase_discounts { get; set; }

        }
        public class Installments
        {
            [DefaultValue(0)]
            public int quantity { get; set; }
            [DefaultValue(0)]
            public double amount { get; set; }
            [DefaultValue(0)]
            public double rate { get; set; }
            [DefaultValue("")]
            public string currency_id { get; set; }

        }
        public class Address
        {

            [DefaultValue("")] public string state_id { get; set; }
            [DefaultValue("")] public string state_name { get; set; }
            [DefaultValue("")] public string city_id { get; set; }
            [DefaultValue("")] public string city_name { get; set; }

        }

        public class Shipping
        {
            [DefaultValue("")] public string free_shipping { get; set; }
            //[DefaultValue("")] public string mode { get; set; }
            //[DefaultValue("")] public IList<string> tags { get; set; }
            //[DefaultValue("")] public string logistic_type { get; set; }
            //[DefaultValue(false)] public bool store_pick_up { get; set; }
        }

        public class Country
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }

        }
        public class State
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }

        }
        public class City
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }

        }
        public class Seller_address
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string comment { get; set; }
            [DefaultValue("")] public string address_line { get; set; }
            [DefaultValue("")] public string zip_code { get; set; }
            public Country country { get; set; }
            public State state { get; set; }
            public City city { get; set; }
            [DefaultValue("")] public string latitude { get; set; }
            [DefaultValue("")] public string longitude { get; set; }

        }
        public class Values
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }
            [DefaultValue("")] public string structs { get; set; }
            [DefaultValue(0)] public long source { get; set; }

        }
        public class Attributes
        {
            [DefaultValue("")] public string attribute_group_id { get; set; }
            [DefaultValue("")] public string attribute_group_name { get; set; }
            [DefaultValue(0)] public long source { get; set; }
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }
            [DefaultValue("")] public string value_id { get; set; }
            [DefaultValue("")] public string value_name { get; set; }
            //[DefaultValue("")] public string value_struct { get; set; }
            public List<Values> values { get; set; }

        }
        public class Results
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string site_id { get; set; }
            [DefaultValue("")] public string title { get; set; }
            [DefaultValue(0)] public double price { get; set; }
            [DefaultValue("")] public string sale_price { get; set; }
            [DefaultValue("")] public string currency_id { get; set; }
            [DefaultValue(0)] public int available_quantity { get; set; }
            [DefaultValue(0)] public int sold_quantity { get; set; }
            [DefaultValue("")] public string buying_mode { get; set; }
            [DefaultValue("")] public string listing_type_id { get; set; }
            [DefaultValue("")] public string stop_time { get; set; }
            [DefaultValue("")] public string condition { get; set; }
            [DefaultValue("")] public string permalink { get; set; }
            [DefaultValue("")] public string thumbnail { get; set; }
            [DefaultValue("")] public string thumbnail_id { get; set; }
            [DefaultValue(false)] public bool accepts_mercadopago { get; set; }
            public Address address { get; set; }
            public IList<Attributes> attributes { get; set; }
            [DefaultValue("")] public string category_id { get; set; }
            public Shipping shipping { get; set;  }

        }
        public class Sort
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }

        }
        public class Available_sorts
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }

        }
        public class Values2
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }
            [DefaultValue(0)] public int results { get; set; }

        }

        public class Path_from_root
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }

        }
        public class Values3
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }
            public IList<Path_from_root> path_from_root { get; set; }

        }
        public class Filters
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }
            [DefaultValue("")] public string type { get; set; }
            public IList<Values3> values { get; set; }

        }

        public class Available_filters
        {
            [DefaultValue("")] public string id { get; set; }
            [DefaultValue("")] public string name { get; set; }
            [DefaultValue("")] public string type { get; set; }
            public IList<Values2> values { get; set; }

        }

        [DefaultValue("")] public string site_id { get; set; }
        [DefaultValue("")] public string query { get; set; }
        public Paging paging { get; set; }
        public List<Results> results { get; set; }
        [DefaultValue("")] public List<string> secondary_results { get; set; }
        [DefaultValue("")] public List<string> related_results { get; set; }
        public Sort sort { get; set; }
        public List<Available_sorts> available_sorts { get; set; }
        public List<Filters> filters { get; set; }
        //public List<Available_filters> available_filters { get; set; }
    }
}
