using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopFive.Models
{
    public class Restaurant
    {
        public Restaurant(int rank)
        {
            RestaurantRanking = rank;
        }
        public int RestaurantRanking { get; }
        public string RestaurantName { get; set; }
        public string FavoriteDish { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; } = "Coming Soon";

        public static Restaurant[] GetRestaurants()
        {
            Restaurant r1 = new Restaurant(1)
            {
                RestaurantName = "Bombay House",
                FavoriteDish = null,
                Address = "463 N University Avenue",
                PhoneNumber = "8013736677",
                Website = "www.bombayhouse.com"
            };

            Restaurant r2 = new Restaurant(2)
            {
                RestaurantName = "Bam Bams BBQ",
                FavoriteDish = "Brisket or Ribs",
                Address = "1708 South State Street",
                PhoneNumber = "8012251324",
                Website = "www.bambamsbbq.com"
            };

            Restaurant r3 = new Restaurant(3)
            {
                RestaurantName = "Don Joaquin",
                FavoriteDish = "Carne Asada Burrito",
                Address = "150 W 1230 N St",
                PhoneNumber = "8014002894",
                Website = "www.donjoaquinsttacosprovo.com"
            };

            Restaurant r4 = new Restaurant(4)
            {
                RestaurantName = "Ruby River Steakhouse",
                FavoriteDish = "Anything with Steak",
                Address = "1454 S. University Ave.",
                PhoneNumber = "8013710648",
                Website = "www.rubyriver.com"
            };

            Restaurant r5 = new Restaurant(5)
            {
                RestaurantName = "Red Fuego",
                FavoriteDish = "Lomo Saltado",
                Address = "820 E 800 N",
                PhoneNumber = "8019609095"
            };

            return new Restaurant[] { r1, r2, r3, r4, r5 };
        }
    }

    public class OtherRestaurant
    {
        public string Name { get; set; }
        public string RestaurantName { get; set; }
        public string FavoriteDish { get; set; }
        public int PhoneNumber { get; set; }
    }

    public static class RestaurantStorage
    {
        private static List<OtherRestaurant> restaurants = new List<OtherRestaurant>();

        public static IEnumerable<OtherRestaurant> Restaurants => restaurants;

        public static void AddNewRestaurant(OtherRestaurant restaurant)
        {
            restaurants.Add(restaurant);
        }
    }
}
