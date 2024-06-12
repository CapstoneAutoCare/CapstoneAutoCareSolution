using Domain.Entities;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.SeedingData
{
    public partial class SeedingDataVehicles
    {
        private static List<Vehicles> Get(Client client, VehicleModel vehicleModel)
        {
            return new List<Vehicles>
        {
                new Vehicles
                {
                    Odo=1000,
                    VehiclesId=Guid.NewGuid(),
                    ClientId = client.ClientId,
                    VehicleModelId =vehicleModel.VehicleModelId,
                    CreatedDate = DateTime.Now,
                    Status=EnumStatus.ACTIVE.ToString(),
                    Color="RED",
                    Description="Vehicle",
                    LicensePlate="1111",
                },
                new Vehicles
                {
                    Odo=10000,
                    VehiclesId=Guid.NewGuid(),
                    ClientId = client.ClientId,
                    VehicleModelId =vehicleModel.VehicleModelId,
                    CreatedDate = DateTime.Now,
                    Status=EnumStatus.ACTIVE.ToString(),
                    Color="BLUE",
                    Description="Vehicle",
                    LicensePlate="1112",
                },
        };
        }
        public static List<Vehicles> ServiceSeedingDataVeHicles(ModelBuilder modelBuilder, List<Client> clients, List<VehicleModel> vehicleModels)
        {
            var vehicle = new List<Vehicles>();

            foreach (var client in clients)
            {
                foreach (var vehicleModel in vehicleModels)
                {
                    vehicle = Get(client, vehicleModel);
                    modelBuilder.Entity<Vehicles>().HasData(vehicle);
                }
            }
            return vehicle;

        }
    }
}
