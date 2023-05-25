global using Microsoft.EntityFrameworkCore;

namespace CarRentalManagementSystemAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne(c => c.Car)
                .WithMany(b => b.Bookings)
                .HasForeignKey(ci => ci.CarId);

            modelBuilder.Entity<Booking>()
                .HasOne(c => c.Driver)
                .WithMany(b => b.Bookings)
                .HasForeignKey(ci => ci.DriverId);

            modelBuilder.Entity<Booking>()
                .HasOne(c => c.Customer)
                .WithMany(b => b.Bookings)
                .HasForeignKey(ci => ci.CustomerId);

            modelBuilder.Entity<Payment>()
                .HasOne(c => c.Booking)
                .WithMany(b => b.Payments)
                .HasForeignKey(bi => bi.BookingId);
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }


    }
}
