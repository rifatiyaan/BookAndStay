using BookAndStay.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookAndStay.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Amenity> Amenities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                RoomType = "Standard Room",
                Price = 100,
                Description = "A basic accommodation option with essential amenities. Standard rooms are usually more affordable and cater to guests looking for a comfortable yet budget-friendly stay.",
                Occupancy = 2,
                ImageUrl = "aa"

            },
            new Category
            {
                Id = 2,
                RoomType = "Deluxe Room",
                Price = 300,
                Description = "An upgraded and more spacious room category compared to the standard room. Deluxe rooms often feature larger beds, higher-quality furnishings, and additional amenities for enhanced comfort. Guests choosing a deluxe room can enjoy a more luxurious experience without opting for a full suite.",
                Occupancy = 2,
                ImageUrl = "aa"
            },
            new Category
            {
                Id = 3,
                RoomType = "Suit",
                Price = 100,
                Description = "A suite is a larger and more luxurious accommodation option that goes beyond the features of a standard or deluxe room. It usually consists of a separate living area and bedroom, providing more space for relaxation and work. Suites may include additional amenities such as a mini-kitchen, dining area, and upgraded in-room facilities.",
                Occupancy = 2,
                ImageUrl = "aa"
            },
            new Category
            {
                Id = 4,
                RoomType = "VIP Suite",
                Price = 100,
                Description = "The VIP Suite represents the pinnacle of luxury in a hotel.It is designed for high - profile guests, celebrities, or those seeking an exclusive and opulent experience.VIP Suites often feature a spacious living room, a master bedroom, a dining area, and may include special services such as a personal concierge.These suites are characterized by top - notch amenities, premium furnishings, and a high level of privacy.",
                Occupancy = 2,
                ImageUrl = "aa"
            });


            modelBuilder.Entity<Room>().HasData(

                new Room
                {
                    Room_Number = 101,
                    Room_ID = 1,

                },
                new Room
                {
                    Room_Number = 102,
                    Room_ID = 2,

                },
                new Room
                {
                    Room_Number = 103,
                    Room_ID = 3,

                });

            modelBuilder.Entity<Amenity>().HasData(

                new Amenity
                {
                    Id = 1,
                    Name = "Air Conditioner",
                    CategoryId = 1
                },
                new Amenity
                {
                    Id = 2,
                    Name = "Tv",
                    CategoryId = 2
                });
        }

    }
}
