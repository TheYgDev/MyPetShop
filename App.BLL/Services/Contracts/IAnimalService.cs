using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DAL.Models;
namespace App.BLL.Services.Contracts
{
    public interface IAnimalService
    {
        IEnumerable<Animal> Get();
        Animal GetById(int id);
        bool AddAsync(Animal animal);
		bool EditAsync(Animal animal);
		Animal Delete(int animalID);
        bool IsAlreadyIn(string name);
		IEnumerable<Animal> GetAnimalByCatgory(int Catogoryid, IEnumerable<Animal> animals = null!);
        IEnumerable<Animal> GetMostRatedAnimales(int howMany,IEnumerable<Animal> animals = null!);


    }
}
