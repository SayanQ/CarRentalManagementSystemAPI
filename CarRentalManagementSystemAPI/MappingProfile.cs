using AutoMapper;

namespace CarRentalManagementSystemAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Car, CarVM>();
            CreateMap<CarVM, Car>().ReverseMap();            
            CreateMap<Customer, CustomerVM>();
            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<Driver, DriverVM>();
            CreateMap<Driver, DriverVM>().ReverseMap();
            CreateMap<Employee, EmployeeVM>();
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<Booking, BookingVM>();
            CreateMap<Booking, BookingVM>().ReverseMap();
            CreateMap<Payment, PaymentVM>();
            CreateMap<Payment, PaymentVM>().ReverseMap();
        }
    }
}
