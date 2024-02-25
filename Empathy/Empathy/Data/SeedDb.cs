using Empathy.Data.Entities;
using Empathy.Enums;
using Empathy.Helpers;

namespace Empathy.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            //Crea  la BD y aplica las migraciones
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckSedesAsync();
            await CheckRolesAsync();
            await CheckProceduresAsync();
            await CheckUserAsync("1067950681", "Juan Sebastian", "Cardona Serna", "jcardser@yopmail.com", "304 414 3038", "Villa hermosa", UserType.Admin);
            await CheckUserAsync("1230099", "ProPruebas", "professional", "propuebas@yopmail.com", "304 414 3038", "Villa hermosa", UserType.UserProfessional);
            await CheckUserAsync("1152713905", "Laura Valentina", "Lopera Londoño", "lvalel@yopmail.com", "301 388 74 94", "Manrique", UserType.User);
        }

        private async Task<User> CheckUserAsync(
            string document,
            string firstName,
            string lastName,
            string email,
            string phone,
            string address,
            UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }

            return user;
        }



        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
            await _userHelper.CheckRoleAsync(UserType.UserProfessional.ToString());
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Antioquia",
                            Cities = new List<City>() {
                                new City() { Name = "Medellín" },
                                new City() { Name = "Itagüí" },
                                new City() { Name = "Envigado" },
                                new City() { Name = "Bello" },
                                new City() { Name = "Rionegro" },
                            }
                        },
                        new State()
                        {
                            Name = "Bogotá",
                            Cities = new List<City>() {
                                new City() { Name = "Usaquen" },
                                new City() { Name = "Champinero" },
                                new City() { Name = "Santa fe" },
                                new City() { Name = "Useme" },
                                new City() { Name = "Bosa" },
                            }
                        },
                    }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Florida",
                            Cities = new List<City>() {
                                new City() { Name = "Orlando" },
                                new City() { Name = "Miami" },
                                new City() { Name = "Tampa" },
                                new City() { Name = "Fort Lauderdale" },
                                new City() { Name = "Key West" },
                            }
                        },
                        new State()
                        {
                            Name = "Texas",
                            Cities = new List<City>() {
                                new City() { Name = "Houston" },
                                new City() { Name = "San Antonio" },
                                new City() { Name = "Dallas" },
                                new City() { Name = "Austin" },
                                new City() { Name = "El Paso" },
                            }
                        },
                    }
                });
            }

            await _context.SaveChangesAsync();
        }


        private async Task CheckSedesAsync()
        {
            if (!_context.Campuses.Any())
            {
                _context.Campuses.Add(new Campus
                {
                    NameCam = "Empathy Sur",
                    AddressCam = "Cra 36 Sur # 20-20",
                    PhoneCam = "3044143038",
                    Doctors = new List<Doctor>()
                    {
                        new Doctor()
                        {
                            NameDoctor = "Laura Lopera",
                            SpecialtyDoc = "General",
                        },
                        new Doctor()
                        {
                            NameDoctor = "Hernan Cardona",
                            SpecialtyDoc = "Psicología",
                        },
                        new Doctor()
                        {
                            NameDoctor = "Hernan Cardona",
                            SpecialtyDoc = "Cardiología",
                        },
                        new Doctor()
                        {
                            NameDoctor = "Mariana Pulgar",
                            SpecialtyDoc = "Odontología",
                        },
                    }
                });
                _context.Campuses.Add(new Campus
                {
                    NameCam = "Empathy Norte",
                    AddressCam = "Diagonal 55 #105-33",
                    PhoneCam = "604-6045050",
                    Doctors = new List<Doctor>()
                    {
                        new Doctor()
                        {
                            NameDoctor = "Manuela Alejandra Londoño",
                            SpecialtyDoc = "General",
                        },
                        new Doctor()
                        {
                            NameDoctor = "Juan Sebastian Betancurt",
                            SpecialtyDoc = "Psicología",
                        },
                        new Doctor()
                        {
                            NameDoctor = "Alan Garcia",
                            SpecialtyDoc = "Cardiología",
                        },
                        new Doctor()
                        {
                            NameDoctor = "Maria Dahiana Bohorquez",
                            SpecialtyDoc = "Odontología",
                        },
                    }
                });

                _context.Campuses.Add(new Campus
                {
                    NameCam = "Empathy Occidente",
                    AddressCam = "Transversal 165 Avenida 33 Frente al cai",
                    PhoneCam = "604-60452020",
                    Doctors = new List<Doctor>()
                    {
                        new Doctor()
                        {
                            NameDoctor = "Maria Teresa Serna Ramirez",
                            SpecialtyDoc = "General",
                        },
                        new Doctor()
                        {
                            NameDoctor = "Andres Felipe Madrigal",
                            SpecialtyDoc = "Psicología",
                        },
                        new Doctor()
                        {
                            NameDoctor = "Manuel Miranda",
                            SpecialtyDoc = "Cardiología",
                        },
                        new Doctor()
                        {
                            NameDoctor = "Mauricio Montenegro",
                            SpecialtyDoc = "Odontología",
                        },
                    }
                });
            }

            await _context.SaveChangesAsync();
        }
        private async Task CheckProceduresAsync()
        {
            if (!_context.Procedures.Any())
            {
                _context.Procedures.Add(new Procedure { TypeProcedure = "Examen Hemograma"});
                _context.Procedures.Add(new Procedure { TypeProcedure = "Radiografia"});
                _context.Procedures.Add(new Procedure { TypeProcedure = "Cirugia"});
                _context.Procedures.Add(new Procedure { TypeProcedure = "Inyectología"});
                await _context.SaveChangesAsync();
            }
        }

      
        
    }
}
